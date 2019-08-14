using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZEQP.Entities.LED
{
    public class LEDContext : DbContext
    {
        public LEDContext()
            : base("OracleDbContext")
        { }

        public DbQuery<V_InOrder> InOrder { get; set; }
        public DbQuery<V_OutOrder> OutOrder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
