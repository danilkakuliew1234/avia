using Server.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class GetTablesController : ApiController
    {
        public IEnumerable<News> GetNews()
        {
            return new AviaProjectEntities().News.ToList();
        }
        public IEnumerable<Tickets> GetTickets(string id)
        {
            return new AviaProjectEntities().Tickets.ToList();

        }
        public IEnumerable<Cards> GetCards(string login)
        {
            return new AviaProjectEntities().Cards.Where(elem => elem.login == login).ToList();
        }
        [HttpGet]
        public bool BuyTicket(int ID, int UserId)
        {
            AviaProjectEntities aviaProjectEntities = new AviaProjectEntities();

            IQueryable<Tickets> tickets = aviaProjectEntities.Tickets;

            Tickets ticket = tickets.FirstOrDefault(elem => elem.id == ID);
            ticket.isBuyed = true;
            ticket.UserId = UserId;

            aviaProjectEntities.SaveChanges();

            if (aviaProjectEntities.SaveChanges() == 1) return true;
            return false;
        }
    }
}
