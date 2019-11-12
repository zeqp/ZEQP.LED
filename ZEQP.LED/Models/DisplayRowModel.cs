using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEQP.LED.Models
{
    public class DisplayRowModel
    {
        public int RowNum { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public string BoxNo { get; set; }
        public override string ToString()
        {
            return $"{this.RowNum.ToString().PadCenter(3)}|{this.Code.PadCenter(12)}|{this.Count.ToString().PadCenter(5)}|{this.Total.ToString().PadCenter(5)}|{this.BoxNo.PadCenter(10)}";
        }
    }
}
