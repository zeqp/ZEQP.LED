using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace DeviceControllor
{
    public partial class Form1 : Form
    {
        SynchronizationContext m_SyncContext = null;
        private uint m_iCurrentDeviceId = 0;
        private ZHLED.LedAgent.OnDeviceNotify m_fCallback = new ZHLED.LedAgent.OnDeviceNotify(OnDeviceNotified);
        private int m_isReady = 0;

        private static Form1 m_form = null;
        public static void OnDeviceNotified(uint uDeviceId, IntPtr pNotifiedData, uint uCommand, IntPtr pUserParam)
        {
            string msg = "failure";
            if (pNotifiedData != null && (int)pNotifiedData != 0)
            {
                msg = "success";
            }
            m_form.m_SyncContext.Post(m_form.OnMessage, new DeviceMessage(uDeviceId, uCommand, msg));
        }
        public Form1()
        {
            InitializeComponent();

            OnInitDialog();

            m_form = this;
            m_SyncContext = SynchronizationContext.Current;
        }
        private void OnMessage(object o)
        {
            DeviceMessage msg = (DeviceMessage)o;
            for (int i = 0; i < this.listView_devicelist.Items.Count; i++ )
            {
                ListViewItem item = this.listView_devicelist.Items[i];
                if (uint.Parse(item.SubItems[3].Text) == msg.m_deviceId)
                {
                    if (msg.m_command == 0)
                    {
                        item.SubItems[2].Text = msg.m_content == "success" ? "在线" : "断开";
                    }

                    this.log.AppendText(item.SubItems[0].Text + ":" + item.SubItems[1].Text +
                                        " command: " + ConvertCommandToString(msg.m_command) + " " + msg.m_content + "\r\n");
                    return;
                }
            }

            this.log.AppendText("Unknown deviceId: " +Convert.ToString(msg.m_deviceId) + " command: " + Convert.ToString(msg.m_command) + " " + msg.m_content + "\r\n");
        }
        private void OnInitDialog()
        {
            this.comboBox_store_color.Items.AddRange(new object[] { "RED", "GREEN", "YELLOW", "BLUE", "PURPLE", "CYAN", "WHITE" });
            this.comboBox_store_color.SelectedIndex = 0;

            this.comboBox_store_EncodingFormat.Items.AddRange(new object[] { "UNICODE", "GB2312" });
            this.comboBox_store_EncodingFormat.SelectedIndex = 0;

            this.comboBox_instant_color.Items.AddRange(new object[] {"RED", "GREEN", "YELLOW", "BLUE", "PURPLE", "CYAN", "WHITE"});
            this.comboBox_instant_color.SelectedIndex = 0;

            this.comboBox_instant_EncodingFormat.Items.AddRange(new object[] {"UNICODE", "GB2312"});
            this.comboBox_instant_EncodingFormat.SelectedIndex = 0;

            this.listView_devicelist.Columns.Add("地址", 120, HorizontalAlignment.Right);
            this.listView_devicelist.Columns.Add("端口", 60, HorizontalAlignment.Right);
            this.listView_devicelist.Columns.Add("状态", 80, HorizontalAlignment.Center);
            this.listView_devicelist.Columns.Add("ID", 30, HorizontalAlignment.Right);

            this.textBox_ip.Text = "192.168.9.100";
            this.textBox_port.Text = "58258";

            this.button_init.Enabled = true;
            this.button_revInit.Enabled = false;

            this.textBox_CharacterPartition.Text = "0";
        }
        private void OnDeviceListMouseClicked(object sender, MouseEventArgs e)
        {
            m_iCurrentDeviceId = 0;
            this.textBox_ip.Text = "";
            this.textBox_port.Text = "";

            if (this.listView_devicelist.SelectedItems.Count > 0)
            {
                this.textBox_ip.Text = this.listView_devicelist.SelectedItems[0].SubItems[0].Text;
                this.textBox_port.Text = this.listView_devicelist.SelectedItems[0].SubItems[1].Text;

                m_iCurrentDeviceId = uint.Parse(this.listView_devicelist.SelectedItems[0].SubItems[3].Text);
            }
        }
        private string ConvertCommandToString(uint uCommand)
        {
            switch (uCommand)
            {
                case 0x21:
                    return ("打开屏幕");
                case 0x22:
                    return ("关闭屏幕");
                case 0x24:
                    return ("设置亮度");
                case 0x29:
                    return ("设置文本");
                case 0x2A:
                    return ("删除文本");
                case 0x3F:
                    return ("切换文本");
                case 0:
                    return "设备连接";
                default:
                    return ("未知动作");
            }
        }
        private uint ConvertToEncodeType(string sText)
        {
            /*
             * 
             *  enum TEXT_ENCODE_MODE
	            {
		            TEXT_ENCODE_NONE=-1,
		            TEXT_ENCODE_UNICODE=0,
		            TEXT_ENCODE_GB2312=1
	            };
             */
            if (sText == "UNICODE")
            {
                return 0;
            }
            else if (sText == "GB2312")
            {
                return 1;
            }
            return 0;
        }
        private uint ConvertToColor(string sText)
        {
            /*
             *  enum TEXT_COLOR_TYPE
	            {
		            TEXT_COLOR_NONE,
		            TEXT_COLOR_RED=1,
		            TEXT_COLOR_GREEN=2,
		            TEXT_COLOR_YELLOW=3,
		            TEXT_COLOR_BLUE=4,
		            TEXT_COLOR_PURPLE=5,
		            TEXT_COLOR_CYAN=6,
		            TEXT_COLOR_WHITE=7,
		            TEXT_COLOR_MAXVALUE
	            };
             */
            if (sText == "RED")
            {
                return 1;
            }
            else if (sText == "GREEN")
            {
                return 2;
            }
            else if (sText == "YELLOW")
            {
                return 3;
            }
            else if (sText == "BLUE")
            {
                return 4;
            }
            else if (sText == "PURPLE")
            {
                return 5;
            }
            else if (sText == "CYAN")
            {
                return 6;
            }
            else if (sText == "WHITE")
            {
                return 7;
            }
            return 1;
        }
        private void OnInitButtonClicked(object sender, EventArgs e)
        {
            if ((m_isReady == 0) && (ZHLED.LedAgent.Init() == 1))
            {
                this.button_init.Enabled = false;
                this.button_revInit.Enabled = true;
                m_isReady = 1;
                this.log.AppendText("初始化成功 \r\n");
            }
            else
            {
                this.log.AppendText("初始化失败 \r\n");
            }
        }
        private void OnDeInitButtonClicked(object sender, EventArgs e)
        {
            this.button_init.Enabled = true;
            this.button_revInit.Enabled = false;

            if (m_isReady != 0)
            {
                ZHLED.LedAgent.DeInit();
            }

            this.listView_devicelist.Items.Clear();
            m_isReady = 0;
            m_iCurrentDeviceId = 0;
        }
        private void OnAddDeviceButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0) return;

            string sDeviceIpAddr = this.textBox_ip.Text;
            string sDevicePort = this.textBox_port.Text;
            if (sDeviceIpAddr.Trim().Length == 0 || sDevicePort.Trim().Length == 0)
            {
                return;
            }

            int isFound = 0;
            for (int i = 0; i < this.listView_devicelist.Items.Count; i++)
            {
                string sIp = this.listView_devicelist.Items[i].SubItems[0].Text;
                string sPort = this.listView_devicelist.Items[i].SubItems[1].Text;

                if (sPort == sDevicePort && sIp == sDeviceIpAddr)
                {
                    isFound = 1;
                    break;
                }
            }
            if (isFound != 0) return;

            uint uDeviceId = ZHLED.LedAgent.RegisterDevice(sDeviceIpAddr,
                                                           uint.Parse(sDevicePort),
                                                           m_fCallback,
                                                           IntPtr.Zero);
            if (uDeviceId != 0)
            {
                m_iCurrentDeviceId = uDeviceId;

                ListViewItem item = new ListViewItem();
                item.Text = sDeviceIpAddr;
                item.SubItems.Add(sDevicePort);
                item.SubItems.Add("断开");
                item.SubItems.Add(Convert.ToString(uDeviceId));
                this.listView_devicelist.Items.Add(item);

                this.log.AppendText("添加设备 " + sDeviceIpAddr + " : " + sDevicePort + " 成功\r\n");
            }
        }
        private void OnDeleteDeviceButtonClicked(object sender, EventArgs e)
        {
            if (m_iCurrentDeviceId == 0 || m_isReady == 0) return;

            int isFound = 0;
	        for (int i = 0; i < this.listView_devicelist.Items.Count; i++)
	        {
		        if (uint.Parse(this.listView_devicelist.Items[i].SubItems[3].Text) == m_iCurrentDeviceId)
		        {
                    this.listView_devicelist.Items[i].Remove();
                    isFound = 1;
                    break;
		        }		
	        }

	        if (isFound != 0)
	        {
		        ZHLED.LedAgent.UnregisterDevice(m_iCurrentDeviceId);

		        this.textBox_ip.Text = "";
		        this.textBox_port.Text = "";
            }

	        m_iCurrentDeviceId = 0;
        }
        private void OnShowInstantTextButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            uint uEncodeType = ConvertToEncodeType(this.comboBox_instant_EncodingFormat.Text);
            uint uColor = ConvertToColor(this.comboBox_instant_color.Text);
            uint uField = uint.Parse(this.textBox_CharacterPartition.Text);

            //StringBuilder sText = 
            StringBuilder pText = new StringBuilder(this.textBox_instant.Text);
            if (ZHLED.LedAgent.ShowInstantText(m_iCurrentDeviceId, uEncodeType, uColor, pText, uField) != 0)
            {
                this.log.AppendText("显示即时文本 :" +"设备[" + m_iCurrentDeviceId + "]" + 
                                    " 文本["+ this.textBox_instant.Text + "]\r\n");
            }
        }
        private void OnHideInstantTextButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            uint uField = uint.Parse(this.textBox_CharacterPartition.Text);

            if (ZHLED.LedAgent.HideInstantText(m_iCurrentDeviceId, uField) != 0)
            {
                this.log.AppendText("隐藏即时文本 :" + "设备[" + m_iCurrentDeviceId + "]" + 
                                    " 分区[" +Convert.ToString(uField) + "]\r\n");
            }
        }
        private void OnUpdateTextButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            uint uTextIndex = uint.Parse(this.textBox_index.Text.Trim());
            uint uField = uint.Parse(this.textBox_CharacterPartition.Text.Trim());
            
            StringBuilder pText = new StringBuilder(this.textBox_store.Text);

            uint uEncodeType = ConvertToEncodeType(this.comboBox_store_EncodingFormat.Text);
            uint uColor = ConvertToColor(this.comboBox_store_color.Text);
            
	        if (ZHLED.LedAgent.UpdateDeviceText(m_iCurrentDeviceId, uTextIndex, uEncodeType, uColor, pText, uField) != 0)
	        {
                this.log.AppendText("更新分区文本 :" +"设备[" + m_iCurrentDeviceId + "]" + 
                                    " 分区[" + uField + "]" +
                                    " 文本[" + this.textBox_store.Text + "]\r\n");
	        }
        }
        private void OnDeleteTextButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            uint uTextIndex = uint.Parse(this.textBox_index.Text.Trim());
            uint uField = uint.Parse(this.textBox_CharacterPartition.Text.Trim());
            
	        if (ZHLED.LedAgent.DeleteDeviceText(m_iCurrentDeviceId, uTextIndex, uField) != 0)
	        {
                this.log.AppendText("删除分区文本 :" + "设备[" + m_iCurrentDeviceId + "]" + 
                                    "分区[" + uField + "]" +
                                    "文本序号[" + this.textBox_index.Text + "]\r\n");
	        }
        }
        private void OnPrevTextButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            uint uField = uint.Parse(this.textBox_CharacterPartition.Text.Trim());
	        if (ZHLED.LedAgent.SwitchDeviceText(m_iCurrentDeviceId, -2, uField) != 0)
	        {
                this.log.AppendText("切换分区上一个序号文本 :" + "设备[" + m_iCurrentDeviceId + "]" +
                                    "分区[" + uField + "]" + "]\r\n");
	        }
        }
        private void OnNextTextButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            uint uField = uint.Parse(this.textBox_CharacterPartition.Text.Trim());
            if (ZHLED.LedAgent.SwitchDeviceText(m_iCurrentDeviceId, -1, uField) != 0)
            {
                this.log.AppendText("切换分区下一个序号文本:" + " 设备[" + m_iCurrentDeviceId + "]" +
                                    " 分区[" + uField + "]\r\n");
            }
        }
        private void OnTextSwitchToButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

	        int uTextIndex = int.Parse(this.textBox_switch_to.Text.Trim());
	        uint uField = uint.Parse(this.textBox_CharacterPartition.Text.Trim());

	        if (ZHLED.LedAgent.SwitchDeviceText(m_iCurrentDeviceId, uTextIndex, uField) != 0)
	        {
                this.log.AppendText("切换分区到指定序号文本:" + " 设备[" + m_iCurrentDeviceId + "]" +
                                    " 分区[" + uField + "]" +
                                    " 文本序号[" + uTextIndex + "]\r\n");
	        }
        }
        private void OnAdjustScreenLightnessButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            uint uLightness = uint.Parse(this.textBox_lightness.Text.Trim());
            
	        if (ZHLED.LedAgent.SetDeviceLightness(m_iCurrentDeviceId, uLightness) != 0)
	        {
                this.log.AppendText("切换分区到指定序号文本:" + " 设备[" + m_iCurrentDeviceId + "]" +
                                    " 亮度[" + uLightness + "]\r\n");
	        }
        }
        private void OnOpenScreenButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            if (ZHLED.LedAgent.OpenDevice(m_iCurrentDeviceId) != 0)
	        {
                this.log.AppendText("打开屏幕:" + " 设备[" + m_iCurrentDeviceId + "]\r\n");
	        }
        }
        private void OnCloseScreenButtonClicked(object sender, EventArgs e)
        {
            if (m_isReady == 0 || m_iCurrentDeviceId == 0) return;

            if (ZHLED.LedAgent.CloseDevice(m_iCurrentDeviceId) != 0)
	        {
                this.log.AppendText("关闭屏幕:" + " 设备[" + m_iCurrentDeviceId + "]\r\n");
	        }
        }
        private void OnDialogClosed(object sender, EventArgs e)
        {
            OnDeInitButtonClicked(sender, e);
            this.Close();
        }
    }
}
