using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiTest.Models
{
    public class Stock
    {
        private string queryString;

        public List<Dictionary<String, object>> showStockChange()
        {
            String queryString;
            List<Dictionary<String, object>> list = new List<Dictionary<String, object>>(4);//用于存储字典的列表
           // Dictionary<String, object> pList = new Dictionary<String, object>();//用于保存结果

            MySqlConnection mysql = getMysql();
            queryString = "select stock_change.id,stock.id,stock.number,stock_change.number,stock.goodsId,stock.warehouseId,stock_change.time " +
            "from stock_change LEFT JOIN stock on stock_change.stock_id = stock.id";
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    Dictionary<String, object> pList = new Dictionary<String, object>();//用于保存结果
                    pList.Add("stockChangeId", rdr.GetInt32(0));
                    pList.Add("stockId", rdr.GetInt32(1));
                    pList.Add("stockNumber", rdr.GetInt32(2));
                    pList.Add("stockChanegNum", rdr.GetInt32(3));
                    pList.Add("goodsId", rdr.GetInt32(4));
                    pList.Add("wareHouseId", rdr.GetInt32(5));
                    pList.Add("stockChangeTime", rdr.GetString(6));
                    list.Add(pList);
                }
            }
          
            rdr.Close();//关闭读取的
            mysql.Close();//关闭链接
            return list;
        }

        public int addStock(int goodsId,int wareHouseId,int number)
        {
            int stockChangeId = 0;
            int stockId = 0;
            MySqlConnection mysql = getMysql();
            queryString = "SELECT * FROM STOCK WHERE GOODSID="+goodsId+" AND WAREHOUSEID="+wareHouseId;
            mysql.Open();//打开数据库
            MySqlCommand mySqlCommand = new MySqlCommand(queryString, mysql);
            MySqlDataReader rdr = mySqlCommand.ExecuteReader();
            if (!rdr.HasRows)//if this record doesn`t exist in this table, then create a data
            {
                rdr.Close();
                mySqlCommand.CommandText = "INSERT INTO STOCK (GOODSID,WAREHOUSEID,NUMBER) VALUES("+goodsId+","+wareHouseId+","+"0)";
                mySqlCommand.ExecuteNonQuery();
            }
            else rdr.Close();
            mySqlCommand.CommandText = "SELECT * FROM STOCK WHERE GOODSID=" + goodsId + " AND WAREHOUSEID=" + wareHouseId;
            rdr = mySqlCommand.ExecuteReader();
            rdr.Read();
            stockId = rdr.GetInt32(0);
            rdr.Close();
            mySqlCommand.CommandText = "INSERT INTO STOCK_CHANGE (STOCK_ID,NUMBER) VALUES (" + stockId + "," + number + ")";
            mySqlCommand.ExecuteNonQuery();
            queryString = "SELECT MAX(id) from stock_change";
            mySqlCommand.CommandText = queryString;
            rdr = mySqlCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Read();
                stockChangeId = rdr.GetInt32(0);
            }
            Console.WriteLine(stockChangeId);
            rdr.Close();//关闭读取的

            return stockChangeId;
        }
        MySqlConnection getMysql()
        {
            String mysqlStr = MysqlConn.connString;
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }
    }
}