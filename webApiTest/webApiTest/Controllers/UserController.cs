using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using webApiTest.Models;

namespace webApiTest.Controllers
{
  
    public class UserController : ApiController
    {
        public static HttpResponseMessage objToJson(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                str = serializer.Serialize(obj);
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, System.Text.Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
        User user = new User();
        // GET: User
        public int getaddUser(string name,string password)
        {
            return user.addUser(name, password); ;
        }
        //return user infomation 
        public User getuserInfo(int id)
        {
            user.queryUserInfo(id);
            return user;
        }
        public string Options()

        {

            return null; // HTTP 200 response with empty body

        }
    }
}