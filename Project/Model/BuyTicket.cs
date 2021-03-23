using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    class BuyTicket : BaseModel
    {
        WebRequest request = WebRequest.Create($"{SERVER}/");
    }
}
