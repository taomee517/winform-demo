using System;

namespace Windows
{
    partial class Gateway
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gatewayNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.batteryCheckBox = new System.Windows.Forms.CheckBox();
            this.voltageCheckBox = new System.Windows.Forms.CheckBox();
            this.signalCheckBox = new System.Windows.Forms.CheckBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.intervalSelect = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.scheduledBox = new System.Windows.Forms.CheckBox();
            this.msgBox = new System.Windows.Forms.RichTextBox();
            this.messageBuffer = new System.Windows.Forms.RichTextBox();
            this.send = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.socketStatus = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.signalBox = new System.Windows.Forms.TextBox();
            this.tempBox = new System.Windows.Forms.TextBox();
            this.voltageBox = new System.Windows.Forms.TextBox();
            this.batteryBox = new System.Windows.Forms.TextBox();
            this.pwdBox = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.tempCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.netframeUpDown = new System.Windows.Forms.DomainUpDown();
            this.allRemoveBtn = new System.Windows.Forms.Button();
            this.allSelectBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buildRandomData = new System.Windows.Forms.Button();
            this.swingRBox = new System.Windows.Forms.TextBox();
            this.baseRBox = new System.Windows.Forms.TextBox();
            this.channelSize = new System.Windows.Forms.NumericUpDown();
            this.label66 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.swingFBox = new System.Windows.Forms.TextBox();
            this.baseFBox = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.selectChannelsBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button7 = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.buildStatusMsg = new System.Windows.Forms.Button();
            this.buildDataMsg = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.cacheOrder = new System.Windows.Forms.Button();
            this.logClear = new System.Windows.Forms.Button();
            this.errorMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.intervalSelect)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gatewayNo
            // 
            this.gatewayNo.Location = new System.Drawing.Point(80, 22);
            this.gatewayNo.Name = "gatewayNo";
            this.gatewayNo.Size = new System.Drawing.Size(120, 21);
            this.gatewayNo.TabIndex = 0;
            this.gatewayNo.Text = "4854000000000001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "网关编号";
            // 
            // batteryCheckBox
            // 
            this.batteryCheckBox.AutoSize = true;
            this.batteryCheckBox.Location = new System.Drawing.Point(13, 55);
            this.batteryCheckBox.Name = "batteryCheckBox";
            this.batteryCheckBox.Size = new System.Drawing.Size(48, 16);
            this.batteryCheckBox.TabIndex = 4;
            this.batteryCheckBox.Text = "电量";
            this.batteryCheckBox.UseVisualStyleBackColor = true;
            // 
            // voltageCheckBox
            // 
            this.voltageCheckBox.AutoSize = true;
            this.voltageCheckBox.Checked = true;
            this.voltageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.voltageCheckBox.Location = new System.Drawing.Point(214, 55);
            this.voltageCheckBox.Name = "voltageCheckBox";
            this.voltageCheckBox.Size = new System.Drawing.Size(48, 16);
            this.voltageCheckBox.TabIndex = 6;
            this.voltageCheckBox.Text = "电压";
            this.voltageCheckBox.UseVisualStyleBackColor = true;
            // 
            // signalCheckBox
            // 
            this.signalCheckBox.AutoSize = true;
            this.signalCheckBox.Checked = true;
            this.signalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.signalCheckBox.Location = new System.Drawing.Point(214, 86);
            this.signalCheckBox.Name = "signalCheckBox";
            this.signalCheckBox.Size = new System.Drawing.Size(48, 16);
            this.signalCheckBox.TabIndex = 6;
            this.signalCheckBox.Text = "信号";
            this.signalCheckBox.UseVisualStyleBackColor = true;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Items.Add("TCP");
            this.domainUpDown1.Items.Add("UDP");
            this.domainUpDown1.Items.Add("MQTT");
            this.domainUpDown1.Items.Add("HTTP");
            this.domainUpDown1.Items.Add("MODBUS");
            this.domainUpDown1.Location = new System.Drawing.Point(80, 26);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(120, 21);
            this.domainUpDown1.TabIndex = 7;
            this.domainUpDown1.Text = "TCP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "通信协议";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "域名/IP";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(80, 56);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(120, 21);
            this.ip.TabIndex = 9;
            this.ip.Text = "127.0.0.1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 16);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.Text = "ASCII";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(134, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(41, 16);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "HEX";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // intervalSelect
            // 
            this.intervalSelect.Location = new System.Drawing.Point(102, 54);
            this.intervalSelect.Maximum = new decimal(new int[] {
            1800000,
            0,
            0,
            0});
            this.intervalSelect.Name = "intervalSelect";
            this.intervalSelect.Size = new System.Drawing.Size(88, 21);
            this.intervalSelect.TabIndex = 13;
            this.intervalSelect.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.intervalSelect.ValueChanged += new System.EventHandler(this.channelSize_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "ms";
            // 
            // scheduledBox
            // 
            this.scheduledBox.AutoSize = true;
            this.scheduledBox.Location = new System.Drawing.Point(14, 55);
            this.scheduledBox.Name = "scheduledBox";
            this.scheduledBox.Size = new System.Drawing.Size(72, 16);
            this.scheduledBox.TabIndex = 15;
            this.scheduledBox.Text = "定时发送";
            this.scheduledBox.UseVisualStyleBackColor = true;
            // 
            // msgBox
            // 
            this.msgBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.msgBox.Location = new System.Drawing.Point(456, 66);
            this.msgBox.Name = "msgBox";
            this.msgBox.ReadOnly = true;
            this.msgBox.Size = new System.Drawing.Size(693, 507);
            this.msgBox.TabIndex = 16;
            this.msgBox.Text = "";
            // 
            // messageBuffer
            // 
            this.messageBuffer.Location = new System.Drawing.Point(456, 602);
            this.messageBuffer.Name = "messageBuffer";
            this.messageBuffer.Size = new System.Drawing.Size(601, 80);
            this.messageBuffer.TabIndex = 17;
            this.messageBuffer.Text = "";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(1063, 602);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(86, 80);
            this.send.TabIndex = 18;
            this.send.Text = "发送";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(80, 85);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(120, 21);
            this.port.TabIndex = 9;
            this.port.Text = "21703";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "目标端口";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.socketStatus);
            this.groupBox1.Controls.Add(this.label67);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.domainUpDown1);
            this.groupBox1.Controls.Add(this.ip);
            this.groupBox1.Controls.Add(this.port);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(33, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 145);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络配置";
            // 
            // socketStatus
            // 
            this.socketStatus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.socketStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.socketStatus.ForeColor = System.Drawing.Color.Red;
            this.socketStatus.Location = new System.Drawing.Point(80, 116);
            this.socketStatus.Name = "socketStatus";
            this.socketStatus.Size = new System.Drawing.Size(120, 14);
            this.socketStatus.TabIndex = 11;
            this.socketStatus.Text = "连接断开";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(7, 116);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(53, 12);
            this.label67.TabIndex = 12;
            this.label67.Text = "连接状态";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.signalBox);
            this.groupBox2.Controls.Add(this.tempBox);
            this.groupBox2.Controls.Add(this.voltageBox);
            this.groupBox2.Controls.Add(this.batteryBox);
            this.groupBox2.Controls.Add(this.pwdBox);
            this.groupBox2.Controls.Add(this.label68);
            this.groupBox2.Controls.Add(this.gatewayNo);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tempCheckBox);
            this.groupBox2.Controls.Add(this.batteryCheckBox);
            this.groupBox2.Controls.Add(this.voltageCheckBox);
            this.groupBox2.Controls.Add(this.signalCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(33, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 114);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网关配置";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(367, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 42;
            this.label15.Text = "dBm";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(166, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 42;
            this.label16.Text = "%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(166, 90);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 42;
            this.label17.Text = "℃";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(367, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "V";
            // 
            // signalBox
            // 
            this.signalBox.Location = new System.Drawing.Point(281, 81);
            this.signalBox.Name = "signalBox";
            this.signalBox.Size = new System.Drawing.Size(79, 21);
            this.signalBox.TabIndex = 7;
            this.signalBox.Text = "-65";
            // 
            // tempBox
            // 
            this.tempBox.Location = new System.Drawing.Point(80, 81);
            this.tempBox.Name = "tempBox";
            this.tempBox.Size = new System.Drawing.Size(79, 21);
            this.tempBox.TabIndex = 7;
            this.tempBox.Text = "25";
            // 
            // voltageBox
            // 
            this.voltageBox.Location = new System.Drawing.Point(281, 50);
            this.voltageBox.Name = "voltageBox";
            this.voltageBox.Size = new System.Drawing.Size(79, 21);
            this.voltageBox.TabIndex = 7;
            this.voltageBox.Text = "13";
            // 
            // batteryBox
            // 
            this.batteryBox.Location = new System.Drawing.Point(80, 50);
            this.batteryBox.Name = "batteryBox";
            this.batteryBox.Size = new System.Drawing.Size(79, 21);
            this.batteryBox.TabIndex = 7;
            this.batteryBox.Text = "90";
            // 
            // pwdBox
            // 
            this.pwdBox.BackColor = System.Drawing.SystemColors.Menu;
            this.pwdBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pwdBox.Location = new System.Drawing.Point(281, 25);
            this.pwdBox.Name = "pwdBox";
            this.pwdBox.Size = new System.Drawing.Size(120, 14);
            this.pwdBox.TabIndex = 0;
            this.pwdBox.Text = "空";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(218, 26);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(53, 12);
            this.label68.TabIndex = 2;
            this.label68.Text = "登录口令";
            // 
            // tempCheckBox
            // 
            this.tempCheckBox.AutoSize = true;
            this.tempCheckBox.Location = new System.Drawing.Point(13, 86);
            this.tempCheckBox.Name = "tempCheckBox";
            this.tempCheckBox.Size = new System.Drawing.Size(48, 16);
            this.tempCheckBox.TabIndex = 6;
            this.tempCheckBox.Text = "温度";
            this.tempCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.netframeUpDown);
            this.groupBox4.Controls.Add(this.allRemoveBtn);
            this.groupBox4.Controls.Add(this.allSelectBtn);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.buildRandomData);
            this.groupBox4.Controls.Add(this.swingRBox);
            this.groupBox4.Controls.Add(this.baseRBox);
            this.groupBox4.Controls.Add(this.channelSize);
            this.groupBox4.Controls.Add(this.label66);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label65);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label64);
            this.groupBox4.Controls.Add(this.label49);
            this.groupBox4.Controls.Add(this.label63);
            this.groupBox4.Controls.Add(this.label50);
            this.groupBox4.Controls.Add(this.label62);
            this.groupBox4.Controls.Add(this.label51);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label61);
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.swingFBox);
            this.groupBox4.Controls.Add(this.baseFBox);
            this.groupBox4.Controls.Add(this.textBox23);
            this.groupBox4.Controls.Add(this.textBox22);
            this.groupBox4.Controls.Add(this.label60);
            this.groupBox4.Controls.Add(this.label53);
            this.groupBox4.Controls.Add(this.label59);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Controls.Add(this.label58);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.label57);
            this.groupBox4.Controls.Add(this.label56);
            this.groupBox4.Controls.Add(this.textBox16);
            this.groupBox4.Controls.Add(this.textBox25);
            this.groupBox4.Controls.Add(this.selectChannelsBox);
            this.groupBox4.Location = new System.Drawing.Point(33, 345);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(406, 228);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "通道配置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(199, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 47;
            this.label9.Text = "拓扑模式";
            // 
            // netframeUpDown
            // 
            this.netframeUpDown.Items.Add("点对点模式");
            this.netframeUpDown.Items.Add("总线模式");
            this.netframeUpDown.Items.Add("全解析数据");
            this.netframeUpDown.Items.Add("半透传数据");
            this.netframeUpDown.Items.Add("全透传数据");
            this.netframeUpDown.Location = new System.Drawing.Point(272, 20);
            this.netframeUpDown.Name = "netframeUpDown";
            this.netframeUpDown.Size = new System.Drawing.Size(120, 21);
            this.netframeUpDown.TabIndex = 46;
            this.netframeUpDown.Text = "点对点模式";
            // 
            // allRemoveBtn
            // 
            this.allRemoveBtn.Location = new System.Drawing.Point(102, 190);
            this.allRemoveBtn.Name = "allRemoveBtn";
            this.allRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.allRemoveBtn.TabIndex = 45;
            this.allRemoveBtn.Text = "反选";
            this.allRemoveBtn.UseVisualStyleBackColor = true;
            this.allRemoveBtn.Click += new System.EventHandler(this.allChannelRemove);
            // 
            // allSelectBtn
            // 
            this.allSelectBtn.Location = new System.Drawing.Point(13, 190);
            this.allSelectBtn.Name = "allSelectBtn";
            this.allSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.allSelectBtn.TabIndex = 45;
            this.allSelectBtn.Text = "全选";
            this.allSelectBtn.UseVisualStyleBackColor = true;
            this.allSelectBtn.Click += new System.EventHandler(this.allChannelSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "数据编辑";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.channelDataEdit_Click);
            // 
            // buildRandomData
            // 
            this.buildRandomData.Location = new System.Drawing.Point(193, 190);
            this.buildRandomData.Name = "buildRandomData";
            this.buildRandomData.Size = new System.Drawing.Size(95, 23);
            this.buildRandomData.TabIndex = 43;
            this.buildRandomData.Text = "随机数据";
            this.buildRandomData.UseVisualStyleBackColor = true;
            this.buildRandomData.Click += new System.EventHandler(this.buildRandomData_Click);
            // 
            // swingRBox
            // 
            this.swingRBox.Location = new System.Drawing.Point(270, 162);
            this.swingRBox.Name = "swingRBox";
            this.swingRBox.Size = new System.Drawing.Size(100, 21);
            this.swingRBox.TabIndex = 33;
            this.swingRBox.Text = "50";
            // 
            // baseRBox
            // 
            this.baseRBox.Location = new System.Drawing.Point(270, 136);
            this.baseRBox.Name = "baseRBox";
            this.baseRBox.Size = new System.Drawing.Size(100, 21);
            this.baseRBox.TabIndex = 33;
            this.baseRBox.Text = "3500";
            // 
            // channelSize
            // 
            this.channelSize.Location = new System.Drawing.Point(87, 22);
            this.channelSize.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.channelSize.Name = "channelSize";
            this.channelSize.Size = new System.Drawing.Size(100, 21);
            this.channelSize.TabIndex = 1;
            this.channelSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.channelSize.ValueChanged += new System.EventHandler(this.channelSize_ValueChanged);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(10, 168);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(29, 12);
            this.label66.TabIndex = 27;
            this.label66.Text = "幅度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "基数";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(57, 168);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(29, 12);
            this.label65.TabIndex = 29;
            this.label65.Text = "频率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "频率";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(10, 168);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(35, 12);
            this.label64.TabIndex = 28;
            this.label64.Text = "通道1";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(10, 142);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(35, 12);
            this.label49.TabIndex = 28;
            this.label49.Text = "通道1";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(57, 168);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(29, 12);
            this.label63.TabIndex = 30;
            this.label63.Text = "频率";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(57, 142);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(29, 12);
            this.label50.TabIndex = 30;
            this.label50.Text = "频率";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(375, 169);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(17, 12);
            this.label62.TabIndex = 39;
            this.label62.Text = "Ω";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(375, 143);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(17, 12);
            this.label51.TabIndex = 39;
            this.label51.Text = "Ω";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "总通道数";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(375, 169);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(17, 12);
            this.label61.TabIndex = 40;
            this.label61.Text = "Ω";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(375, 143);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(17, 12);
            this.label52.TabIndex = 40;
            this.label52.Text = "Ω";
            // 
            // swingFBox
            // 
            this.swingFBox.Location = new System.Drawing.Point(88, 163);
            this.swingFBox.Name = "swingFBox";
            this.swingFBox.Size = new System.Drawing.Size(100, 21);
            this.swingFBox.TabIndex = 34;
            this.swingFBox.Text = "10";
            // 
            // baseFBox
            // 
            this.baseFBox.Location = new System.Drawing.Point(88, 137);
            this.baseFBox.Name = "baseFBox";
            this.baseFBox.Size = new System.Drawing.Size(100, 21);
            this.baseFBox.TabIndex = 34;
            this.baseFBox.Text = "1000";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(88, 163);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(100, 21);
            this.textBox23.TabIndex = 35;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(88, 137);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 21);
            this.textBox22.TabIndex = 35;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(190, 170);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(17, 12);
            this.label60.TabIndex = 41;
            this.label60.Text = "Hz";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(190, 144);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(17, 12);
            this.label53.TabIndex = 41;
            this.label53.Text = "Hz";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(190, 170);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(17, 12);
            this.label59.TabIndex = 42;
            this.label59.Text = "Hz";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(190, 144);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(17, 12);
            this.label54.TabIndex = 42;
            this.label54.Text = "Hz";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(240, 169);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(29, 12);
            this.label58.TabIndex = 31;
            this.label58.Text = "电阻";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(240, 143);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(29, 12);
            this.label55.TabIndex = 31;
            this.label55.Text = "电阻";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(240, 169);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(29, 12);
            this.label57.TabIndex = 32;
            this.label57.Text = "电阻";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(240, 143);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(29, 12);
            this.label56.TabIndex = 32;
            this.label56.Text = "电阻";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(270, 162);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 21);
            this.textBox16.TabIndex = 38;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(270, 136);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(100, 21);
            this.textBox25.TabIndex = 38;
            // 
            // selectChannelsBox
            // 
            this.selectChannelsBox.FormattingEnabled = true;
            this.selectChannelsBox.Items.AddRange(new object[] {
            "CH-1",
            "CH-2",
            "CH-3",
            "CH-4",
            "CH-5",
            "CH-6",
            "CH-7",
            "CH-8",
            "CH-9",
            "CH-10",
            "CH-11",
            "CH-12",
            "CH-13",
            "CH-14",
            "CH-15",
            "CH-16"});
            this.selectChannelsBox.Location = new System.Drawing.Point(12, 46);
            this.selectChannelsBox.Name = "selectChannelsBox";
            this.selectChannelsBox.Size = new System.Drawing.Size(379, 84);
            this.selectChannelsBox.TabIndex = 44;
            this.selectChannelsBox.TabStop = false;
            this.selectChannelsBox.Tag = "CH";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.intervalSelect);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.scheduledBox);
            this.groupBox3.Location = new System.Drawing.Point(33, 593);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 89);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志配置";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Controls.Add(this.connect);
            this.flowLayoutPanel1.Controls.Add(this.disconnect);
            this.flowLayoutPanel1.Controls.Add(this.register);
            this.flowLayoutPanel1.Controls.Add(this.login);
            this.flowLayoutPanel1.Controls.Add(this.buildStatusMsg);
            this.flowLayoutPanel1.Controls.Add(this.buildDataMsg);
            this.flowLayoutPanel1.Controls.Add(this.logout);
            this.flowLayoutPanel1.Controls.Add(this.cacheOrder);
            this.flowLayoutPanel1.Controls.Add(this.logClear);
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(33, 31);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1116, 29);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 3;
            this.button7.Text = "重置配置";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(84, 3);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 0;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(165, 3);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(75, 23);
            this.disconnect.TabIndex = 1;
            this.disconnect.Text = "断开连接";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(246, 3);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(75, 23);
            this.register.TabIndex = 7;
            this.register.Text = "注册";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(327, 3);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 2;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // buildStatusMsg
            // 
            this.buildStatusMsg.Location = new System.Drawing.Point(408, 3);
            this.buildStatusMsg.Name = "buildStatusMsg";
            this.buildStatusMsg.Size = new System.Drawing.Size(75, 23);
            this.buildStatusMsg.TabIndex = 8;
            this.buildStatusMsg.Text = "状态报文";
            this.buildStatusMsg.UseVisualStyleBackColor = true;
            this.buildStatusMsg.Click += new System.EventHandler(this.buildStatusMsg_Click);
            // 
            // buildDataMsg
            // 
            this.buildDataMsg.Location = new System.Drawing.Point(489, 3);
            this.buildDataMsg.Name = "buildDataMsg";
            this.buildDataMsg.Size = new System.Drawing.Size(75, 23);
            this.buildDataMsg.TabIndex = 9;
            this.buildDataMsg.Text = "数据报文";
            this.buildDataMsg.UseVisualStyleBackColor = true;
            this.buildDataMsg.Click += new System.EventHandler(this.buildDataMsg_Click);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(570, 3);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(75, 23);
            this.logout.TabIndex = 5;
            this.logout.Text = "退出";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // cacheOrder
            // 
            this.cacheOrder.Location = new System.Drawing.Point(651, 3);
            this.cacheOrder.Name = "cacheOrder";
            this.cacheOrder.Size = new System.Drawing.Size(85, 23);
            this.cacheOrder.TabIndex = 6;
            this.cacheOrder.Text = "读取缓存指令";
            this.cacheOrder.UseVisualStyleBackColor = true;
            this.cacheOrder.Click += new System.EventHandler(this.cacheOrder_Click);
            // 
            // logClear
            // 
            this.logClear.Location = new System.Drawing.Point(742, 3);
            this.logClear.Name = "logClear";
            this.logClear.Size = new System.Drawing.Size(75, 23);
            this.logClear.TabIndex = 4;
            this.logClear.Text = "清空日志";
            this.logClear.UseVisualStyleBackColor = true;
            this.logClear.Click += new System.EventHandler(this.logClear_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.BackColor = System.Drawing.SystemColors.Menu;
            this.errorMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(33, 697);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(1116, 14);
            this.errorMessage.TabIndex = 28;
            // 
            // Gateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 722);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.send);
            this.Controls.Add(this.messageBuffer);
            this.Controls.Add(this.msgBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Name = "Gateway";
            this.Text = "Gateway";
            ((System.ComponentModel.ISupportInitialize)(this.intervalSelect)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gatewayNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox batteryCheckBox;
        private System.Windows.Forms.CheckBox voltageCheckBox;
        private System.Windows.Forms.CheckBox signalCheckBox;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.NumericUpDown intervalSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox scheduledBox;
        private System.Windows.Forms.RichTextBox msgBox;
        private System.Windows.Forms.RichTextBox messageBuffer;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox baseRBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox baseFBox;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Button buildRandomData;
        private System.Windows.Forms.TextBox swingRBox;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox swingFBox;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button logClear;
        private System.Windows.Forms.TextBox socketStatus;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox errorMessage;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button cacheOrder;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.TextBox signalBox;
        private System.Windows.Forms.TextBox voltageBox;
        private System.Windows.Forms.TextBox batteryBox;
        private System.Windows.Forms.Button buildStatusMsg;
        private System.Windows.Forms.Button buildDataMsg;
        private System.Windows.Forms.TextBox pwdBox;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.NumericUpDown channelSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tempBox;
        private System.Windows.Forms.CheckBox tempCheckBox;
        private System.Windows.Forms.CheckedListBox selectChannelsBox;
        private System.Windows.Forms.Button allRemoveBtn;
        private System.Windows.Forms.Button allSelectBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DomainUpDown netframeUpDown;
    }
}