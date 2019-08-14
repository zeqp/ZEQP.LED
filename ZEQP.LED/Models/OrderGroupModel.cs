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
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 项目号
        /// </summary>
        public string ProjectNo { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime OrderTime { get; set; }
    }
}
