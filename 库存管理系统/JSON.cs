using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 库存管理系统
{
    public class JSON
    {
        public JSON(string no, string name, string price, string type, string date, string lastdate, string company, string num)
        {
            this.no = no;
            this.name = name;
            this.price = price;
            this.type = type;
            this.date = date;
            this.lastdate = lastdate;
            this.company = company;
            this.num = num;
        }
        public static bool addToDatabase(JSON r)
        {
            Msql sql = new Msql();
            bool ans = sql.modify(
                String.Format(
                "insert into goods(no,name,price,type,date,lastdate,company,num) values('{0}','{1}',{2},'{3}','{4}',{5},'{6}','{7}')",
                r.no, r.name, r.price, r.type, r.date, r.lastdate, r.company, r.num));
            return ans;
        }
        public static bool updateToDatabase(JSON r)
        {
            Msql sql = new Msql();
            bool ans = sql.modify(
                String.Format(
                "update goods set name='{1}',price='{2}',type='{3}',date='{4}',lastdate='{5}',company='{6}',num='{7}' where no='{0}';",
                r.no, r.name, r.price, r.type, r.date, r.lastdate, r.company, r.num));
            return ans;
        }
        public string no, name, price, type, date, lastdate, company, num;
        public string 商品编号
        {
            get { return this.no; }
            set { this.no = value; }
        }
        public string 名称
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string 价格
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public string 类型
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string 生产日期
        {
            get { return this.date; }
            set { this.date = value; }
        }
        public string 保质期_天
        {
            get { return this.lastdate; }
            set { this.lastdate = value; }
        }
        public string 公司
        {
            get { return this.company; }
            set { this.company = value; }
        }
        public string 数量
        {
            get { return this.num; }
            set { this.num = value; }
        }
    }

    public class PERSON
    {
        public PERSON(string usr, string pwd)
        {
            this.usr = usr;
            this.pwd = pwd;
        }
        public static bool addToDatabase(PERSON r)
        {
            Msql sql = new Msql();
            bool ans = sql.modify(String.Format("insert into user(usr,pwd) values('{0}','{1}')", r.用户名, r.密码));
            return ans;
        }
        public static bool updateToDatabase(PERSON r)
        {
            Msql sql = new Msql();
            bool ans = sql.modify(String.Format("update user set pwd='{1}' where usr='{0}';", r.用户名, r.密码));
            return ans;
        }
        public string usr, pwd, authority;
        public string 用户名
        {
            get { return this.usr; }
            set { this.usr = value; }
        }
        public string 密码
        {
            get { return this.pwd; }
            set { this.pwd = value; }
        }
    }
    public class KUCUN
    {
        public KUCUN(string ddno, string no, string usr, string opNum)
        {
            this.ddno = ddno;
            this.no = no;
            this.usr = usr;
            this.opNum = opNum;
        }
        public string ddno, no, usr, opNum;
        public static bool addToDatabase(KUCUN r)
        {
            Msql sql = new Msql();
            var num = sql.select(string.Format("select num from goods where no='{0}';", r.no));
            if (num.Count() == 0)
            {
                MessageBox.Show("商品表中没有此商品！");
                return false;
            }
            int nnn = Convert.ToInt32(num[0][0]);
            if (nnn + Convert.ToInt32(r.opNum) < 0)
            {
                MessageBox.Show("出库数量超过此商品现有最大库存！");
                return false;
            }
            bool ans = sql.modify(String.Format("insert into record(no,usr,opNum) values('{0}','{1}','{2}')", r.no, r.usr, r.opNum));
            bool ansans = sql.modify(String.Format("update goods set num='{0}' where no='{1}'", (nnn + Convert.ToInt32(r.opNum)), r.no));
            return ans && ansans;
        }
        public string 订单号
        {
            get { return this.ddno; }
            set { this.ddno = value; }
        }
        public string 商品编号
        {
            get { return this.no; }
            set { this.no = value; }
        }
        public string 操作者
        {
            get { return this.usr; }
            set { this.usr = value; }
        }
        public string 操作数量
        {
            get { return this.opNum; }
            set { this.opNum = value; }
        }
    }

    public class EMPTY
    {
        public EMPTY()
        {
        }
        public string no = "";
        public string NO
        {
            get { return no; }
            set { this.no = value; }
        }
    }
    public class FILTER_TABLE
    {
        public FILTER_TABLE(string type,string op,string val)
        {
            this.type = type;
            this.op = op;
            this.val = val;
        }
        public static string toSQL(FILTER_TABLE r)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("商品编号", "goods.no");
            dict.Add("商品名称", "name");
            dict.Add("价格", "price");
            dict.Add("类别", "type");
            dict.Add("生产日期", "date");
            dict.Add("保质期", "lastdate");
            dict.Add("所在公司", "company");
            dict.Add("库存数量", "num");

            dict.Add("订单号", "ddno");
            dict.Add("操作订单者", "usr");
            dict.Add("入库数量", "opNum");
            dict.Add("出库数量", "opNum");

            if (r.type == "全文搜索")
            {
                // 出库！！！！！！！！！！！！
                List<string> tmp = new List<string>();
                foreach (var item in dict.Values)
                {
                    tmp.Add(String.Format("{0} {1} '{2}'", item, r.关系, r.值));
                }
                return "(" + String.Join(" or ", tmp) + ")";
            }

            if (r.type == "出库数量") r.值 = "-" + r.值;
            return String.Format("({0} {1} '{2}')", dict[r.类别], r.关系, r.值);
        }
        public string type, op, val;
        public string 类别
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string 关系
        {
            get { return this.op; }
            set { this.op = value; }
        }
        public string 值
        {
            get { return this.val; }
            set { this.val = value; }
        }
    }
    public class UNION_GOODS
    {
        public UNION_GOODS(string cond)
        {
            string sql = string.Format("select * from goods,record {0};", cond);
            MessageBox.Show(sql);
            var ans = (new Msql().select(sql));
            string nnn = "";
            foreach (var ii in ans)
            {
                nnn += "\n" + String.Join("  ", ii);
            }
            MessageBox.Show(nnn);
        }
    }
}
