using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webApiTest.Models;

namespace webApiTest.Controllers
{
    public class GoodsController : ApiController
    {
        // GET: Goods
        
        Goods goods = new Goods();
        public int getaddGoods(string itemNum, string itemName, string itemDescription,string hashCode)
        {
            if (!ConfirmUser.testUser(hashCode)) return -1;
            else return goods.addGoods(itemNum, itemName, itemDescription);
        }
        public Goods getgoodsInfo(int id)
        {
            goods.queryGoods(id);
            return goods;
        }
    }
}