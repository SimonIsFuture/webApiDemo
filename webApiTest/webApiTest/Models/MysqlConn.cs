using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql;
using MySql.Data.MySqlClient;

namespace webApiTest.Models
{
    public class MysqlConn
    {
        public static string connString = "Database=stockmanage;Data Source=localhost;User Id=root;Password=;pooling=false;CharSet=utf8;port=3306";
        public MySqlConnection getMysql()
        {
            String mysqlStr = "Database=test;Data Source=localhost;User Id=root;Password=;pooling=false;CharSet=utf8;port=3306";
            // String mySqlCon = ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString;
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }
    }
}