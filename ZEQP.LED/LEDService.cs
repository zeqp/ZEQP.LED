using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;
using ZEQP.LED.Models;
namespace ZEQP.LED
{
    public class LEDService : ServiceControl
    {
        private LogWriter Log { get; set; }
        private string CardIP { get; set; }
        private uint CardPort { get; set; }
        /// <summary>
        /// 是否初始化
        /// </summary>
        private bool IsReady { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        private uint DeviceId { get; set; }
        /// <summary>
        /// 设备是否在线
        /// </summary>
        private bool DeviceOnline { get; set; }
        private ZHLED.LedAgent.OnDeviceNotify DeviceCallback { get; set; }

        private ConcurrentQueue<OrderGroupModel> QueueData { get; set; }
        private System.Timers.Timer ShowDataTimer { get; set; }


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

            this.ShowDataTimer = new System.Timers.Timer(5000);
            this.ShowDataTimer.Elapsed += ShowDataTimer_Elapsed;
        }

        private void ShowDataTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var timer = sender as System.Timers.Timer;
            try
            {
                timer.Stop();
                if (this.QueueData.IsEmpty)
                    this.GetData();
                else
                {
                    OrderGroupModel CurData = null;
                    var canDequeue = this.QueueData.TryDequeue(out CurData);
                    if (canDequeue)
                    {
                        this.Log.Info($"显示数据：{Environment.NewLine}{JsonConvert.SerializeObject(CurData)}");
                        ZHLED.LedAgent.ShowInstantText(this.DeviceId, 0U, 1U, new StringBuilder(CurData.Type), 61U);
                        ZHLED.LedAgent.ShowInstantText(this.DeviceId, 0U, 1U, new StringBuilder(CurData.ProjectNo), 62U);
                        ZHLED.LedAgent.ShowInstantText(this.DeviceId, 0U, 1U, new StringBuilder(CurData.OrderTime.ToString("yyyy-MM-dd HH:mm")), 63U);
                        if (CurData.ListData.Count > 6)
                        {
                            var newModel = new OrderGroupModel()
                            {
                                Type = CurData.Type,
                                ProjectNo = CurData.ProjectNo,
                                OrderTime = CurData.OrderTime,
                                ListData = CurData.ListData.OrderBy(o => o.RowNum).Skip(6).ToList()
                            };
                            this.QueueData.Enqueue(newModel);
                        }
                        var listData = CurData.ListData.OrderBy(o => o.RowNum).Take(6).ToList();
                        for (int i = 0; i < 6; i++)
                        {
                            var item = listData.ElementAtOrDefault(i);
                            var text = new StringBuilder(item == null ? DisplayRowModel.Empty : item.ToString());
                            ZHLED.LedAgent.ShowInstantText(this.DeviceId, 0U, 1U, text, (uint)((i + 1) * 10 + 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log.Error(ex.Message, ex);
            }
            finally
            {
                timer.Start();
            }
        }

        private void GetData()
        {
            try
            {
                var inOrder = LEDData.GetInOrder();
                this.Log.Info("入库数据：\r\n" + JsonConvert.SerializeObject(inOrder));
                var inGroup = LEDData.Convert(inOrder);
                foreach (var item in inGroup)
                {
                    this.QueueData.Enqueue(item);
                }
                var outOrder = LEDData.GetOutOrder();
                this.Log.Info("出库数据：\r\n" + JsonConvert.SerializeObject(outOrder));
                var outGroup = LEDData.Convert(outOrder);
                foreach (var item in outGroup)
                {
                    this.QueueData.Enqueue(item);
                }
            }
            catch (Exception ex)
            {
                this.Log.Error("获取数据出错", ex);
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
                this.ShowDataTimer.Start();
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
            this.ShowDataTimer.Stop();
            this.DeviceId = 0;
            this.DeviceOnline = false;
            this.IsReady = false;
            return true;
        }
    }
}
