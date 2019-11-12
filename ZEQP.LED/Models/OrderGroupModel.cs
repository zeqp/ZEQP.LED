using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEQP.LED.Models
{
    public class OrderGroupModel
    {
        /// <summary>
        /// 类型（出库/入库）
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string ProjectNo { get; set; }
        /// <summary>
        /// 出库/入库 时间
        /// </summary>
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 列表数据
        /// </summary>
        public List<DisplayRowModel> ListData { get; set; }
    }
}
