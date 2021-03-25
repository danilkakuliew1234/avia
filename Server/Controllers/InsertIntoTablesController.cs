using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Base;

namespace Server.Controllers
{
    public class InsertIntoTablesController : ApiController
    {
        public string Get(int id, int uid)
        {
            AviaProjectEntities aviaProjectEntities = new AviaProjectEntities();

            var ticket = aviaProjectEntities.Entry<Tickets>(aviaProjectEntities.Tickets.Where(elem => elem.id == id).FirstOrDefault());


            ticket.Entity.id = id;
            ticket.Entity.isBuyed = true;

            try
            {
                aviaProjectEntities.SaveChanges();
                return "1";
            } catch (DbUpdateException ex)
            {
                return ex.ToString();
            }
        }
    }
}
