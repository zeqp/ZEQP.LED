namespace DeviceControllor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_devicelist = new System.Windows.Forms.GroupBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_devicelist = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_powerOff = new System.Windows.Forms.Button();
            this.button_open_screen = new System.Windows.Forms.Button();
            this.textBox_lightness = new System.Windows.Forms.TextBox();
            this.button_AdjustBrightnessTo = new System.Windows.Forms.Button();
            this.textBox_CharacterPartition = new System.Windows.Forms.TextBox();
            this.label_CharacterPartition = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.groupBox_TextSwitching = new System.Windows.Forms.GroupBox();
            this.textBox_switch_to = new System.Windows.Forms.TextBox();
            this.button_switch_to = new System.Windows.Forms.Button();
            this.button_switchtext_next = new System.Windows.Forms.Button();
            this.button_switchtext_prev = new System.Windows.Forms.Button();
            this.groupBox_Store = new System.Windows.Forms.GroupBox();
            this.button_store_delete = new System.Windows.Forms.Button();
            this.button_store_update = new System.Windows.Forms.Button();
            this.textBox_store = new System.Windows.Forms.TextBox();
            this.textBox_index = new System.Windows.Forms.TextBox();
            this.label_store_index = new System.Windows.Forms.Label();
            this.comboBox_store_color = new System.Windows.Forms.ComboBox();
            this.label_store_color = new System.Windows.Forms.Label();
            this.comboBox_store_EncodingFormat = new System.Windows.Forms.ComboBox();
            this.label_store_EncodingFormat = new System.Windows.Forms.Label();
            this.groupBox_Instant = new System.Windows.Forms.GroupBox();
            this.comboBox_instant_color = new System.Windows.Forms.ComboBox();
            this.comboBox_instant_EncodingFormat = new System.Windows.Forms.ComboBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_display = new System.Windows.Forms.Button();
            this.label_instant_color = new System.Windows.Forms.Label();
            this.label_instant_EncodingFormat = new System.Windows.Forms.Label();
            this.textBox_instant = new System.Windows.Forms.TextBox();
            this.groupBox_initialization = new System.Windows.Forms.GroupBox();
            this.button_revInit = new System.Windows.Forms.Button();
            this.button_init = new System.Windows.Forms.Button();
            this.textBox_deviceType = new System.Windows.Forms.TextBox();
            this.textBox_localPort = new System.Windows.Forms.TextBox();
            this.textBox_localAddress = new System.Windows.Forms.TextBox();
            this.label_devtype = new System.Windows.Forms.Label();
            this.label_localport = new System.Windows.Forms.Label();
            this.label_localaddress = new System.Windows.Forms.Label();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_Insert = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.RichTextBox();
            this.groupBox_devicelist.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_TextSwitching.SuspendLayout();
            this.groupBox_Store.SuspendLayout();
            this.groupBox_Instant.SuspendLayout();
            this.groupBox_initialization.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_devicelist
            // 
            this.groupBox_devicelist.Controls.Add(this.textBox_port);
            this.groupBox_devicelist.Controls.Add(this.label2);
            this.groupBox_devicelist.Controls.Add(this.textBox_ip);
            this.groupBox_devicelist.Controls.Add(this.label1);
            this.groupBox_devicelist.Controls.Add(this.listView_devicelist);
            this.groupBox_devicelist.Location = new System.Drawing.Point(3, 8);
            this.groupBox_devicelist.Name = "groupBox_devicelist";
            this.groupBox_devicelist.Size = new System.Drawing.Size(336, 405);
            this.groupBox_devicelist.TabIndex = 0;
            this.groupBox_devicelist.TabStop = false;
            this.groupBox_devicelist.Text = "设备列表";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(236, 371);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(93, 21);
            this.textBox_port.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口：";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(61, 371);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(137, 21);
            this.textBox_ip.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP地址：";
            // 
            // listView_devicelist
            // 
            this.listView_devicelist.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_devicelist.FullRowSelect = true;
            this.listView_devicelist.GridLines = true;
            this.listView_devicelist.Location = new System.Drawing.Point(6, 26);
            this.listView_devicelist.MultiSelect = false;
            this.listView_devicelist.Name = "listView_devicelist";
            this.listView_devicelist.Size = new System.Drawing.Size(324, 333);
            this.listView_devicelist.TabIndex = 1;
            this.listView_devicelist.UseCompatibleStateImageBehavior = false;
            this.listView_devicelist.View = System.Windows.Forms.View.Details;
            this.listView_devicelist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnDeviceListMouseClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_powerOff);
            this.panel1.Controls.Add(this.button_open_screen);
            this.panel1.Controls.Add(this.textBox_lightness);
            this.panel1.Controls.Add(this.button_AdjustBrightnessTo);
            this.panel1.Controls.Add(this.textBox_CharacterPartition);
            this.panel1.Controls.Add(this.label_CharacterPartition);
            this.panel1.Controls.Add(this.button_exit);
            this.panel1.Controls.Add(this.groupBox_TextSwitching);
            this.panel1.Controls.Add(this.groupBox_Store);
            this.panel1.Controls.Add(this.groupBox_Instant);
            this.panel1.Controls.Add(this.groupBox_initialization);
            this.panel1.Controls.Add(this.button_remove);
            this.panel1.Controls.Add(this.button_Insert);
            this.panel1.Controls.Add(this.groupBox_devicelist);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 453);
            this.panel1.TabIndex = 1;
            // 
            // button_powerOff
            // 
            this.button_powerOff.Location = new System.Drawing.Point(723, 390);
            this.button_powerOff.Name = "button_powerOff";
            this.button_powerOff.Size = new System.Drawing.Size(97, 23);
            this.button_powerOff.TabIndex = 29;
            this.button_powerOff.Text = "关闭屏幕";
            this.button_powerOff.UseVisualStyleBackColor = true;
            this.button_powerOff.Click += new System.EventHandler(this.OnCloseScreenButtonClicked);
            // 
            // button_open_screen
            // 
            this.button_open_screen.Location = new System.Drawing.Point(627, 390);
            this.button_open_screen.Name = "button_open_screen";
            this.button_open_screen.Size = new System.Drawing.Size(89, 23);
            this.button_open_screen.TabIndex = 28;
            this.button_open_screen.Text = "打开屏幕";
            this.button_open_screen.UseVisualStyleBackColor = true;
            this.button_open_screen.Click += new System.EventHandler(this.OnOpenScreenButtonClicked);
            // 
            // textBox_lightness
            // 
            this.textBox_lightness.Location = new System.Drawing.Point(476, 392);
            this.textBox_lightness.Name = "textBox_lightness";
            this.textBox_lightness.Size = new System.Drawing.Size(146, 21);
            this.textBox_lightness.TabIndex = 27;
            this.textBox_lightness.Text = "100";
            // 
            // button_AdjustBrightnessTo
            // 
            this.button_AdjustBrightnessTo.Location = new System.Drawing.Point(358, 390);
            this.button_AdjustBrightnessTo.Name = "button_AdjustBrightnessTo";
            this.button_AdjustBrightnessTo.Size = new System.Drawing.Size(110, 23);
            this.button_AdjustBrightnessTo.TabIndex = 10;
            this.button_AdjustBrightnessTo.Text = "调整亮度";
            this.button_AdjustBrightnessTo.UseVisualStyleBackColor = true;
            this.button_AdjustBrightnessTo.Click += new System.EventHandler(this.OnAdjustScreenLightnessButtonClicked);
            // 
            // textBox_CharacterPartition
            // 
            this.textBox_CharacterPartition.Location = new System.Drawing.Point(432, 110);
            this.textBox_CharacterPartition.Name = "textBox_CharacterPartition";
            this.textBox_CharacterPartition.Size = new System.Drawing.Size(382, 21);
            this.textBox_CharacterPartition.TabIndex = 9;
            this.textBox_CharacterPartition.Text = "0";
            // 
            // label_CharacterPartition
            // 
            this.label_CharacterPartition.AutoSize = true;
            this.label_CharacterPartition.Location = new System.Drawing.Point(352, 110);
            this.label_CharacterPartition.Name = "label_CharacterPartition";
            this.label_CharacterPartition.Size = new System.Drawing.Size(65, 12);
            this.label_CharacterPartition.TabIndex = 8;
            this.label_CharacterPartition.Text = "字符分区：";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(723, 422);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(98, 23);
            this.button_exit.TabIndex = 7;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.OnDialogClosed);
            // 
            // groupBox_TextSwitching
            // 
            this.groupBox_TextSwitching.Controls.Add(this.textBox_switch_to);
            this.groupBox_TextSwitching.Controls.Add(this.button_switch_to);
            this.groupBox_TextSwitching.Controls.Add(this.button_switchtext_next);
            this.groupBox_TextSwitching.Controls.Add(this.button_switchtext_prev);
            this.groupBox_TextSwitching.Location = new System.Drawing.Point(347, 332);
            this.groupBox_TextSwitching.Name = "groupBox_TextSwitching";
            this.groupBox_TextSwitching.Size = new System.Drawing.Size(473, 42);
            this.groupBox_TextSwitching.TabIndex = 6;
            this.groupBox_TextSwitching.TabStop = false;
            this.groupBox_TextSwitching.Text = "文本切换";
            // 
            // textBox_switch_to
            // 
            this.textBox_switch_to.Location = new System.Drawing.Point(375, 14);
            this.textBox_switch_to.Name = "textBox_switch_to";
            this.textBox_switch_to.Size = new System.Drawing.Size(98, 21);
            this.textBox_switch_to.TabIndex = 26;
            this.textBox_switch_to.Text = "0";
            // 
            // button_switch_to
            // 
            this.button_switch_to.Location = new System.Drawing.Point(278, 14);
            this.button_switch_to.Name = "button_switch_to";
            this.button_switch_to.Size = new System.Drawing.Size(91, 23);
            this.button_switch_to.TabIndex = 25;
            this.button_switch_to.Text = "切换到";
            this.button_switch_to.UseVisualStyleBackColor = true;
            this.button_switch_to.Click += new System.EventHandler(this.OnTextSwitchToButtonClicked);
            // 
            // button_switchtext_next
            // 
            this.button_switchtext_next.Location = new System.Drawing.Point(145, 14);
            this.button_switchtext_next.Name = "button_switchtext_next";
            this.button_switchtext_next.Size = new System.Drawing.Size(129, 23);
            this.button_switchtext_next.TabIndex = 24;
            this.button_switchtext_next.Text = "下一个";
            this.button_switchtext_next.UseVisualStyleBackColor = true;
            this.button_switchtext_next.Click += new System.EventHandler(this.OnNextTextButtonClicked);
            // 
            // button_switchtext_prev
            // 
            this.button_switchtext_prev.Location = new System.Drawing.Point(11, 14);
            this.button_switchtext_prev.Name = "button_switchtext_prev";
            this.button_switchtext_prev.Size = new System.Drawing.Size(129, 23);
            this.button_switchtext_prev.TabIndex = 0;
            this.button_switchtext_prev.Text = "上一个";
            this.button_switchtext_prev.UseVisualStyleBackColor = true;
            this.button_switchtext_prev.Click += new System.EventHandler(this.OnPrevTextButtonClicked);
            // 
            // groupBox_Store
            // 
            this.groupBox_Store.Controls.Add(this.button_store_delete);
            this.groupBox_Store.Controls.Add(this.button_store_update);
            this.groupBox_Store.Controls.Add(this.textBox_store);
            this.groupBox_Store.Controls.Add(this.textBox_index);
            this.groupBox_Store.Controls.Add(this.label_store_index);
            this.groupBox_Store.Controls.Add(this.comboBox_store_color);
            this.groupBox_Store.Controls.Add(this.label_store_color);
            this.groupBox_Store.Controls.Add(this.comboBox_store_EncodingFormat);
            this.groupBox_Store.Controls.Add(this.label_store_EncodingFormat);
            this.groupBox_Store.Location = new System.Drawing.Point(347, 219);
            this.groupBox_Store.Name = "groupBox_Store";
            this.groupBox_Store.Size = new System.Drawing.Size(474, 107);
            this.groupBox_Store.TabIndex = 5;
            this.groupBox_Store.TabStop = false;
            this.groupBox_Store.Text = "存储文本";
            // 
            // button_store_delete
            // 
            this.button_store_delete.Location = new System.Drawing.Point(410, 78);
            this.button_store_delete.Name = "button_store_delete";
            this.button_store_delete.Size = new System.Drawing.Size(63, 23);
            this.button_store_delete.TabIndex = 24;
            this.button_store_delete.Text = "删除";
            this.button_store_delete.UseVisualStyleBackColor = true;
            this.button_store_delete.Click += new System.EventHandler(this.OnDeleteTextButtonClicked);
            // 
            // button_store_update
            // 
            this.button_store_update.Location = new System.Drawing.Point(410, 45);
            this.button_store_update.Name = "button_store_update";
            this.button_store_update.Size = new System.Drawing.Size(63, 23);
            this.button_store_update.TabIndex = 23;
            this.button_store_update.Text = "更新";
            this.button_store_update.UseVisualStyleBackColor = true;
            this.button_store_update.Click += new System.EventHandler(this.OnUpdateTextButtonClicked);
            // 
            // textBox_store
            // 
            this.textBox_store.Location = new System.Drawing.Point(7, 45);
            this.textBox_store.Name = "textBox_store";
            this.textBox_store.Size = new System.Drawing.Size(394, 21);
            this.textBox_store.TabIndex = 22;
            // 
            // textBox_index
            // 
            this.textBox_index.Location = new System.Drawing.Point(51, 18);
            this.textBox_index.Name = "textBox_index";
            this.textBox_index.Size = new System.Drawing.Size(70, 21);
            this.textBox_index.TabIndex = 21;
            this.textBox_index.Text = "0";
            // 
            // label_store_index
            // 
            this.label_store_index.AutoSize = true;
            this.label_store_index.Location = new System.Drawing.Point(9, 21);
            this.label_store_index.Name = "label_store_index";
            this.label_store_index.Size = new System.Drawing.Size(41, 12);
            this.label_store_index.TabIndex = 19;
            this.label_store_index.Text = "索引：";
            // 
            // comboBox_store_color
            // 
            this.comboBox_store_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_store_color.FormattingEnabled = true;
            this.comboBox_store_color.Location = new System.Drawing.Point(375, 18);
            this.comboBox_store_color.Name = "comboBox_store_color";
            this.comboBox_store_color.Size = new System.Drawing.Size(98, 20);
            this.comboBox_store_color.TabIndex = 18;
            // 
            // label_store_color
            // 
            this.label_store_color.AutoSize = true;
            this.label_store_color.Location = new System.Drawing.Point(331, 21);
            this.label_store_color.Name = "label_store_color";
            this.label_store_color.Size = new System.Drawing.Size(41, 12);
            this.label_store_color.TabIndex = 17;
            this.label_store_color.Text = "颜色：";
            // 
            // comboBox_store_EncodingFormat
            // 
            this.comboBox_store_EncodingFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_store_EncodingFormat.FormattingEnabled = true;
            this.comboBox_store_EncodingFormat.Location = new System.Drawing.Point(184, 18);
            this.comboBox_store_EncodingFormat.Name = "comboBox_store_EncodingFormat";
            this.comboBox_store_EncodingFormat.Size = new System.Drawing.Size(140, 20);
            this.comboBox_store_EncodingFormat.TabIndex = 16;
            // 
            // label_store_EncodingFormat
            // 
            this.label_store_EncodingFormat.AutoSize = true;
            this.label_store_EncodingFormat.Location = new System.Drawing.Point(126, 21);
            this.label_store_EncodingFormat.Name = "label_store_EncodingFormat";
            this.label_store_EncodingFormat.Size = new System.Drawing.Size(65, 12);
            this.label_store_EncodingFormat.TabIndex = 12;
            this.label_store_EncodingFormat.Text = "编码格式：";
            // 
            // groupBox_Instant
            // 
            this.groupBox_Instant.Controls.Add(this.comboBox_instant_color);
            this.groupBox_Instant.Controls.Add(this.comboBox_instant_EncodingFormat);
            this.groupBox_Instant.Controls.Add(this.button_delete);
            this.groupBox_Instant.Controls.Add(this.button_display);
            this.groupBox_Instant.Controls.Add(this.label_instant_color);
            this.groupBox_Instant.Controls.Add(this.label_instant_EncodingFormat);
            this.groupBox_Instant.Controls.Add(this.textBox_instant);
            this.groupBox_Instant.Location = new System.Drawing.Point(346, 135);
            this.groupBox_Instant.Name = "groupBox_Instant";
            this.groupBox_Instant.Size = new System.Drawing.Size(475, 78);
            this.groupBox_Instant.TabIndex = 4;
            this.groupBox_Instant.TabStop = false;
            this.groupBox_Instant.Text = "即时文本";
            // 
            // comboBox_instant_color
            // 
            this.comboBox_instant_color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_instant_color.FormattingEnabled = true;
            this.comboBox_instant_color.Location = new System.Drawing.Point(281, 50);
            this.comboBox_instant_color.Name = "comboBox_instant_color";
            this.comboBox_instant_color.Size = new System.Drawing.Size(121, 20);
            this.comboBox_instant_color.TabIndex = 16;
            // 
            // comboBox_instant_EncodingFormat
            // 
            this.comboBox_instant_EncodingFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_instant_EncodingFormat.FormattingEnabled = true;
            this.comboBox_instant_EncodingFormat.Location = new System.Drawing.Point(86, 50);
            this.comboBox_instant_EncodingFormat.Name = "comboBox_instant_EncodingFormat";
            this.comboBox_instant_EncodingFormat.Size = new System.Drawing.Size(141, 20);
            this.comboBox_instant_EncodingFormat.TabIndex = 15;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(410, 50);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(63, 23);
            this.button_delete.TabIndex = 14;
            this.button_delete.Text = "隐藏";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.OnHideInstantTextButtonClicked);
            // 
            // button_display
            // 
            this.button_display.Location = new System.Drawing.Point(410, 20);
            this.button_display.Name = "button_display";
            this.button_display.Size = new System.Drawing.Size(63, 23);
            this.button_display.TabIndex = 13;
            this.button_display.Text = "显示";
            this.button_display.UseVisualStyleBackColor = true;
            this.button_display.Click += new System.EventHandler(this.OnShowInstantTextButtonClicked);
            // 
            // label_instant_color
            // 
            this.label_instant_color.AutoSize = true;
            this.label_instant_color.Location = new System.Drawing.Point(234, 54);
            this.label_instant_color.Name = "label_instant_color";
            this.label_instant_color.Size = new System.Drawing.Size(41, 12);
            this.label_instant_color.TabIndex = 12;
            this.label_instant_color.Text = "颜色：";
            // 
            // label_instant_EncodingFormat
            // 
            this.label_instant_EncodingFormat.AutoSize = true;
            this.label_instant_EncodingFormat.Location = new System.Drawing.Point(7, 54);
            this.label_instant_EncodingFormat.Name = "label_instant_EncodingFormat";
            this.label_instant_EncodingFormat.Size = new System.Drawing.Size(59, 12);
            this.label_instant_EncodingFormat.TabIndex = 11;
            this.label_instant_EncodingFormat.Text = "编码格式:";
            // 
            // textBox_instant
            // 
            this.textBox_instant.Location = new System.Drawing.Point(6, 20);
            this.textBox_instant.Name = "textBox_instant";
            this.textBox_instant.Size = new System.Drawing.Size(396, 21);
            this.textBox_instant.TabIndex = 10;
            // 
            // groupBox_initialization
            // 
            this.groupBox_initialization.Controls.Add(this.button_revInit);
            this.groupBox_initialization.Controls.Add(this.button_init);
            this.groupBox_initialization.Controls.Add(this.textBox_deviceType);
            this.groupBox_initialization.Controls.Add(this.textBox_localPort);
            this.groupBox_initialization.Controls.Add(this.textBox_localAddress);
            this.groupBox_initialization.Controls.Add(this.label_devtype);
            this.groupBox_initialization.Controls.Add(this.label_localport);
            this.groupBox_initialization.Controls.Add(this.label_localaddress);
            this.groupBox_initialization.Location = new System.Drawing.Point(346, 9);
            this.groupBox_initialization.Name = "groupBox_initialization";
            this.groupBox_initialization.Size = new System.Drawing.Size(474, 88);
            this.groupBox_initialization.TabIndex = 3;
            this.groupBox_initialization.TabStop = false;
            this.groupBox_initialization.Text = "初始化";
            // 
            // button_revInit
            // 
            this.button_revInit.Location = new System.Drawing.Point(343, 57);
            this.button_revInit.Name = "button_revInit";
            this.button_revInit.Size = new System.Drawing.Size(126, 23);
            this.button_revInit.TabIndex = 7;
            this.button_revInit.Text = "反初始化";
            this.button_revInit.UseVisualStyleBackColor = true;
            this.button_revInit.Click += new System.EventHandler(this.OnDeInitButtonClicked);
            // 
            // button_init
            // 
            this.button_init.Location = new System.Drawing.Point(343, 22);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(125, 23);
            this.button_init.TabIndex = 6;
            this.button_init.Text = "初始化";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.OnInitButtonClicked);
            // 
            // textBox_deviceType
            // 
            this.textBox_deviceType.Enabled = false;
            this.textBox_deviceType.Location = new System.Drawing.Point(86, 57);
            this.textBox_deviceType.Name = "textBox_deviceType";
            this.textBox_deviceType.Size = new System.Drawing.Size(92, 21);
            this.textBox_deviceType.TabIndex = 5;
            // 
            // textBox_localPort
            // 
            this.textBox_localPort.Enabled = false;
            this.textBox_localPort.Location = new System.Drawing.Point(244, 25);
            this.textBox_localPort.Name = "textBox_localPort";
            this.textBox_localPort.Size = new System.Drawing.Size(92, 21);
            this.textBox_localPort.TabIndex = 4;
            // 
            // textBox_localAddress
            // 
            this.textBox_localAddress.Enabled = false;
            this.textBox_localAddress.Location = new System.Drawing.Point(86, 25);
            this.textBox_localAddress.Name = "textBox_localAddress";
            this.textBox_localAddress.Size = new System.Drawing.Size(92, 21);
            this.textBox_localAddress.TabIndex = 3;
            // 
            // label_devtype
            // 
            this.label_devtype.AutoSize = true;
            this.label_devtype.Location = new System.Drawing.Point(7, 60);
            this.label_devtype.Name = "label_devtype";
            this.label_devtype.Size = new System.Drawing.Size(65, 12);
            this.label_devtype.TabIndex = 2;
            this.label_devtype.Text = "设备类型：";
            // 
            // label_localport
            // 
            this.label_localport.AutoSize = true;
            this.label_localport.Location = new System.Drawing.Point(184, 28);
            this.label_localport.Name = "label_localport";
            this.label_localport.Size = new System.Drawing.Size(65, 12);
            this.label_localport.TabIndex = 1;
            this.label_localport.Text = "本地端口：";
            // 
            // label_localaddress
            // 
            this.label_localaddress.AutoSize = true;
            this.label_localaddress.Location = new System.Drawing.Point(6, 28);
            this.label_localaddress.Name = "label_localaddress";
            this.label_localaddress.Size = new System.Drawing.Size(65, 12);
            this.label_localaddress.TabIndex = 0;
            this.label_localaddress.Text = "本地地址：";
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(258, 422);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(75, 23);
            this.button_remove.TabIndex = 2;
            this.button_remove.Text = "删除";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.OnDeleteDeviceButtonClicked);
            // 
            // button_Insert
            // 
            this.button_Insert.Location = new System.Drawing.Point(144, 422);
            this.button_Insert.Name = "button_Insert";
            this.button_Insert.Size = new System.Drawing.Size(75, 23);
            this.button_Insert.TabIndex = 1;
            this.button_Insert.Text = "添加";
            this.button_Insert.UseVisualStyleBackColor = true;
            this.button_Insert.Click += new System.EventHandler(this.OnAddDeviceButtonClicked);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(3, 462);
            this.log.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(824, 106);
            this.log.TabIndex = 2;
            this.log.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 577);
            this.Controls.Add(this.log);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "demo";
            this.groupBox_devicelist.ResumeLayout(false);
            this.groupBox_devicelist.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_TextSwitching.ResumeLayout(false);
            this.groupBox_TextSwitching.PerformLayout();
            this.groupBox_Store.ResumeLayout(false);
            this.groupBox_Store.PerformLayout();
            this.groupBox_Instant.ResumeLayout(false);
            this.groupBox_Instant.PerformLayout();
            this.groupBox_initialization.ResumeLayout(false);
            this.groupBox_initialization.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_devicelist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_devicelist;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_Insert;
        private System.Windows.Forms.GroupBox groupBox_initialization;
        private System.Windows.Forms.GroupBox groupBox_TextSwitching;
        private System.Windows.Forms.GroupBox groupBox_Store;
        private System.Windows.Forms.GroupBox groupBox_Instant;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_revInit;
        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.TextBox textBox_deviceType;
        private System.Windows.Forms.TextBox textBox_localPort;
        private System.Windows.Forms.TextBox textBox_localAddress;
        private System.Windows.Forms.Label label_devtype;
        private System.Windows.Forms.Label label_localport;
        private System.Windows.Forms.Label label_localaddress;
        private System.Windows.Forms.TextBox textBox_CharacterPartition;
        private System.Windows.Forms.Label label_CharacterPartition;
        private System.Windows.Forms.ComboBox comboBox_instant_color;
        private System.Windows.Forms.ComboBox comboBox_instant_EncodingFormat;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_display;
        private System.Windows.Forms.Label label_instant_color;
        private System.Windows.Forms.Label label_instant_EncodingFormat;
        private System.Windows.Forms.TextBox textBox_instant;
        private System.Windows.Forms.ComboBox comboBox_store_color;
        private System.Windows.Forms.Label label_store_color;
        private System.Windows.Forms.ComboBox comboBox_store_EncodingFormat;
        private System.Windows.Forms.Label label_store_EncodingFormat;
        private System.Windows.Forms.TextBox textBox_index;
        private System.Windows.Forms.Label label_store_index;
        private System.Windows.Forms.Button button_store_delete;
        private System.Windows.Forms.Button button_store_update;
        private System.Windows.Forms.TextBox textBox_store;
        private System.Windows.Forms.TextBox textBox_switch_to;
        private System.Windows.Forms.Button button_switch_to;
        private System.Windows.Forms.Button button_switchtext_next;
        private System.Windows.Forms.Button button_switchtext_prev;
        private System.Windows.Forms.Button button_powerOff;
        private System.Windows.Forms.Button button_open_screen;
        private System.Windows.Forms.TextBox textBox_lightness;
        private System.Windows.Forms.Button button_AdjustBrightnessTo;
        private System.Windows.Forms.RichTextBox log;
    }
}

