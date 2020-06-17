namespace winform_demo
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connect = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.serverLabel = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.deviceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.port.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.serverLabel.Click += new System.EventHandler(this.label2_Click);
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
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deviceNo);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.serverLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.port);
            this.Controls.Add(this.connect);
            this.Name = "ClientForm";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}

