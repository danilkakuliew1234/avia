using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LocalEntities;

namespace Project.Model
{
    class GetTicketsModel : BaseModel
    {
        public List<Ticket> GetTickets()
        {
            WebRequest request = WebRequest.Create($"{SERVER}/api/GetTables/1");

            WebResponse response = request.GetResponse();

            List<Ticket> tickets;

            using(StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                tickets = JsonConvert.DeserializeObject<List<Ticket>>(streamReader.ReadToEnd());
            }

            return tickets;
        }
    }
}
