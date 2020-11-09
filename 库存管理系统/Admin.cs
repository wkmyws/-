﻿using System;
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
    
    public partial class Admin : Form
    {
        public Index _Index;
        public Admin that;
        public string usrName = "";
        public bool unexpectExit = true;
        public Admin(Index _Index, string type = "Admin", string usrName = "Admin")
        {
            InitializeComponent();
            this._Index = _Index;
            this.usrName = usrName;
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
            table.Columns[0].ReadOnly = true;// 不可更改列
            
            button13_Click();
            this.that=this;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*switch (tabControl1.SelectedIndex)
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
            }*/
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
            table.Columns[0].ReadOnly = true;
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
            //sql.modify("delete from goods;");
            List<AddGoods> updateList = new List<AddGoods>();
            for (var i = 0; i < list.Count(); i++)
            {
                totalNum+=1;
                if (JSON.updateToDatabase(list[i])) succNum += 1;
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
            foreach (var r_ in table.SelectedCells)
            {
                int row = ((DataGridViewTextBoxCell)r_).RowIndex;
                //var goods_no = table.Rows[row].Cells[0].Value.ToString();
                //DelGoods _DelGoods = new DelGoods(this, "Admin", goods_no);
                //_DelGoods.Show();
                //AddGoods _AddGoods = new AddGoods(this, "Admin", list[row]);
                //_AddGoods.Show();
                var r = list[row];
                no.Text = r.no;
                name.Text = r.name;
                price.Text = r.price;
                type.Text = r.type;
                date.Text = r.date;
                lastdate.Text = r.lastdate;
                company.Text = r.company;
                num.Text = r.num;
            }
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
            人员表.Columns[0].ReadOnly = true;
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
            //sql.modify("delete from user where authority='1';");
            List<AddUser> updateList = new List<AddUser>();
            int succNum = 0;
            for (var i = 0; i < personData.Count(); i++)
            {
                if (PERSON.updateToDatabase(personData[i])) succNum += 1;
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
                case "人员管理": this.tabControl1.Size = new System.Drawing.Size(550, 399); flashPerson(); 人员表.Columns[0].ReadOnly = true; break;
                case "商品管理": this.tabControl1.Size = new System.Drawing.Size(857, 399); flashData(); button13_Click(); break;
                case "库存管理": 
                    this.tabControl1.Size = new System.Drawing.Size(857, 399); 
                    flashKuCun();
                    Msql sql = new Msql();
                    comboBox1.Items.Clear();
                    sql.select("select no from goods;").ForEach(item => comboBox1.Items.Add(item[0]));
                    label15.Text = this.usrName;
                    break;
                case "查询统计":
                    this.tabControl1.Size = new System.Drawing.Size(857, 399);
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    筛选表.DataSource = new EMPTY();
                    filter_table.Clear();
                    btn.Name = "btnDel";
                    btn.HeaderText = "操作";
                    btn.DefaultCellStyle.NullValue = "删除";
                    筛选表.Columns.Clear();
                    筛选表.Columns.Add(btn);
                    类别.SelectedIndex = 0;
                    关系.SelectedIndex = 0;
                    button16Click();
                    break;
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

        private void button13_Click(object sender, EventArgs e)
        {
            button13_Click();
        }
        public void button13_Click()
        {
            foreach (var r_ in table.SelectedCells)
            {
                int row = ((DataGridViewTextBoxCell)r_).RowIndex;
                //var goods_no = table.Rows[row].Cells[0].Value.ToString();
                //DelGoods _DelGoods = new DelGoods(this, "Admin", goods_no);
                //_DelGoods.Show();
                //AddGoods _AddGoods = new AddGoods(this, "Admin", list[row]);
                //_AddGoods.Show();
                var r = list[row];
                no.Text = r.no;
                name.Text = r.name;
                price.Text = r.price;
                type.Text = r.type;
                date.Text = r.date;
                lastdate.Text = r.lastdate;
                company.Text = r.company;
                num.Text = r.num;
                break;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button14.Enabled = false;
            foreach (var r_ in table.SelectedCells)
            {
                int row = ((DataGridViewTextBoxCell)r_).RowIndex;
                list[row] = new JSON(no.Text, name.Text, price.Text, type.Text, date.Value.ToString(), lastdate.Text, company.Text, num.Text);
                button2_Click(sender, e);
                break;
            }
            button13_Click();
            button14.Enabled = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void modifyGoodsNumToSQL(string no, int num)
        {
            // assert 修改的数量小于库存数量，不做额外检测
            // assert 商品编号存在
            int n = Convert.ToInt32(new Msql().select(String.Format("select num from goods where no='{0}' limit 1;", comboBox1.Text))[0][0]);
            n += num;
            new Msql().modify(String.Format("update goods set num='{0}' where no='{1}'", n, no));
        }
        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            if (new Regex(@"^\d+$").IsMatch(op_num.Text) == false)
            {
                MessageBox.Show("入库数量应为正整数！");
                op_num.Focus();
                button10.Enabled = true;
                return;
            }
            if (new Msql().exist(String.Format("select no from goods where no='{0}' limit 1;", comboBox1.Text)) == false)
            {
                MessageBox.Show("不存在此商品编号，请联系管理员录入此商品信息！");
                button10.Enabled = true;
                return;
            }
            if (false == new Msql().modify(String.Format("insert into record(no,usr,opNum) values('{0}','{1}','{2}')", comboBox1.Text, this.usrName, op_num.Text)))
            {
                MessageBox.Show("入库失败！");
            }
            else
            {
                modifyGoodsNumToSQL(comboBox1.Text, Convert.ToInt32(op_num.Text));
                MessageBox.Show("入库成功！");
                op_num.Text = "";
            }
            button12_Click(sender, e);
            button10.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.Enabled = false;
            if (new Regex(@"^\d+$").IsMatch(op_num.Text) == false)
            {
                MessageBox.Show("出库数量应为正整数！");
                op_num.Focus();
                button11.Enabled = true;
                return;
            }
            List<List<string>> ans = new Msql().select(String.Format("select num from goods where no='{0}' limit 1;", comboBox1.Text));
            if (ans.Count() == 0)
            {
                MessageBox.Show("不存在此商品编号，请联系管理员录入此商品信息！");
                button11.Enabled = true;
                return;
            }
            if (Convert.ToDecimal(ans[0][0]) - Convert.ToDecimal(op_num.Text) < 0)
            {
                MessageBox.Show("库存数小于出库数量，出库失败！");
                button11.Enabled = true;
                return;
            }
            if (false == new Msql().modify(String.Format("insert into record(no,usr,opNum) values('{0}','{1}','{2}')", comboBox1.Text, this.usrName, "-" + op_num.Text)))
            {
                MessageBox.Show("出库失败！");
                button11.Enabled = true;
                return;
            }
            else
            {
                modifyGoodsNumToSQL(comboBox1.Text, -Convert.ToInt32(op_num.Text));
                MessageBox.Show("出库成功！");
                op_num.Text = "";
            }
            button12_Click(sender, e);
            button11.Enabled = true;
        }
        public void comboBox1_COMPLETE()
        {
            List<List<string>> ans = new Msql().select(String.Format("select name,num from goods where no='{0}' limit 1;", comboBox1.Text));
            if (ans.Count() == 0)
            {
                label16.Text = label17.Text = "该商品不存在";
                return;
            }
            label16.Text = ans[0][0];
            label17.Text = ans[0][1];
        }
        private void comboBox1_Leave(object sender, EventArgs e)
        {
            comboBox1_COMPLETE();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1_COMPLETE();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ans = new Msql().select(String.Format("select no,name,price,type,date,lastdate,company,num from goods where no='{0}';", comboBox1.Text));
            if(ans.Count()==0){
                MessageBox.Show("商品不存在！");
                return;
            }
            var r=new JSON(ans[0][0],ans[0][1],ans[0][2],ans[0][3],ans[0][4],ans[0][5],ans[0][6],ans[0][7]);
            AddGoods _previewGoods = new AddGoods(this, "readOnly", r);
            _previewGoods.Show();
        }

        
        //-------------------------------------------------------------
        List<FILTER_TABLE> filter_table = new List<FILTER_TABLE>();

        public void flash筛选表()
        {
            筛选表.DataSource = new EMPTY();
            筛选表.DataSource = filter_table;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (类别.Text == "全文搜索" && 关系.Text == "=")
            {
                if (MessageBox.Show("mysql推荐使用正则表达式（RegExp）进行全文搜索，\n是否切换到推荐设置？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    关系.Text = "RegExp";
                }
            }
            filter_table.Add(new FILTER_TABLE(类别.Text, 关系.Text, 值.Text));
            flash筛选表();
        }

        private void 筛选表_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (筛选表.Columns[e.ColumnIndex].Name == "btnDel" && e.RowIndex >= 0)
            {
                if (MessageBox.Show("确定删除此筛选项吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    filter_table.RemoveAt(e.RowIndex);
                    flash筛选表();
                }
            }
        }
        List<UNION_GOODS> searchCountAns;
        private void button16Click()
        {
            button16.Enabled = false;
            button16.Text = "正在筛选";
            List<string> filList = new List<string>();
            foreach (var ee in filter_table)
            {
                filList.Add(FILTER_TABLE.toSQL(ee));
            }
            var sql_where = filList.Count == 0 ? "" : (" where " + (String.Join(" and ", filList)));
            sql_where = "select * from goods left join record on goods.no=record.no " + sql_where + ";";
            var ans = new Msql().select(sql_where);
            searchCountGrid.DataSource = new EMPTY();
            searchCountAns = new List<UNION_GOODS>();
            for (int i = 0; i < ans.Count(); i++)
            {
                searchCountAns.Add(new UNION_GOODS(ans[i]));
            }
            searchCountGrid.DataSource = searchCountAns;
            foreach (DataGridViewColumn column in searchCountGrid.Columns)
            {
                //设置自动排序
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            button16.Text = "筛            选";
            button16.Enabled = true;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            button16Click();
        }

        private void 类别_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (类别.Text == "全文搜索")
            {
                关系.Text = "RegExp";
            }
        }


    }
    
}
