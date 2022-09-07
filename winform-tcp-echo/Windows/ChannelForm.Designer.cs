namespace Windows
{
    partial class ChannelForm
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
            this.channelSettingsView = new System.Windows.Forms.ListView();
            this.allSelectBtn = new System.Windows.Forms.Button();
            this.allRemoveBtn = new System.Windows.Forms.Button();
            this.appBtn = new System.Windows.Forms.Button();
            this.randomBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // channelSettingsView
            // 
            this.channelSettingsView.HideSelection = false;
            this.channelSettingsView.Location = new System.Drawing.Point(12, 17);
            this.channelSettingsView.Name = "channelSettingsView";
            this.channelSettingsView.Size = new System.Drawing.Size(698, 391);
            this.channelSettingsView.TabIndex = 6;
            this.channelSettingsView.UseCompatibleStateImageBehavior = false;
            this.channelSettingsView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            this.channelSettingsView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.channelSettingsView_MouseClick);
            this.channelSettingsView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.channelSettingsView_MouseDoubleClick);
            // 
            // allSelectBtn
            // 
            this.allSelectBtn.Location = new System.Drawing.Point(114, 415);
            this.allSelectBtn.Name = "allSelectBtn";
            this.allSelectBtn.Size = new System.Drawing.Size(75, 23);
            this.allSelectBtn.TabIndex = 7;
            this.allSelectBtn.Text = "全选";
            this.allSelectBtn.UseVisualStyleBackColor = true;
            this.allSelectBtn.Click += new System.EventHandler(this.allItemSelect);
            // 
            // allRemoveBtn
            // 
            this.allRemoveBtn.Location = new System.Drawing.Point(236, 415);
            this.allRemoveBtn.Name = "allRemoveBtn";
            this.allRemoveBtn.Size = new System.Drawing.Size(75, 23);
            this.allRemoveBtn.TabIndex = 7;
            this.allRemoveBtn.Text = "反选";
            this.allRemoveBtn.UseVisualStyleBackColor = true;
            this.allRemoveBtn.Click += new System.EventHandler(this.allItemRemove);
            // 
            // appBtn
            // 
            this.appBtn.Location = new System.Drawing.Point(476, 415);
            this.appBtn.Name = "appBtn";
            this.appBtn.Size = new System.Drawing.Size(75, 23);
            this.appBtn.TabIndex = 7;
            this.appBtn.Text = "应用";
            this.appBtn.UseVisualStyleBackColor = true;
            this.appBtn.Click += new System.EventHandler(this.dataApply);
            // 
            // randomBtn
            // 
            this.randomBtn.Location = new System.Drawing.Point(357, 415);
            this.randomBtn.Name = "randomBtn";
            this.randomBtn.Size = new System.Drawing.Size(75, 23);
            this.randomBtn.TabIndex = 8;
            this.randomBtn.Text = "重新随机";
            this.randomBtn.UseVisualStyleBackColor = true;
            this.randomBtn.Click += new System.EventHandler(this.buildRandomData);
            // 
            // ChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.randomBtn);
            this.Controls.Add(this.appBtn);
            this.Controls.Add(this.allRemoveBtn);
            this.Controls.Add(this.allSelectBtn);
            this.Controls.Add(this.channelSettingsView);
            this.Name = "ChannelForm";
            this.Text = "ChannelForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView channelSettingsView;
        private System.Windows.Forms.Button allSelectBtn;
        private System.Windows.Forms.Button allRemoveBtn;
        private System.Windows.Forms.Button appBtn;
        private System.Windows.Forms.Button randomBtn;
    }
}