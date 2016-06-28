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

    }
}