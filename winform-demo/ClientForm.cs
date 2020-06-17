using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using winform_demo.Client;
using winform_demo.Device;

namespace winform_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //var text = "点击事件";
        //    //this.textBox1.Text = text;
            
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void connect_Click(object sender, EventArgs e)
        {
            var mac = this.deviceNo.Text;
            var ip = this.ip.Text;
            var port = Convert.ToInt32(this.port.Text);            
            var device = new VirtualDevice(mac);
            var client = new VirtualClient(ip, port, device);
            await client.Start();
        }
    }
}
