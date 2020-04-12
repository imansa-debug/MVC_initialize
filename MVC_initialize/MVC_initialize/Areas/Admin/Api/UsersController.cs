using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_initialize.Areas.Admin.Api
{
    public class UsersController : ApiController
    {
        private DbProvider db = new DbProvider();
        public List<Users> GetUsers()
        {
            var users = db.Users;
            var userslist = users.ToList();
            return userslist;
        }
    }
}
