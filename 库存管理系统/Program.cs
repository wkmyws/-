using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 库存管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Index _Index = new Index();
            Application.Run(new Index());
        }
    }
}
