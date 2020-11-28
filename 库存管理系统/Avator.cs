using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 库存管理系统
{
    public partial class Avator : Form
    {
        public string no = "";
        public Avator(string no="")
        {
            InitializeComponent();
            if (no == "") return;
            this.no = no;
            Time.setTimeout(500, () =>
            {
                Action action = delegate ()
                {
                    try
                    {
                        var ii = FileExt.ConvertBase64ToImage(new Msql().select(String.Format("select convert (base64 using utf8) from goods_avator where no='{0}';", no))[0][0]);
                        pictureBox1.Image = ii;
                    }
                    catch (Exception)
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = false;
                    }
                    finally
                    {
                        int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
                        int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度
                        this.Location = new Point(xWidth / 2 - this.Width / 2, yHeight / 2 - this.Height / 2);
                    }
                };
                try { this.Invoke(action); } catch (Exception) { }
            });
        }
        public Avator(Image img)
        {
            InitializeComponent();
            Time.setTimeout(500, () =>
            {
                Action action = delegate ()
                {
                    try
                    {
                        pictureBox1.Image = img;
                    }
                    catch (Exception)
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = false;
                    }
                    finally
                    {
                        int xWidth = SystemInformation.PrimaryMonitorSize.Width;//获取显示器屏幕宽度
                        int yHeight = SystemInformation.PrimaryMonitorSize.Height;//高度
                        this.Location = new Point(xWidth / 2 - this.Width / 2, yHeight / 2 - this.Height / 2);
                    }
                };
                try { this.Invoke(action); } catch (Exception) { }
            });
        }

        private void Avator_Load(object sender, EventArgs e)
        {
           
        }
    }
}
