using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webApiTest.Models;

namespace webApiTest.Controllers
{
    public class StockController : ApiController
    {
        Stock stock = new Stock();
       public List<Dictionary<String, object>> getstockChangeInfo()
        {
            return stock.showStockChange();   
        }
        public int getaddStockChange(int goodsId,int wareHouseId,int number)
        {
            return stock.addStock(goodsId, wareHouseId, number);
        }
    }
}