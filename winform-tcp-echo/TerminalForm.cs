using System;
using System.Drawing;
using System.Windows.Forms;
using winform_demo.Client;
using winform_demo.Device;

namespace winform_demo
{
    public partial class TerminalForm : Form
    {
        private static string msgReady;
        private static VirtualClient _client;
        public delegate void ShowSendMsg(string msg);
        public delegate void ShowRecvMsg(string msg);
        public delegate void OnlineStatusChange(bool online);

        private static ShowRecvMsg showRecv;
        private static ShowSendMsg showSend;
        private static OnlineStatusChange onlineChange;

        public TerminalForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            ip.Text = "127.0.0.1";
            port.Text = "9000";
            // 展示接收消息记录
            showRecv = new ShowRecvMsg(msg =>
            {
                if (recvHistory.Text==null)
                {
                    recvHistory.Text = DateTime.Now.ToString("HH:mm:ss.fff") + ":" + msg + "\n";
                }
                else
                {
                    recvHistory.Text += DateTime.Now.ToString("HH:mm:ss.fff") + ":" + msg  + "\n";
                }
            });
            //展示发送消息记录
            showSend = new ShowSendMsg(msg =>
            {
                message.Text = "";
                if (sendHistory.Text==null)
                {
                    sendHistory.Text = DateTime.Now.ToString("HH:mm:ss.fff") + ":" + msg + "\n";
                }
                else
                {
                    sendHistory.Text += DateTime.Now.ToString("HH:mm:ss.fff") + ":" + msg  + "\n";
                }
            });
            //连接状态变更
            onlineChange = new OnlineStatusChange(status =>
            {
                if (status)
                {
                    online.Checked = true;
                    connect.Text = "断开连接";
                }
                else
                {
                    online.Checked = false;
                    connect.Text = "连接";
                }
            });
        }

        private async void connect_Click(object sender, EventArgs e)
        {
            var onlineStatus = online.Checked;
            if (onlineStatus)
            {
                _client.Disconnect();
                return;
            }
            var mac = deviceNo.Text;
            var ip = this.ip.Text;
            var port = Convert.ToInt32(this.port.Text); 
            var device = new VirtualDevice(mac, showSend, showRecv, onlineChange);
            var hbSwitch = heartbeat.Checked;
            var interval = 30;
            if (!String.IsNullOrEmpty(heartBeatInterval.Text))
            {
                interval = Convert.ToInt32(heartBeatInterval.Text);
            }
            _client = new VirtualClient(ip, port, hbSwitch, interval, device);
            await _client.Start();
            
        }

        private void login_click(object sender, EventArgs e)
        {
            var mac = deviceNo.Text;
            if (String.IsNullOrEmpty(mac))
            {
                deviceNo.BackColor = Color.Salmon;
                return;
            }
            msgReady = "login msg(" + mac + ")";
            message.Text = msgReady;
        }


        private void send_Click(object sender, EventArgs e)
        {
            _client.Send(msgReady);
        }

        private void sendClear_Click(object sender, EventArgs e)
        {
            sendHistory.Text = "";
        }

        private void recvClear_Click(object sender, EventArgs e)
        {
            recvHistory.Text = "";
        }
       

        private void heartBeat_CheckedChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(heartBeatInterval.Text))
            {
                heartBeatInterval.BackColor = Color.Salmon;
                return;
            }

            var interval = Convert.ToInt32(heartBeatInterval.Text);
            if (_client!=null && _client.Active() && heartbeat.Checked)
            {
                _client.AddInterval(interval);
            }
            
            if (_client!=null && _client.Active() && !heartbeat.Checked)
            {
                _client.RemoveInterval();
            }
        }

        private void heartBeatInterval_TextChanged(object sender, EventArgs e)
        {
            var errColor = heartBeatInterval.BackColor == Color.Salmon;
            var emptyInterval = String.IsNullOrEmpty(heartBeatInterval.Text);
            if (errColor && !emptyInterval)
            {
                heartBeatInterval.BackColor = Color.White;
            }
        }

        private void deviceNo_TextChanged(object sender, EventArgs e)
        {
            var errColor = deviceNo.BackColor == Color.Salmon;
            var emptyDeviceNo = String.IsNullOrEmpty(deviceNo.Text);
            if (errColor && !emptyDeviceNo)
            {
                deviceNo.BackColor = Color.White;
            }
        }
    }
}
