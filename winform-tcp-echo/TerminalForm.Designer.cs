namespace winform_demo
{
    partial class TerminalForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(TerminalForm));
            this.connect = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.deviceNo = new System.Windows.Forms.TextBox();
            this.deviceNoLabel = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.msgLabel = new System.Windows.Forms.Label();
            this.sendHistory = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recvHistory = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.sendClear = new System.Windows.Forms.Button();
            this.recvClear = new System.Windows.Forms.Button();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.heartbeat = new System.Windows.Forms.CheckBox();
            this.heartBeatLabel = new System.Windows.Forms.Label();
            this.online = new System.Windows.Forms.RadioButton();
            this.heartBeatIntervalLabel = new System.Windows.Forms.Label();
            this.heartBeatInterval = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connect
            // 
            resources.ApplyResources(this.connect, "connect");
            this.connect.Name = "connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // port
            // 
            resources.ApplyResources(this.port, "port");
            this.port.Name = "port";
            // 
            // portLabel
            // 
            resources.ApplyResources(this.portLabel, "portLabel");
            this.portLabel.Name = "portLabel";
            // 
            // serverLabel
            // 
            resources.ApplyResources(this.serverLabel, "serverLabel");
            this.serverLabel.Name = "serverLabel";
            // 
            // ip
            // 
            resources.ApplyResources(this.ip, "ip");
            this.ip.Name = "ip";
            // 
            // deviceNo
            // 
            resources.ApplyResources(this.deviceNo, "deviceNo");
            this.deviceNo.Name = "deviceNo";
            this.deviceNo.TextChanged += new System.EventHandler(this.deviceNo_TextChanged);
            // 
            // deviceNoLabel
            // 
            resources.ApplyResources(this.deviceNoLabel, "deviceNoLabel");
            this.deviceNoLabel.Name = "deviceNoLabel";
            // 
            // login
            // 
            resources.ApplyResources(this.login, "login");
            this.login.Name = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_click);
            // 
            // message
            // 
            resources.ApplyResources(this.message, "message");
            this.message.Name = "message";
            // 
            // msgLabel
            // 
            resources.ApplyResources(this.msgLabel, "msgLabel");
            this.msgLabel.Name = "msgLabel";
            // 
            // sendHistory
            // 
            resources.ApplyResources(this.sendHistory, "sendHistory");
            this.sendHistory.Name = "sendHistory";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // recvHistory
            // 
            resources.ApplyResources(this.recvHistory, "recvHistory");
            this.recvHistory.Name = "recvHistory";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // send
            // 
            resources.ApplyResources(this.send, "send");
            this.send.Name = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // sendClear
            // 
            resources.ApplyResources(this.sendClear, "sendClear");
            this.sendClear.Name = "sendClear";
            this.sendClear.UseVisualStyleBackColor = true;
            this.sendClear.Click += new System.EventHandler(this.sendClear_Click);
            // 
            // recvClear
            // 
            resources.ApplyResources(this.recvClear, "recvClear");
            this.recvClear.Name = "recvClear";
            this.recvClear.UseVisualStyleBackColor = true;
            this.recvClear.Click += new System.EventHandler(this.recvClear_Click);
            // 
            // onlineLabel
            // 
            resources.ApplyResources(this.onlineLabel, "onlineLabel");
            this.onlineLabel.Name = "onlineLabel";
            // 
            // heartbeat
            // 
            resources.ApplyResources(this.heartbeat, "heartbeat");
            this.heartbeat.Name = "heartbeat";
            this.heartbeat.UseVisualStyleBackColor = true;
            this.heartbeat.CheckedChanged += new System.EventHandler(this.heartBeat_CheckedChanged);
            // 
            // heartBeatLabel
            // 
            resources.ApplyResources(this.heartBeatLabel, "heartBeatLabel");
            this.heartBeatLabel.Name = "heartBeatLabel";
            // 
            // online
            // 
            resources.ApplyResources(this.online, "online");
            this.online.ForeColor = System.Drawing.Color.Lime;
            this.online.Name = "online";
            this.online.TabStop = true;
            this.online.UseVisualStyleBackColor = true;
            // 
            // heartBeatIntervalLabel
            // 
            resources.ApplyResources(this.heartBeatIntervalLabel, "heartBeatIntervalLabel");
            this.heartBeatIntervalLabel.Name = "heartBeatIntervalLabel";
            // 
            // heartBeatInterval
            // 
            resources.ApplyResources(this.heartBeatInterval, "heartBeatInterval");
            this.heartBeatInterval.Name = "heartBeatInterval";
            this.heartBeatInterval.TextChanged += new System.EventHandler(this.heartBeatInterval_TextChanged);
            // 
            // TerminalForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.heartBeatInterval);
            this.Controls.Add(this.heartBeatIntervalLabel);
            this.Controls.Add(this.online);
            this.Controls.Add(this.heartBeatLabel);
            this.Controls.Add(this.heartbeat);
            this.Controls.Add(this.onlineLabel);
            this.Controls.Add(this.recvClear);
            this.Controls.Add(this.sendClear);
            this.Controls.Add(this.send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recvHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendHistory);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.message);
            this.Controls.Add(this.login);
            this.Controls.Add(this.deviceNoLabel);
            this.Controls.Add(this.deviceNo);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.port);
            this.Controls.Add(this.connect);
            this.Name = "TerminalForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.TextBox deviceNo;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label deviceNoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.RichTextBox sendHistory;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Button recvClear;
        private System.Windows.Forms.Button sendClear;
        private System.Windows.Forms.RichTextBox recvHistory;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.CheckBox heartbeat;
        private System.Windows.Forms.Label heartBeatLabel;
        private System.Windows.Forms.RadioButton online;
        private System.Windows.Forms.TextBox heartBeatInterval;
        private System.Windows.Forms.Label heartBeatIntervalLabel;
    }
}

