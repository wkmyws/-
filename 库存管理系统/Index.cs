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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            initLogin();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        public void initLogin()
        {
            //Admin _Login = new Admin(this,"Admin","admin");
            Login _Login = new Login(this);
            _Login.Show();
        }

        public void successLogin(int identify, string usr)
        {
            //MessageBox.Show(identify.ToString());
            if (identify == 0)
            {
                // 管理员页面
                Admin _Admin = new Admin(this, "Admin", usr);
                _Admin.Show();
            }
            else if (identify == 1)
            {
                // User 页面
                //User _User = new User(this);
                Admin _User = new Admin(this, "User", usr);
                _User.Show();
            }
            else
            {
                MessageBox.Show("不合法的identify");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("确定退出吗？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                ==
                DialogResult.OK
                ) this.Close();

        }
    }
}
