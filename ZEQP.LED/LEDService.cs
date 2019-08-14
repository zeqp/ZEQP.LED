using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;
using ZEQP.LED.Models;
using Newtonsoft.Json;
namespace ZEQP.LED
{
    public class LEDService : ServiceControl
    {
        public LogWriter Log { get; set; }
        public string CardIP { get; set; }
        public uint CardPort { get; set; }
        /// <summary>
        /// 是否初始化
        /// </summary>
        public bool IsReady { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public uint DeviceId { get; set; }
        /// <summary>
        /// 设备是否在线
        /// </summary>
        public bool DeviceOnline { get; set; }
        private ZHLED.LedAgent.OnDeviceNotify DeviceCallback { get; set; }

        private System.Timers.Timer GetDataTimer { get; set; }
        private System.Timers.Timer ShowDataTimer { get; set; }

        public List<BaseOrderModel> ListData { get; set; }
        //public ILookup<OrderGroupModel, BaseOrderModel> LookupData { get; set; }
        //public IGrouping<OrderGroupModel,BaseOrderModel> CurData { get; set; }
        public LEDService()
        {
            this.CardIP = ConfigurationManager.AppSettings["CardIP"];
            this.CardPort = uint.Parse(ConfigurationManager.AppSettings["CardPort"]);
            this.Log = HostLogger.Get<LEDService>();
            this.Log.Info("LEDService Init");
            this.Log.InfoFormat("IP:{0},Port:{1}", this.CardIP, this.CardPort);
            this.DeviceId = 0;
            this.IsReady = false;
            this.DeviceOnline = false;
            this.DeviceCallback = new ZHLED.LedAgent.OnDeviceNotify(OnDeviceNotified);


            this.GetDataTimer = new System.Timers.Timer(5 * 1000);
            this.GetDataTimer.Elapsed += GetDataTimer_Elapsed;
            this.ListData = new List<BaseOrderModel>();
        }

        private void GetDataTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var timer = sender as System.Timers.Timer;
            try
            {
                timer.Stop();
                this.ListData.Clear();
                var inOrder = LEDData.GetInOrder();
                this.Log.Info("入库数据：\r\n" + JsonConvert.SerializeObject(inOrder));
                this.ListData.AddRange(inOrder);
                var outOrder = LEDData.GetOutOrder();
                this.Log.Info("出库数据：\r\n" + JsonConvert.SerializeObject(outOrder));
                this.ListData.AddRange(outOrder);
                var lookupData = this.ListData.ToLookup(k => new { k.Type, k.ProjectNo, k.OrderTime });
                foreach (var item in lookupData)
                {
                    this.Log.Info($"类型:{item.Key.Type},项目：{item.Key.ProjectNo},时间：{item.Key.OrderTime}");
                    foreach (var row in item)
                    {
                        this.Log.Info($"序号：{row.Seq},物料:{row.Code}");
                    }
                    Thread.Sleep(5 * 1000);
                }
            }
            catch (Exception ex)
            {
                this.Log.Error("获取数据出错", ex);
            }
            finally
            {
                timer.Start();
            }
        }
        public void OnDeviceNotified(uint uDeviceId, IntPtr pNotifiedData, uint uCommand, IntPtr pUserParam)
        {
            if (this.DeviceId == uDeviceId && uCommand == 0)
            {
                this.DeviceOnline = (pNotifiedData != null && (int)pNotifiedData != 0);
            }
            this.Log.Info($"OnDeviceNotified:\r\nDeviceId:{uDeviceId}\r\nCommand:{uCommand}\r\nDeviceOnline:{this.DeviceOnline}");
        }
        public bool Start(HostControl hostControl)
        {
            var init = ZHLED.LedAgent.Init();
            if (init == 1)
            {
                this.IsReady = true;
                this.Log.Info("初始化成功");
            }
            else
            {
                this.Log.Error("初始化失败");
            }
            if (!this.IsReady)
                return this.IsReady;

            var driveId = ZHLED.LedAgent.RegisterDevice(this.CardIP, this.CardPort, this.DeviceCallback, IntPtr.Zero);
            if (driveId != 0)
            {
                this.DeviceId = driveId;
                this.Log.Info($"添加设备成功,设备ID：{driveId}");
                this.GetDataTimer.Start();
                return true;
            }
            this.Log.Error("添加设备失败");
            return false;
        }

        public bool Stop(HostControl hostControl)
        {
            if (this.DeviceId != 0)
                ZHLED.LedAgent.UnregisterDevice(this.DeviceId);
            if (this.IsReady)
                ZHLED.LedAgent.DeInit();
            this.GetDataTimer.Stop();
            this.DeviceId = 0;
            this.DeviceOnline = false;
            this.IsReady = false;
            return true;
        }
    }
}
