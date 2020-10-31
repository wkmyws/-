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
    public partial class Login : Form
    {
        public Index _Main;
        bool unexpectExit = true;
        public Login(Index _Main)
        {
            InitializeComponent();
            this._Main = _Main;
        }

        private void 登录_Click(object sender, EventArgs e)
        {
            登录.Enabled = false;
            var usr = _usr.Text;
            var pwd = _pwd.Text;
            if (usr == "" || pwd == "")
            {
                MessageBox.Show(String.Format("{0}不能为空！",usr==""?"用户名":"密码"));
                登录.Enabled=true;
                var i= (usr == "" ? _usr.Focus() : _pwd.Focus());
                return;
            }
            if (authority.SelectedIndex == -1)
            {
                MessageBox.Show("未选择权限!");
                登录.Enabled = true;
                return;
            }
            var au = authority.SelectedItem.ToString();
            switch (au)
            {
                case "管理员": au = "0"; break;
                case "用户": au = "1"; break;
                default: MessageBox.Show("权限对应错误！"); break;
            }
            Msql sql = new Msql();
            List<List<string>> ans = sql.select("select authority from user where usr='" + usr + "' and pwd='" + pwd + "' limit 1;");
            if (ans.Count == 0)
            {
                MessageBox.Show("用户名和密码不匹配！");
                登录.Enabled = true;
                return;
            }
            if (sql.exist(String.Format("select * from user where usr='{0}' and authority='{1}' limit 1;", usr, au)) == false)
            {
                MessageBox.Show("用户名和权限不匹配！");
                登录.Enabled = true;
                return;
            }
            {
                _Main.successLogin(Convert.ToInt32(ans[0][0]));
                unexpectExit = false;
                this.Close();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (unexpectExit) _Main.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }





    }
}
