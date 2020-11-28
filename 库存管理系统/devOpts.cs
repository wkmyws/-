using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 库存管理系统
{
    public partial class devOpts : Form
    {
        public string initSql = "";
        public devOpts()
        {
            InitializeComponent();
        }

        private void devOpts_Load(object sender, EventArgs e)
        {
            textBox1.Text = Msql.connstr;
            initSql = Msql.connstr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Msql.connstr = textBox1.Text;
            Msql test = new Msql();
            if (test.reach() == false)
            {
                Msql.connstr = initSql;
                MessageBox.Show("数据库连接失败！\n请重新输入！");
            }
            else
            {
                MessageBox.Show("更改成功！");
                this.Close();
            }
        }
    }
}
