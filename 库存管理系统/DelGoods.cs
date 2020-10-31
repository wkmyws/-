using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace 库存管理系统
{
    public partial class DelGoods : Form
    {
        public object FatherPage;
        public DelGoods(object FatherPage, string pageType,string goods_no="")
        {
            InitializeComponent();
            this.FatherPage = FatherPage;
            textBox1.Text = goods_no;
        }

        private void DelGoods_Load(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (new Regex(@"^\d+$").IsMatch(textBox1.Text) == false)
            {
                MessageBox.Show("商品编号只能为数字！");
                button1.Enabled = true;
                textBox1.Focus();
                return;
            }
            Msql sql = new Msql();
            if (sql.modify(String.Format("delete from goods where no={0};", textBox1.Text)))
            {
                MessageBox.Show("删除成功！");
                ((Admin)this.FatherPage).flashData();
                this.Close();
            }
            else
            {
                MessageBox.Show("此商品编号不存在，删除失败！");
            }
            button1.Enabled = true;
        }
    }
}
