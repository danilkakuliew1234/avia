using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LocalEntities
{
    public class News
    {
        [JsonProperty("name")]
        public string NewsName { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
    public class Ticket
    {
        [JsonProperty("StartTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("EndTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty("AviaName")]
        public string AviaName { get; set; }

        [JsonProperty("From")]
        public string From { get; set; }

        [JsonProperty("To")]
        public string To { get; set; }

        [JsonProperty("Price")]
        public int Price { get; set; }
        [JsonProperty("id")]
        public int ID { get; set; }
    }
    public class Card
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("numberaccount")]
        public string NumberAccount { get; set; }
        [JsonProperty("creditcardnumber")]
        public string CreditCardNumber { get; set; }
        [JsonProperty("validityperiod")]
        public string ValidityPeriod { get; set; }
    }
    public class AccountInformation
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("EndDate")]
        public string EndDate { get; set; }
        [JsonProperty("Name")]
        public string  Name { get; set; }
        [JsonProperty("AccountNumber")]
        public string AccountNumber { get; set; }
        [JsonProperty("CardNumber")]
        public string CardNumber { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
    }
}
