using Beans;
using Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class ChannelForm : Form
    {
        private int ChannelSize;
        private TopologyType Topology;
        private List<SensorDataInfo> SensorDatas;

        private static SensorModelInfo defaultSensorModel;

        public delegate void DataApplyEventHandler(object sender, DataEventArgs e);
        public event DataApplyEventHandler DataApply;

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int GetScrollPos(int hwnd, int nBar);
        private TextBox txtInput;


        public ChannelForm()
        {
            InitializeComponent();
        }


        public ChannelForm(int channelSize, TopologyType topology,List<SensorDataInfo> sensorDatas)
        {
            InitializeComponent();
            defaultSensorModel = new SensorModelInfo();
            defaultSensorModel.ModelName = "振弦默认传感器";
            defaultSensorModel.ParamSize = 2;
            defaultSensorModel.ParamNames = new List<string>() { "频率", "电阻" };
            defaultSensorModel.ParamUnits = new List<string>() { "Hz", "Ω" };

            this.ChannelSize = channelSize;
            this.Topology = topology;
            //this.SelectedChannels = selectedChannels;
            this.SensorDatas = sensorDatas;
            loadSensorDatas(sensorDatas);           
        }

        private void loadSensorDatas(List<SensorDataInfo> sensorDatas)
        {
            ListView channelSettingsView = this.channelSettingsView;
            channelSettingsView.Bounds = new Rectangle(new Point(10, 10), new Size(700, 400));
            // Set the view to show details.
            channelSettingsView.View = View.Details;
            // Allow the user to edit item text.
            channelSettingsView.LabelEdit = true;
            // Allow the user to rearrange columns.
            channelSettingsView.AllowColumnReorder = true;
            // Display check boxes.
            channelSettingsView.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            channelSettingsView.FullRowSelect = true;
            // Display grid lines.
            channelSettingsView.GridLines = true;

            channelSettingsView.HeaderStyle = ColumnHeaderStyle.Nonclickable;   // 不响应鼠标单击列头操作
            channelSettingsView.MultiSelect = true;

            // Sort the items in the list in ascending order.
            //channelSettingsView.Sorting = SortOrder.Ascending;
            channelSettingsView.Items.Clear();
            if (sensorDatas.Count > 0)
            {
                SensorModelInfo modelInfo = sensorDatas[0].ModelInfo; 

                if (channelSettingsView.Columns.Count == 0)
                {
                    channelSettingsView.Columns.Add("通道名称", 120, HorizontalAlignment.Left);
                    for (int i = 0; i < modelInfo.ParamSize; i++)
                    {
                        string title = modelInfo.ParamNames[i];
                        string unit = modelInfo.ParamUnits[i];
                        if (unit != null && unit.Length > 0)
                        {
                            title += "(" + unit + ")";
                        }
                        channelSettingsView.Columns.Add(title, 120, HorizontalAlignment.Left);
                    }
                }


                for (int i = 0; i < ChannelSize; i++)
                {
                    var channelName = "通道" + (i + 1);
                    ListViewItem lvi = new ListViewItem(channelName, i);
                    lvi.Checked = sensorDatas[i].CheckeState;
                    List<Object> datas = sensorDatas[i].Params;
                    int dataSize = datas.Count;
                    for (int j = 0; j < dataSize; j++)
                    {
                        var data = datas[j];
                        lvi.SubItems.Add(data.ToString());
                    }
                    channelSettingsView.Items.Add(lvi);
                }
            }
        }


        private void allItemSelect(object sender, EventArgs e)
        {
            ListView listView = this.channelSettingsView;
            int itemSize = listView.Items.Count;
            for (int i = 0; i < itemSize; i++)
            {
                listView.Items[i].Checked = true;
            }
        }

        private void allItemRemove(object sender, EventArgs e)
        {
            ListView listView = this.channelSettingsView;
            int itemSize = listView.Items.Count;
            for (int i = 0; i < itemSize; i++)
            {
                listView.Items[i].Checked = false;
            }
        }


        private void buildRandomData(object sender, EventArgs e)
        {
            double baseF = 1000;
            double baseR = 3000;
            double swingF = 10;
            double swingR = 50;
            

            this.SensorDatas.Clear();
            ListView listView = this.channelSettingsView;
            int totalSize = listView.Items.Count;

            Random random = new Random();
            for (int i = 0; i < totalSize; i++)
            {
                var randomNF = Math.Round(baseF + random.NextDouble() * swingF, 2);
                var randomNR = Math.Round(baseR + random.NextDouble() * swingR);                
                SensorDataInfo sensorData = new SensorDataInfo();
                sensorData.CheckeState = listView.Items[i].Checked;
                sensorData.ModelInfo = defaultSensorModel;
                sensorData.Params = new List<object>() { randomNF, randomNR };
                this.SensorDatas.Add(sensorData);
            }
            loadSensorDatas(this.SensorDatas);
        }


        private void dataApply(object sender, EventArgs e)
        {
            ListView channelSettingsView = this.channelSettingsView;
            var channelViewItems = channelSettingsView.Items;
            int itemCount = channelViewItems.Count;
            if (itemCount > 0)
            {
                this.SensorDatas.Clear();
                for (int i = 0; i < itemCount; i++)
                {
                    var item = channelViewItems[i];
                    SensorDataInfo sensorData = new SensorDataInfo();
                    sensorData.ModelInfo = defaultSensorModel;
                    sensorData.Params = new List<object>() { item.SubItems[1].Text, item.SubItems[2].Text };
                    sensorData.CheckeState = item.Checked;
                    this.SensorDatas.Add(sensorData);
                }
            }

            //向外引发一个事件
            if (DataApply != null)
            {
                DataApply(this, new DataEventArgs(SensorDatas));
                this.Close();
            }
            
        }


        // 添加鼠标双击事件
        private void channelSettingsView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem item = this.channelSettingsView.GetItemAt(e.X, e.Y);
                //找到文本框
                Rectangle rect = item.GetBounds(ItemBoundsPortion.Entire);
                int StartX = rect.Left; //获取文本框位置的X坐标
                int ColumnIndex = 0;    //文本框的索引

                //获取列的索引
                //得到滑块的位置
                int pos = GetScrollPos(this.channelSettingsView.Handle.ToInt32(), 0);
                foreach (ColumnHeader Column in channelSettingsView.Columns)
                {
                    if (e.X + pos >= StartX + Column.Width)
                    {
                        StartX += Column.Width;
                        ColumnIndex += 1;
                    }
                }

                if (ColumnIndex < this.channelSettingsView.Columns.Count - 2)//第一列为序号，不修改。如果双击为第一列则不可以进入修改
                {
                    return;
                }

                this.txtInput = new TextBox();

                //locate the txtinput and hide it. txtInput为TextBox
                this.txtInput.Parent = this.channelSettingsView;

                //begin edit
                if (item != null)
                {
                    int nDClick = this.channelSettingsView.Items[channelSettingsView.SelectedIndices[0]].Index;
                    rect.X = StartX;
                    rect.Width = this.channelSettingsView.Columns[ColumnIndex].Width; //得到长度和ListView的列的长度相同                    
                    this.txtInput.Bounds = rect;
                    this.txtInput.Multiline = true;
                    //显示文本框
                    this.txtInput.Text = item.SubItems[ColumnIndex].Text;
                    this.txtInput.Tag = item.SubItems[ColumnIndex];
                    this.txtInput.KeyPress += new KeyPressEventHandler(txtInput_KeyPress);
                    this.txtInput.Focus();
                }
            }
            catch (Exception ex)
            {

            }
        }

        //添加回车保存内容
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    if (this.txtInput != null)
                    {
                        ListViewItem.ListViewSubItem lvst = (ListViewItem.ListViewSubItem)this.txtInput.Tag;

                        //检查PN是否存在
                        int Index = 0;
                        if (CheckPnIsExist(this.txtInput.Text, ref Index))
                        {
                            this.txtInput.Text = "";
                            MessageBox.Show("第" + (Index + 1) + "行已经存在相同PN号，请重新输入!");
                        }
                        else
                        {
                            lvst.Text = this.txtInput.Text;
                        }

                        this.txtInput.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //添加事件SelectedIndexChanged，释放文本框内容
        private void channelSettingsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtInput != null)
                {
                    if (this.txtInput.Text.Length > 0)
                    {
                        ListViewItem.ListViewSubItem lvst = (ListViewItem.ListViewSubItem)this.txtInput.Tag;
                        //检查PN是否存在
                        int Index = 0;
                        if (CheckPnIsExist(this.txtInput.Text, ref Index))
                        {
                            this.txtInput.Text = "";
                            MessageBox.Show("第" + (Index + 1) + "行已经存在相同PN号，请重新输入!");
                        }
                        else
                        {
                            lvst.Text = this.txtInput.Text;
                        }

                    }

                    this.txtInput.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
        }

        //添加事件，鼠标单击MouseClick，将文本框内容显示在channelSettingsView

        private void channelSettingsView_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.txtInput != null)
                {
                    if (this.txtInput.Text.Length > 0)
                    {
                        ListViewItem.ListViewSubItem lvst = (ListViewItem.ListViewSubItem)this.txtInput.Tag;

                        //检查PN是否存在
                        int Index = 0;
                        if (CheckPnIsExist(this.txtInput.Text, ref Index))
                        {
                            this.txtInput.Text = "";
                            MessageBox.Show("第" + (Index + 1) + "行已经存在相同PN号，请重新输入!");
                        }
                        else
                        {
                            lvst.Text = this.txtInput.Text;
                        }
                    }

                    this.txtInput.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool CheckPnIsExist(string text, ref int index)        
        {
            return false;
        }

    }
}
