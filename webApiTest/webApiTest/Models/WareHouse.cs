using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiTest.Models
{
   
    public class WareHouse
    {
        string queryString;
        public int wareHouseId { get; set; }
        public string wareHouseName { get; set; }
        public string wareHouseDescription { get; set; }

        public int addWareHouse(string name, string description)
        {
            int id = 0;
            MySqlConnection mysql = getMysql();
            queryString = "insert into warehouse (name,description) values ('" + name + "','" + description + "')";
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            mySqlCommand.ExecuteNonQuery();
            queryString = "SELECT MAX(id) from warehouse";
            mySqlCommand.CommandText = queryString;
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                id = rdr.GetInt32(0);
            }
            rdr.Close();//关闭读取的
            mysql.Close();//关闭链接
            return id;
        }

        public void queryGoods(int id)
        {
            MySqlConnection mysql = getMysql();
            queryString = "SELECT * from warehouse where id=" + id;
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                wareHouseId = rdr.GetInt32(0);
                wareHouseName= rdr.GetString(1);
                wareHouseDescription = rdr.GetString(2);
            }
            rdr.Close();//关闭读取的
            mysql.Close();//关闭链接
        }
        MySqlConnection getMysql()
        {
            String mysqlStr = MysqlConn.connString;
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }
        public List<Dictionary<String, object>> showWareHouse()
        {
            String queryString;
            List<Dictionary<String, object>> list = new List<Dictionary<String, object>>(4);//用于存储字典的列表
                                                                                            // Dictionary<String, object> pList = new Dictionary<String, object>();//用于保存结果

            MySqlConnection mysql = getMysql();
            queryString = "SELECT * FROM warehouse";
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    Dictionary<String, object> pList = new Dictionary<String, object>();//用于保存结果
                    pList.Add("wareHouseId", rdr.GetInt32(0));

                    pList.Add("wareHouseName", rdr.GetString(1));
                    pList.Add("wareHouseDescription", rdr.GetString(2));
                    list.Add(pList);
                }
            }

            rdr.Close();//关闭读取的
            mysql.Close();//关闭链接
            return list;
        }

    }
}