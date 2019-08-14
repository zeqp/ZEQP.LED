using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEQP.Entities.LED
{
    [Table("v_inorder")]
    public class V_InOrder
    {
        [Key]
        [Column("序号")]
        public int Seq { get; set; }

        [Column("类型")]
        public string Type { get; set; }

        [Column("物料编号")]
        public string Code { get; set; }

        [Column("项目号")]
        public string ProjectNo { get; set; }

        [Column("入库数量")]
        public int Count { get; set; }

        [Column("库存数量")]
        public int Total { get; set; }

        [Column("箱号")]
        public string BoxNo { get; set; }

        [Column("入库时间")]
        public DateTime OrderTime { get; set; }
    }
}
