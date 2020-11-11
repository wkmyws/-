using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace 库存管理系统
{
    public partial class AddGoods : Form
    {
        public AddGoods()
        {
            InitializeComponent();
        }
        public JSON r;
        public AddGoods(object FatherPage, string pageType, JSON r)
        {
            InitializeComponent();
            this.FatherPage = FatherPage;
            this.pageType = pageType;// Admin User
            this.Text = "修改商品属性";// never change this !!!!!!!!!!!!!!!!!
            button1.Text = "      修改商品属性";
            no.Text = r.no;
            name.Text = r.name;
            price.Text = r.price;
            type.Text = r.type;
            date.Text=r.date;
            lastdate.Text=r.lastdate;
            company.Text = r.company;
            this.r = r;
            no.Enabled = false;
            pictureBox18.Visible = false;
            button2.Visible = false;

            // 删除原有商品记录
            //Msql sql = new Msql();
            //sql.modify(string.Format("delete from goods where no='{0}';", r.no));
        }

        public AddGoods(object FatherPage,string pageType)
        {
            InitializeComponent();
            this.FatherPage = FatherPage;
            this.pageType = pageType;// Admin User
        }

        public object FatherPage;
        public string pageType="";

        private void button1_Click(object sender, EventArgs e)
        {
            // 商品编号验证
            if ((new Regex(@"^\d+$")).IsMatch(no.Text) == false)
            {
                MessageBox.Show("商品编号只能为整数格式！");
                no.Focus();
                return;
            }
            // 名称验证
            if (name.Text.Count()<=0||name.Text.Count()>100)
            {
                MessageBox.Show("商品名称字数限制在1-100！");
                name.Focus();
                return;
            }
            // 价格验证
            if ((new Regex(@"^\d+(\.\d+)?$")).IsMatch(price.Text) == false)
            {
                MessageBox.Show("价格只能为浮点数或整数格式！");
                price.Focus();
                return;
            }
            // 类别验证
            if (type.Text.Count() <= 0 || type.Text.Count() > 10)
            {
                MessageBox.Show("商品类别字数限制在1-10！");
                type.Focus();
                return;
            }
            // 保质期验证
            if ((new Regex(@"^\d+$")).IsMatch(lastdate.Text) == false)
            {
                MessageBox.Show("保质期限制为非负整数！");
                lastdate.Focus();
                return;
            }
            // 发送数据
            Msql sql = new Msql();
            if (this.Text == "修改商品属性")
            {
                //sql.modify(String.Format("delete from goods where no='{0}';", r.商品编号));
                var r = new JSON(no.Text, name.Text, price.Text, type.Text, date.Value.ToString(), lastdate.Text, company.Text, num.Text);
                if (JSON.updateToDatabase(r))
                {
                    MessageBox.Show("修改成功！");
                    switch (pageType)
                    {
                        case "Admin":
                            ((Admin)(this.FatherPage)).flashData();
                            break;
                        default:
                            break;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
                return;
            }

            bool ans = sql.modify(
                String.Format(
                "insert into goods(no,name,price,type,date,lastdate,company,num) values('{0}','{1}',{2},'{3}','{4}',{5},'{6}','{7}')",
                no.Text, name.Text, price.Text, type.Text, date.Value.ToString(), lastdate.Text, company.Text, num.Text));
            if (ans == false)
            {
                MessageBox.Show("商品编号重复，请重新输入！");
                no.Focus();
                return;
            }
            else
            {
                MessageBox.Show("添加成功！");
                switch (pageType)
                {
                    case "Admin":
                        ((Admin)(this.FatherPage)).flashData();
                        break;
                    default:
                        break;
                }
                this.Close();
            }
        }

        private void AddGoods_FormClosed(object sender, FormClosedEventArgs e)
        {/*
            // 添加原有的记录
            Msql sql = new Msql();
            if (sql.exist(string.Format("select * from goods where no='{0}'", r.no)) == false)
            {
                JSON.addToDatabase(r);
                switch (pageType)
                {
                    case "Admin":
                        ((Admin)(this.FatherPage)).flashData();
                        break;
                    default:
                        break;
                }
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定重置所填内容吗？", "", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            no.Text = name.Text = price.Text = type.Text = date.Text = lastdate.Text = company.Text = num.Text = "";
        }

        private void AddGoods_Load(object sender, EventArgs e)
        {
            if (this.pageType == "readOnly")
            {
                this.Text = "商品详情";
                button2.Visible = false;
                button1.Visible = false;
                no.Enabled = false;
                name.Enabled = false;
                price.Enabled = false;
                type.Enabled = false;
                date.Enabled = false;
                lastdate.Enabled = false;
                company.Enabled = false;
                num.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "选择图片文件";
            dialog.Filter = "图片文件(*.jpg,*.gif,*.bmp)|*.jpg;*jpeg;*.gif;*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                avator.Image = Image.FromFile(dialog.FileName);
                //var sss = FileExt.ConvertImageToBase64(dialog.FileName);
                //avator.Image = FileExt.ConvertBase64ToImage(sss);
            }
        }
    }
}
