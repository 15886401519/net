using CsQuery;
using Retrieve.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve.Tool
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
                climbData.SourceNews = "https://www.chemicalbook.com";
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
                climbData.SourceNews = "https://www.chemicalbook.com";
                var EnNameAndCas = ProLbox[i].Cq().Find("table tr");
                foreach (var item in EnNameAndCas)
                {
                    var TexSpan = item.Cq().Find("td").Text().Replace(" ", "").Trim(); ;
                   

                }
            }


            return new List<ClimbData>();
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
                climbData.SourceNews = "https://china.guidechem.com";
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
    }
}
