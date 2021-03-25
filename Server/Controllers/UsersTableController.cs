using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Base;

namespace Server.Controllers
{
    public class UsersTableController : ApiController
    {
        [HttpGet]
        public bool Auth(string login, string password)
        {
            return new AviaProjectEntities().Users.Where(elem => elem.login == login && elem.password == password).ToList().Count > 0;
        }
    }
}
