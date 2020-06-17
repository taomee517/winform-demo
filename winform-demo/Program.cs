using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_demo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //用于启动应用程序中可视的样式，如果控件和操作系统支持，那么控件的绘制就能根据显不风格来实现。
            Application.EnableVisualStyles();
            //控件支持 UseCompatibleTextRenderingproperty 属性，该方法将此属性设置为默认值。
            Application.SetCompatibleTextRenderingDefault(false);
            //用于设置在当前项目中要启动的窗体，这里 new Form1() 即为要启动的窗体。
            Application.Run(new Form1());
        }
    }
}
