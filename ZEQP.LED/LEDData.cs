using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ZEQP.LED.Models;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ZEQP.LED
{
    public static class LEDData
    {
        public static List<V_InOrder> GetInOrder()
        {
            var connStr = ConfigurationManager.ConnectionStrings["oracle"].ConnectionString;
            DataTable dt = new DataTable();
            using (var conn = new OracleConnection(connStr))
            {
                var adp = new OracleDataAdapter("select * from v_inorder", conn);
                adp.Fill(dt);
            }
            var result = new List<V_InOrder>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new V_InOrder();
                item.Seq = int.Parse(row["序号"].ToString());
                item.Type = row["类型"].ToString();
                item.Code = row["物料编号"].ToString();
                item.ProjectNo = row["项目号"].ToString();
                item.Count = int.Parse(row["入库数量"].ToString());
                item.Total = int.Parse(row["库存数量"].ToString());
                item.BoxNo = row["箱号"].ToString();
                item.OrderTime = DateTime.Parse(row["入库时间"].ToString());
                result.Add(item);
            }
            return result;
        }

        public static List<V_OutOrder> GetOutOrder()
        {
            var connStr = ConfigurationManager.ConnectionStrings["oracle"].ConnectionString;
            DataTable dt = new DataTable();
            using (var conn = new OracleConnection(connStr))
            {
                var adp = new OracleDataAdapter("select * from v_outorder", conn);
                adp.Fill(dt);
            }
            var result = new List<V_OutOrder>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new V_OutOrder();
                item.Seq = int.Parse(row["序号"].ToString());
                item.Type = row["类型"].ToString();
                item.Code = row["物料编号"].ToString();
                item.ProjectNo = row["项目号"].ToString();
                item.Count = int.Parse(row["入库数量"].ToString());
                item.Total = int.Parse(row["库存数量"].ToString());
                item.BoxNo = row["箱号"].ToString();
                item.OrderTime = DateTime.Parse(row["入库时间"].ToString());
                result.Add(item);
            }
            return result;
        }
    }
}
