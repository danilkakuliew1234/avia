using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Project.Model
{
    class AuthModel : BaseModel
    {
        public bool Auth(string login, string password)
        {
            WebRequest request = WebRequest.Create($"{SERVER}/api/UsersTable?login={login}&password={password}");
            WebResponse response = request.GetResponse();

            bool status;

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                status = JsonConvert.DeserializeObject<bool>(streamReader.ReadToEnd());
            }

            return status;
        }
    }
}
