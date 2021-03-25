using LocalEntities;
using Server.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class GetInfoForAccountController : ApiController
    {
        // GET: api/GetInfoForAccount
        public AccountInformation GetFIO(string login)
        {
            AviaProjectEntities aviaProjectEntities = new AviaProjectEntities();

            try
            {
                return new AccountInformation
                {
                    FirstName = aviaProjectEntities.Users.Where(elem => elem.login == login).FirstOrDefault().firstname,
                    LastName = aviaProjectEntities.Users.Where(elem => elem.login == login).FirstOrDefault().lastname,
                    Name = aviaProjectEntities.Users.Where(elem => elem.login == login).FirstOrDefault().name,
                    AccountNumber = aviaProjectEntities.Cards.Where(elem => elem.login == login).FirstOrDefault().numberaccount,
                    CardNumber = aviaProjectEntities.Cards.Where(elem => elem.login == login).FirstOrDefault().creditcardnumber,
                    EndDate = aviaProjectEntities.Cards.Where(elem => elem.login == login).FirstOrDefault().validityperiod
                };
            }
            catch
            {
                return new AccountInformation();
            }
        }
    }
}
