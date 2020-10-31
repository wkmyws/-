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
            bool ans = sql.modify(String.Format("insert into record(no,usr,opNum) values('{0}','{1}','{2}')", r.no, r.usr, r.opNum));
            return ans;
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
}
