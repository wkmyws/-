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
    public partial class UploadWebImgLink : Form
    {
        AddGoods _father;
        public UploadWebImgLink(AddGoods _addGoods)
        {
            InitializeComponent();
            _father = _addGoods;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UploadWebImgLink_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _father.button4_Click(textBox1.Text);
            this.Close();
        }
    }
}
