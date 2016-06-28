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
        public int getlogIn(string userName, string userPassword)
        {
            return user.logIn(userName, userPassword);
        }
        public string Options()

        {

            return null; // HTTP 200 response with empty body

        }
    }
}