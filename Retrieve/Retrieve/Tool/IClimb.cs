using CsQuery;
using Retrieve.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve.Tool
{
    public interface IClimb
    {
        /// <summary>
        /// 爬取ChemicalBook页面数据
        /// </summary>
        List<ClimbData> ChemicalBookClimb(CQ promise);
        /// <summary>
        /// 爬取GuiDechem页面数据
        /// </summary>
        List<ClimbData> GuiDechemClimb(CQ promise);
        /// <summary>
        /// 爬取ChemNet页面数据
        /// </summary>
        List<ClimbData> ChemNetClimb(CQ promise);
    }
}
