using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve.Model.Data
{
    public class ClimbData
    {
        public int ID { get; set; }
        public string CAS { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// 联系传真
        /// </summary>
        public string ContactFax { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string CnName { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 其它数据
        /// </summary>
        public string OtherData { get; set; }
        /// <summary>
        /// 主营产品
        /// </summary>
        public string MainProducts { get; set; }
        /// <summary>
        /// 产品目录
        /// </summary>
        public string ProductList { get; set; }

        public string ProductPage { get; set; }
        /// <summary>
        /// 数据来源
        /// </summary>
        public string SourceNews { get; set; }
    }
}
