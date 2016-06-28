using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webApiTest.Models;

namespace webApiTest.Controllers
{
    public class WareHouseController : ApiController
    {
        WareHouse ware = new WareHouse();
        public int getaddWareHouse(string wareHouseName, string wareHouseDescription)
        {
            return ware.addWareHouse(wareHouseName,wareHouseDescription);
        }
        public WareHouse getWareHouseInfo(int id)
        {
            ware.queryGoods(id);
            return ware;
        }
    }
}