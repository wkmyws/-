using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace 库存管理系统
{
    class Msql
    {
        public MySqlConnection conn;
        public Msql()
        {
            string connstr = "data source=47.96.235.211;database=dotnet;user id=c#;password=2212;pooling=false;charset=utf8";//pooling代表是否使用连接池
            conn = new MySqlConnection(connstr);
        }
        public bool modify(string sql)// 数据表增删改 是否成功
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int s = cmd.ExecuteNonQuery();
                conn.Close();
                return s != 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<List<string>> select(string sql) // 数据表查找
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = null;
            List<List<string>> ans = new List<List<string>>();
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var tmp = new List<string>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        tmp.Add(reader[i].ToString());
                    }
                    ans.Add(tmp);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("数据库连接失败！请检查网络是否畅通！");
            }
            finally
            {
                conn.Close();
            }
            return ans;
        }

        public bool exist(string sql)// 数据表是否存在记录
        {
            return select(sql).Count != 0;
        }
    }
}
