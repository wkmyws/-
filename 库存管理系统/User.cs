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
    public partial class User : Form
    {
        public Index _Index;
        public bool unexpectExit = true;
        public User(Index _Index)
        {
            InitializeComponent();
            this._Index = _Index;
        }

        private void User_Load(object sender, EventArgs e)
        {
            
        }

        private void User_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (unexpectExit == true)
            {
                _Index.initLogin();
            }
        }
    }
}
