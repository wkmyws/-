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
    public partial class AddUser : Form
    {
        public Admin _admin;
        public AddUser(Admin _admin,string usr="",string pwd="")
        {
            InitializeComponent();
            this._admin = _admin;
            _usr.Text = usr;
            _pwd.Text = _pwd2.Text = pwd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usr = _usr.Text;
            var pwd = _pwd.Text;
            var pwd2 = _pwd2.Text;
            var authority = "1";
            if (usr == "")
            {
                MessageBox.Show("用户名不能为空！");
                _usr.Focus();
                return;
            }
            if (pwd == "")
            {
                MessageBox.Show("密码不能为空！");
                _pwd.Focus();
                return;
            }
            if (pwd != pwd2)
            {
                MessageBox.Show("两次输入密码不一致！");
                _pwd2.Focus();
                return;
            }
            Msql sql = new Msql();
            if (sql.modify(String.Format("insert into user(usr,pwd,authority) values('{0}','{1}','{2}')", usr, pwd,authority)) == false)
            {
                MessageBox.Show("添加失败，该用户名已存在！");
                _usr.Focus();
                return;
            }
            MessageBox.Show("添加成功！");
            _admin.flashPerson();
            this.Close();

        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
