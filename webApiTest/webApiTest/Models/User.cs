using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace webApiTest.Models
{
    public class User
    {
        
        public string userName { get; set; }
        public string passWord { get; set; }
        int userId { get; set; }
        string queryString;
        DataSet set1;
        MySqlDataAdapter mda;
        public int addUser(string name,string password)
        {
            int id=0;
            MySqlConnection mysql = getMysql();
            queryString = "insert into user (userName,password,userHashCode) values ('" + name + "','" + password + "','"+(name+password).GetHashCode()+"')";
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            mySqlCommand.ExecuteNonQuery();
            queryString = "SELECT MAX(id) from `user`";
         
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
        public void queryUserInfo(int id)
        {  
            MySqlConnection mysql = getMysql(); 
            queryString = "SELECT * FROM user where id="+id;
            Console.WriteLine(queryString);
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                userId = rdr.GetInt32(0);
                userName = rdr.GetString(1);
                passWord = rdr.GetString(2);
            }
            rdr.Close();//关闭读取的
            mysql.Close();//关闭链接
        }
        public String logIn(string name,string password)
        {
            String hashCode="wrong";//not exist
            MySqlConnection mysql = getMysql();
            queryString = "SELECT userHashCode FROM user where userName='" +name+"' and  password='"+password+"'";
            Console.WriteLine(queryString);
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                hashCode = rdr.GetString(0);

            }
            rdr.Close();//关闭读取的
            mysql.Close();//关闭链接

            return hashCode;
        }
        MySqlConnection getMysql()
        {
            String mysqlStr = MysqlConn.connString;
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }
    }
}