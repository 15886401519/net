using CsQuery;
using NPOI.SS.Formula.Functions;
using Retrieve.Model.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retrieve.Model
{
    public class Climb : IClimb
    {
        public List<ClimbData> ChemicalBookClimb(CQ promise)
        {
            List<ClimbData> list = new List<ClimbData>();
            var ProListBox = promise.Find(".ProListBox");
            var ProLbox = ProListBox.Select(".ProLbox");
            for (int i = 0; i < ProLbox.Count(); i++)
            {
                ClimbData climbData = new ClimbData();
                climbData.CompanyName = ProLbox[i].Cq().Find(".ProLboxTit .Downwards").Text().Replace(" ","").Trim();
                climbData.SourceNews = "(ChemicalBook)https://www.chemicalbook.com";
                var EnNameAndCas = ProLbox[i].Cq().Find("li");
                foreach (var item in EnNameAndCas)
                {
                    var TexSpan = item.Cq().Find("span").Text().Replace(" ", "").Trim();
                    if (TexSpan.Contains("联系电话"))
                        climbData.ContactNumber = item.Cq().Find("p").Text().Replace("\n",";").Replace(" ", "").Trim();
                    if (TexSpan.Contains("中文名称"))
                        climbData.CnName = item.Cq().Find("h2").Text().Replace(" ", "").Trim();
                    if (TexSpan.Contains("英文名称"))
                        climbData.EnName = item.Cq().Find("h2").Text().Replace(" ", "").Trim();
                    if (TexSpan.Contains("CAS"))
                        climbData.CAS = item.Cq().Text().Replace("CAS：","").Replace("\n","").Replace(" ", "").Trim();
                    if (TexSpan.Contains("其它信息"))
                        climbData.OtherData = item.Cq().Find("b").Text().Replace(" ", "").Trim();
                }

                list.Add(climbData);
            }
            return list;
        }

        public List<ClimbData> ChemNetClimb(CQ promise)
        {
            List<ClimbData> list = new List<ClimbData>();
            var ProListBox = promise.Find(".gys");
            var ProLbox = ProListBox.Find("dl dd form");
            for (int i = 0; i < ProLbox.Count(); i++)
            {
                ClimbData climbData = new ClimbData();
                climbData.CAS = ProListBox.Find("dt span .reds").Text();
                climbData.SourceNews = "中国化工网(http://china.chemnet.com)";
                var EnNameAndCas = ProLbox[i].Cq().Find("table tr");
                foreach (var item in EnNameAndCas)
                {
                    var TexSpan = item.Cq().Find("td").Text().Trim();
                    if (TexSpan.Contains("公司名称"))
                    {
                        TexSpan = TexSpan.Replace("\n", "").Replace("\t","").Replace(" ", "").Trim();
                        int TexInt = TexSpan.IndexOf("在线询盘");
                        climbData.CompanyName = TexSpan.Substring(0, TexInt).Replace("公司名称", "");
                        climbData.ProductPage = item.Cq().Find("a")[0].Cq().Attr("href");
                    }
                    if (TexSpan.Contains("联系电话"))
                        climbData.ContactNumber = TexSpan.Replace("联系电话", "");
                    if (TexSpan.Contains("联系传真"))
                        climbData.ContactFax = TexSpan.Replace("联系传真", "");
                }
                list.Add(climbData);
            }
            return list;
        }

        public List<ClimbData> GuiDechemClimb(CQ promise)
        {
            List<ClimbData> list = new List<ClimbData>();
            var ProListBox = promise.Find(".ch_m_rig2");
            var ProLbox = ProListBox.Find("dl dd");
            for (int i = 0; i < ProLbox.Count(); i++)
            {
                ClimbData climbData = new ClimbData();
                climbData.CompanyName = ProLbox[i].Cq().Find(".m_ri_t_lk1 a").Text();
                climbData.CAS = promise.Select(".erch_m_left .ch_m_le1 h1").Text().Replace(" ","").Trim();
                climbData.SourceNews = "(盖德化工网)https://china.guidechem.com";
                var ListDatali = ProLbox[i].Cq().Find(".h_m_ri_tp2 li");
                foreach (var item in ListDatali)
                {
                    var TexSpan = item.Cq().Find("span").Text().Replace(" ", "").Trim();
                    if (TexSpan.Contains("联系电话"))
                        climbData.ContactNumber = item.Cq().Find("em").Text().Replace(" ", ";").Trim();
                    if (TexSpan.Contains("主营产品"))
                        climbData.MainProducts = item.Cq().Find("em").Text().Replace(" ", ";").Trim();
                    if (TexSpan.Contains("产品目录"))
                        climbData.ProductList = item.Cq().Find("em").Text().Replace(" ", "").Trim();
                    if (TexSpan.Contains("产品名称"))
                        climbData.CnName = item.Cq().Find("em").Text().Replace(" ", "").Trim();
                    if (TexSpan.Contains("产品属性"))
                        climbData.OtherData = item.Cq().Find("em").Text().Replace(" ", "").Replace("\n","").Trim();
                    if (TexSpan.Contains("参考价"))
                        climbData.OtherData = item.Cq().Find("em i").Text().Replace(" ", "").Replace("\n", "").Trim();
                }
                
                list.Add(climbData);
            }
            return list;
        }

        public void ClimbDataToExcel<T>(List<T> dataExcel)
        {
            try
            {
                //要导出的csv文件的存放位置
                string fullPath = System.IO.Path.Combine(@"E:\", "badao.xls");
                FileInfo fi = new FileInfo(fullPath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                StringBuilder data = new StringBuilder();

                PropertyInfo[] properties = dataExcel[0].GetType().GetProperties();//为空进不来
                foreach (PropertyInfo item in properties)
                    data.Append(item.Name + ",");
                //data.Append("姓名,年龄,地址,性别,生日");
                //换行
                sw.WriteLine(data);

                //构建大数据量
                //List<ClimbData> bigData = new List<ClimbData>();
                //for (int i = 0; i < 1000000; i++)
                //{
                //    ClimbData item = new ClimbData();
                //    item.CnName = "霸道" + i;
                //    item.CAS = i.ToString();
                //    item.EnName = "青岛" + i;
                //    item.CompanyName = i.ToString();
                //    item.OtherData = DateTime.Now.ToString();
                //    bigData.Add(item);
                //}



                //写出各行数据
                foreach (T item in dataExcel)
                {

                    data = new StringBuilder();

                    data.Append(item.ID);
                    data.Append(",");
                    data.Append(item.CAS);
                    data.Append(",");
                    data.Append(item.EnName);
                    data.Append(",");
                    data.Append(item.CompanyName);
                    data.Append(",");
                    data.Append(item.OtherData);
                    data.Append(",");
                    //换行
                    sw.WriteLine(data);

                }
                //关闭
                sw.Close();
                fs.Close();
                MessageBox.Show("导出成功");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                MessageBox.Show("导出失败:" + ex);
            }
        }

        public List<ClimbData> ExcelFind(string strFile)
        {
            throw new NotImplementedException();
        }
    }
}
