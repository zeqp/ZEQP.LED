using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEQP.LED.Models
{
    public class BaseOrderModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Seq { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 物料编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 项目号
        /// </summary>
        public string ProjectNo { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 箱号
        /// </summary>
        public string BoxNo { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime OrderTime { get; set; }
    }

}
