using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiTest.Models
{
    public class Goods
    {
        string queryString;
        public int itemId { get; set; }
        public string itemNumber { get; set; }
        public String itemName { get; set; }
        public String itemDescription { get; set; }

        public int addGoods(string itemnum,string itemname,string itemdes)
        {
            int id = 0;
            MySqlConnection mysql = getMysql();
            queryString = "insert into goods (item_number,name,description) values ('" + itemnum + "','" + itemname + "','" + itemdes + "')";
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            mySqlCommand.ExecuteNonQuery();
            queryString = "SELECT MAX(id) from goods";
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
            queryString = "SELECT * from goods where id=" + id;
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                itemId = rdr.GetInt32(0);
                itemNumber = rdr.GetString(1);
                itemName = rdr.GetString(2);
                itemDescription = rdr.GetString(3);
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
        public List<Dictionary<String, object>> showGoods()
        {
            String queryString;
            List<Dictionary<String, object>> list = new List<Dictionary<String, object>>(4);//用于存储字典的列表
                                                                                            // Dictionary<String, object> pList = new Dictionary<String, object>();//用于保存结果

            MySqlConnection mysql = getMysql();
            queryString = "SELECT * FROM GOODS";
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    Dictionary<String, object> pList = new Dictionary<String, object>();//用于保存结果
                    pList.Add("goodsId", rdr.GetInt32(0));
                    pList.Add("ItemNum", rdr.GetString(1));
                    pList.Add("goodsName", rdr.GetString(2));
                    pList.Add("goodsDescription", rdr.GetString(3));
                    list.Add(pList);
                }
            }

            rdr.Close();//关闭读取的
            mysql.Close();//关闭链接
            return list;
        }
    }
    }
    
