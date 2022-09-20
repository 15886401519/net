using CsQuery;
using CsQuery.Promises;
using CsQueryFramawork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CsQueryFramawork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            testEntities _db = new testEntities();
            // 349 384 429 452
            for (int j = 481; j <484; j++)
            {
                List<I_Cas> ListCas = new List<I_Cas>();//存储爬取数据
                string pathUrl = "https://www.chemicalbook.com/CASDetailList_" + (j * 100) + ".htm";
                var promise = CQ.CreateFromUrl(pathUrl);
                //var promise = CQ.CreateFromUrl("https://www.chemicalbook.com/CASDetailList_0.htm ");
                var CASTable = promise.Find("table tbody");//获取table列表html
                var ChildTr = CASTable.Select("tr");
                int TrSum = ChildTr.Count();
                //var ChildTd = CASTable.Select("tr td");

                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("-----------------开始爬取------------------");
                Console.WriteLine(ChildTr.Count());

                for (int i = 1; i < TrSum; i++)
                {
                    I_Cas cas = new I_Cas();
                    var ChildTd = ChildTr[i].ChildElements.ToList();
                    cas.CAS = StrRetun(ChildTd[0]);
                    cas.CnName = StrRetun(ChildTd[1]);
                    cas.EnName = StrRetun(ChildTd[2]);
                    cas.MF = StrRetun(ChildTd[3]);
                    ListCas.Add(cas);
                }

                Console.WriteLine("爬取结束");
                Console.WriteLine("爬取结束条数：" + ListCas.Count);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("导入数据库条数："+ListCas.Count);
               
                //查看问题出在何处
                //for (int i = 0; i < ListCas.Count; i++)
                //{
                //    _db.I_Cas.Add(ListCas[i]);
                //    _db.SaveChanges();
                //}

                
                try
                {
                    _db.I_Cas.AddRange(ListCas);
                    _db.SaveChanges();
                }
                catch (Exception)
                {

                    for (int i = 0; i < ListCas.Count; i++)
                    {
                        try
                        {
                            _db.I_Cas.Add(ListCas[i]);
                            _db.SaveChanges();
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            //CQ.CreateFromUrl("http://www.jquery.com", successDelegate, failureDelegate);
        }
        /// <summary>
        /// 父节点获取子节点Test
        /// </summary>
        /// <param name="doms"></param>
        /// <returns></returns>
        public static string StrRetun(IDomElement doms)
        {
            if (doms==null)
                return "";
            if (!string.IsNullOrEmpty(doms.InnerText.Replace("\n","").Trim()))
                return doms.InnerText.Replace("\n", "").Trim();
            if (doms.FirstElementChild.FirstChild==null)
                return "";
            if (!string.IsNullOrEmpty(doms.FirstElementChild.FirstChild.NodeValue.Replace("\n", "").Trim()))
                return doms.FirstElementChild.FirstChild.NodeValue.Replace("\n", "").Trim();

            return "";
        }

        private static string padRightEx(string str, int totalByteCount)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount);
            return w;
        }
        static async Task<string> GetBaidu()
        {
            WebClient webClient = new WebClient();
            Console.WriteLine("开爬！");
            webClient.Encoding = Encoding.UTF8;
            //string html = await webClient.DownloadStringTaskAsync("http://www.baidu.com");
            string html = await webClient.DownloadStringTaskAsync("https://www.bilibili.com");
            Console.WriteLine("爬完~");
            return html;
        }
    }
}
