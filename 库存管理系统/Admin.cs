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
    
    public partial class Admin : Form
    {
        public Index _Index;
        public bool unexpectExit = true;
        public Admin(Index _Index,string type="Admin")
        {
            InitializeComponent();
            this._Index = _Index;
            if (type == "User")
            {
                // 隐藏 商品管理和人员管理选项卡
                tabControl1.TabPages.RemoveAt(0);
                tabControl1.TabPages.RemoveAt(1);
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            flashData();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0://商品管理
                    flashData();
                    break;
                case 1://库存管理

                    break;
                case 2://人员管理
                    flashPerson();
                    break;
                case 3://查询统计
                    break;
                default:
                    MessageBox.Show("意外的页面index！");
                    break;
            }
        }
        //------------------------------------------------------------
        public List<JSON> list = new List<JSON>();
        public void flashData()
        {
            list = new List<JSON>();
            Msql sql = new Msql();
            List<List<string>> ans = sql.select("select no,name,price,type,date,lastdate,company,num from goods;");
            for (var i = 0; i < ans.Count(); i++)
            {
                JSON tmp = new JSON(ans[i][0], ans[i][1], ans[i][2], ans[i][3], ans[i][4], ans[i][5], ans[i][6], ans[i][7]);
                list.Add(tmp);
            }
            table.DataSource = list;
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (unexpectExit == true)
            {
                _Index.initLogin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddGoods _AddGoods = new AddGoods(this,"Admin");
            _AddGoods.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            flashData();
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Msql sql = new Msql();
            button2.Enabled = false;
            int totalNum = 0, succNum = 0;
            sql.modify("delete from goods;");
            List<AddGoods> updateList = new List<AddGoods>();
            for (var i = 0; i < list.Count(); i++)
            {
                totalNum+=1;
                if (JSON.addToDatabase(list[i])) succNum += 1;
                else
                {
                    AddGoods _AddGoods = new AddGoods(this,"Admin",list[i]);
                    updateList.Add(_AddGoods);
                }
            }
            if (totalNum == succNum)
            {
                MessageBox.Show("更新成功！");
                this.flashData();
            }
            else
            {
                this.flashData();
                MessageBox.Show("有" + updateList.Count() + "条记录更新失败，请重新录入！");
                for (var i = 0; i < updateList.Count(); i++)
                {
                    updateList[i].Show();
                }
            }
            button2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var r in table.SelectedCells)
            {
                int row = ((DataGridViewTextBoxCell)r).RowIndex;
                var goods_no = table.Rows[row].Cells[0].Value.ToString();
                DelGoods _DelGoods = new DelGoods(this, "Admin",goods_no);
                _DelGoods.Show();
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rightMouse_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void 添加商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void 刷新数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void 保存更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }


        //---------------------------------------------------------------------------------



        
        //----------------------------------------------------------------------------
        public List<PERSON> personData = new List<PERSON>();
        private void tabPage3_Click(object sender, EventArgs e)
        {
        }
        public void flashPerson()
        {
            Msql sql = new Msql();
            人员表.DataSource = new EMPTY();
            List<List<string>> ans = sql.select("select usr,pwd from user where authority='1';");
            personData.Clear();
            for (var i = 0; i < ans.Count(); i++)
            {
                personData.Add(new PERSON(ans[i][0], ans[i][1]));
            }
            人员表.DataSource = personData;
        }
        private void 人员表_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            flashPerson();
            button6.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddUser _AddUser = new AddUser(this);
            _AddUser.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var r in 人员表.SelectedCells)
            {
                int row = ((DataGridViewTextBoxCell)r).RowIndex;
                var usr = 人员表.Rows[row].Cells[0].Value.ToString();
                DelUser _DelUser = new DelUser(this, usr);
                _DelUser.Show();
            }

            
        }

        private void 删除所选用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5_Click(sender, e);
        }

        private void 刷新数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;

            Msql sql = new Msql();
            sql.modify("delete from user where authority='1';");
            List<AddUser> updateList = new List<AddUser>();
            int succNum = 0;
            for (var i = 0; i < personData.Count(); i++)
            {
                if (PERSON.addToDatabase(personData[i])) succNum += 1;
                else
                {
                    AddUser _AddUser = new AddUser(this, personData[i].用户名, personData[i].密码);
                    updateList.Add(_AddUser);
                }
            }
            if (succNum == personData.Count())
            {
                MessageBox.Show("更新成功！");
                this.flashPerson();
                button7.Enabled = true;
                return;
            }
            else
            {
                MessageBox.Show("修改后的用户名存在冲突，请重新命名！");
                for (var i = 0; i < updateList.Count(); i++)
                {
                    updateList[i].Show();
                }
                button7.Enabled = true;
                return;
            }

            //button7.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (var r in table.SelectedCells)
            {
                int row = ((DataGridViewTextBoxCell)r).RowIndex;
                //var goods_no = table.Rows[row].Cells[0].Value.ToString();
                //DelGoods _DelGoods = new DelGoods(this, "Admin", goods_no);
                //_DelGoods.Show();
                AddGoods _AddGoods = new AddGoods(this, "Admin", list[row]);
                _AddGoods.Show();
            }
        }

        private void userRightMouse_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 添加人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button8_Click(sender, e);
        }

        private void 修改选中商品ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            button9_Click(sender, e);
        }

        private void 保存更改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.SelectedTab.Text.ToString())
            {
                case "人员管理": flashPerson(); break;
                case "商品管理": flashData(); break;
                case "库存管理": flashKuCun();break;
                //default: MessageBox.Show("未识别的选项卡"); break;
            }
        }
        //---------------------------------------------------------------库存管理
        public List<KUCUN> kucunData = new List<KUCUN>();
        private void button12_Click(object sender, EventArgs e)
        {
            button12.Enabled = false;
            flashKuCun();
            button12.Enabled = true;
        }
        public void flashKuCun()
        {
            Msql sql = new Msql();
            dataGridView1.DataSource = new EMPTY();
            List<List<string>> ans = sql.select("select ddno,no,usr,opNum from record;");
            kucunData.Clear();
            for(var i = 0; i < ans.Count(); i++)
            {
                kucunData.Add(new KUCUN(ans[i][0], ans[i][1], ans[i][2], ans[i][3]));
            }
            dataGridView1.DataSource = kucunData;
        }
        //-------------------------------------------------------------

    }
    
}
