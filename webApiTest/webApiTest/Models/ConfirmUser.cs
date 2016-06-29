using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiTest.Models
{
    public class ConfirmUser
    {
        public static bool testUser(String hashCode)
        {
            MySqlConnection mysql = getMysql();
            String queryString = "SELECT * FROM USER WHERE `userHashCode`='" + hashCode +"'";
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Close();
                mysql.Close();
                return true;
            }
            else {
                rdr.Close();
                mysql.Close();
                return false;
            }
            
        }
           
            
        static MySqlConnection getMysql()
        {
            String mysqlStr = MysqlConn.connString;
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }
    }
}