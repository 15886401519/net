using CsQuery;
using NPOI.SS.Formula.Functions;
using Retrieve.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve.Model
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
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="filePath">excel路径</param>
        /// <param name="isColumnName">第一行是否是列名</param>
        /// <returns></returns>
        void ClimbDataToExcel<T>(List<T> dataExcel);

        /// <summary>
        /// 批量导入Cas爬取数据
        /// </summary>
        /// <param name="strFile">excel路径</param>
        /// <returns></returns>
        List<ClimbData> ExcelFind(string strFile);

    }
}
