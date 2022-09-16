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
    public partial class Form1 : Form
    {
        List<Task> tasks = new List<Task>();
        static List<ClimbData> files;
        public Form1()
        {
            InitializeComponent();
        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            files = new List<ClimbData>();
            if (ChemicalBookCheck.Checked)
                tasks.Add(Task.Run(() => ChemicalBookCrawling("https://www.chemicalbook.com", searchTxtBox.Text)));
            if (GuiDeChemCheck.Checked)
                tasks.Add(Task.Run(() => GuiDechemCrawling("https://china.guidechem.com", searchTxtBox.Text)));
            if (ChemNetCheck.Checked)
                tasks.Add(Task.Run(() => ChemNetCrawling("http://china.chemnet.com", searchTxtBox.Text)));
            Task t =  Task.WhenAll(tasks.ToArray());
            try
            {
                t.Wait();
            }
            catch {}

        //https://china.guidechem.com/common/searchhistory.jsp?keys=10277-43-7&type=pro&pageUrl=https://china.guidechem.com/cas/16320.html
        //https://china.guidechem.com/common/searchhistory.jsp?keys=865-47-4&type=pro&pageUrl=https://china.guidechem.com/cas/16320.html
            //DbHelperSQL.
            string a = "";

        }

        //思路 搜索几个网页 则使用几个线程 提高速率
        public static void ChemicalBookCrawling(string url,string searchTxt)
        {
            //已完成  但为了方面调试其它方法 关闭 
            return;
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
                string pageUrl = url + $"&page={i}&current=page";
                var promisePage = CQ.Create(httpClient.httpGet(pageUrl, httpClient.defaultHeaders));
                files = files.Union(climb.ChemicalBookClimb(promisePage)).ToList();
            }
            
        }
        public static void GuiDechemCrawling(string url, string searchTxt)
        {
            //已完成  但为了方面调试其它方法 关闭 
            return;
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
                string pageUrl = LocationhttpUrl + $"?pageNo={i}&";
                var promisePage = CQ.Create(httpClient.httpGet(LocationhttpUrl, httpClient.defaultHeaders));
                files = files.Union(climb.GuiDechemClimb(promisePage)).ToList();
            }

        }
        public static void ChemNetCrawling(string url, string searchTxt)
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
                    url = "http://china.chemnet.com/product/"+item.Cq().Attr("href");
                    break;
                }
            }
            var ListhttpTxt = httpClient.httpGet(url, httpClient.defaultHeaders);
            var Listpromise = CQ.Create(ListhttpTxt);
            Climb climb = new Climb();
            files = files.Union(climb.ChemNetClimb(Listpromise)).ToList();

            string aaaa = "";


        }
    }
}
