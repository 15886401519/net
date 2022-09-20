using Retrieve.Model.Data;
using Retrieve.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsQuery;
using System.Text.RegularExpressions;
using Retrieve.Tool;

namespace Retrieve
{
    public partial class Retrieve : Form
    {
        List<Task> tasks;
        static List<ClimbData> files;
        public Retrieve()
        {
            InitializeComponent();
        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadingHelper.ShowLoadingScreen();
                tasks = new List<Task>();
                files = new List<ClimbData>();
                if (ChemicalBookCheck.Checked)
                    tasks.Add(Task.Run(() => ChemicalBookCrawling("https://www.chemicalbook.com", searchTxtBox.Text.Trim())));
                if (GuiDeChemCheck.Checked)
                    tasks.Add(Task.Run(() => GuiDechemCrawling("https://china.guidechem.com", searchTxtBox.Text.Trim())));
                if (ChemNetCheck.Checked)
                    tasks.Add(Task.Run(() => ChemNetCrawling("http://china.chemnet.com", searchTxtBox.Text.Trim())));
                laddimgTxt.Visible = true;
                Task t = Task.WhenAll(tasks.ToArray());
                try
                {
                    t.Wait();
                }
                catch { }
                laddimgTxt.Visible = false;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = files;
                resultNum.Text = "查询结果条数:" + files.Count.ToString();
                LoadingHelper.CloseForm();
            }
            catch (Exception)
            {
                LoadingHelper.CloseForm();
                MessageBox.Show("查询报错，请重新查询。","提示");
                throw;
            }


        }
        //思路 搜索几个网页 则使用几个线程 提高速率
        public  void ChemicalBookCrawling(string url, string searchTxt)
        {
            try
            {
                //精准查询
                url = url + "/ProductList.aspx?kwd=" + searchTxt;
                HttpRequestClient httpClient = new HttpRequestClient();
                var httpTxt = httpClient.httpGet(url, httpClient.defaultHeaders);
                var promise = CQ.Create(httpTxt);
                Climb climb = new Climb();
                files = files.Union(climb.ChemicalBookClimb(promise)).ToList();


                Regex reg = new Regex(@"/[0-9]*");
                var page = reg.Match(promise.Find(".pageTop").Text().Replace(" ", "").Trim()).ToString();
                int pageNum = Convert.ToInt32(Regex.Replace(page, @"[^0-9]+", ""));//获取分页页数
                for (int i = 2; i <= pageNum; i++)
                {
                    try
                    {
                        string pageUrl = url + $"&page={i}&current=page";
                        var promisePage = CQ.Create(httpClient.httpGet(pageUrl, httpClient.defaultHeaders));
                        files = files.Union(climb.ChemicalBookClimb(promisePage)).ToList();
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                //notificationListTxt.Items.Add(e.Message+ "chemicalbook");
                throw e;
            }


        }
        public  void GuiDechemCrawling(string url, string searchTxt)
        {
            try
            {
                url = $"https://china.guidechem.com/product/listc_keys-{searchTxt}-p1.html";
                HttpRequestClient httpClient = new HttpRequestClient();
                var LocationhttpUrl = httpClient.Locationhttp(url, "GET", httpClient.defaultHeaders, null, null, true, null);
                var httpTxt = httpClient.httpGet(LocationhttpUrl, httpClient.defaultHeaders);
                var promise = CQ.Create(httpTxt);
                Climb climb = new Climb();
                files = files.Union(climb.GuiDechemClimb(promise)).ToList();


                var page = promise.Select(".page span").Text().Replace(" ", "").Trim().ToString();
                int pageNum = Convert.ToInt32(Regex.Replace(page, @"[^0-9]+", ""));//获取分页页数
                for (int i = 2; i < pageNum; i++)
                {
                    try
                    {
                        string pageUrl = LocationhttpUrl + $"?pageNo={i}&";
                        var promisePage = CQ.Create(httpClient.httpGet(LocationhttpUrl, httpClient.defaultHeaders));
                        files = files.Union(climb.GuiDechemClimb(promisePage)).ToList();
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                //notificationListTxt.Items.Add(e.Message+ "guidechem");
                throw e;
            }
        }
        public  void ChemNetCrawling(string url, string searchTxt)
        {
            try
            {
                url = $"http://china.chemnet.com/product/search.cgi?type=word&f=plist&terms={searchTxt}";
                HttpRequestClient httpClient = new HttpRequestClient();
                var httpTxt = httpClient.httpGet(url, httpClient.defaultHeaders);
                var promise = CQ.Create(httpTxt);
                var PromiseListUrl = promise.Find(".sj-list a");
                foreach (var item in PromiseListUrl)
                {
                    var AUrlTxt = item.Cq().Text();
                    if (AUrlTxt.Contains(searchTxt))
                    {
                        url = "http://china.chemnet.com/product/" + item.Cq().Attr("href");
                        break;
                    }
                }
                var ListhttpTxt = httpClient.httpGet(url, httpClient.defaultHeaders);
                var Listpromise = CQ.Create(ListhttpTxt);
                Climb climb = new Climb();
                files = files.Union(climb.ChemNetClimb(Listpromise)).ToList();
                var page = Listpromise.Select(".gys dd h6 div").Text();
                var pageNum = Math.Ceiling(Convert.ToInt32(Regex.Replace(page.Substring(0, page.IndexOf("记录")), @"[^0-9]+", "")) / 10d);//获取数据数量 向上取整
                for (int i = 1; i < pageNum; i++)
                {
                    try
                    {
                        string pageUrl = url.Replace("pclist--", "search.cgi?skey=").Replace("--1.html", ";") + $"use_cas=1;f=pclist;p={i}";
                        var promisePage = CQ.Create(httpClient.httpGet(pageUrl, httpClient.defaultHeaders));
                        files = files.Union(climb.ChemNetClimb(promisePage)).ToList();
                    }
                    catch
                    {
                        continue;
                    }
                    
                }
            }
            catch (Exception e)
            {
                //notificationListTxt.Items.Add(e.Message+ "chemnet");
                throw e;
            }

        }

        private void CToExcelBtn_Click(object sender, EventArgs e)
        {
            LoadingHelper.ShowLoadingScreen();
            Climb climb = new Climb();
            files = new List<ClimbData>();

            files.Add(new ClimbData() { CAS="555",CompanyName="lookchem",CnName="奥里给"});
            climb.ClimbDataToExcel(files);
            LoadingHelper.CloseForm();

            return;
            if (files == null || files.Count < 1)
            {
                LoadingHelper.CloseForm();
                MessageBox.Show("数据为空，请先通过关键字搜索","提示");
                return;
            }

            //Thread.Sleep(3000);

        }
    }
}
