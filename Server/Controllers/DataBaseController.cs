using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Base;

namespace Server.Controllers
{
    public class DataBaseController : ApiController
    {
        public IEnumerable<News> GetNews()
        {
            return new AviaProjectEntities().News.ToList();
        }
        public IEnumerable<Tickets> GetTickets(string id)
        {
            return new AviaProjectEntities().Tickets.ToList();
        }
    }
}
