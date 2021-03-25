using LocalEntities;
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
    class AccountInformationModel : BaseModel
    {
        public AccountInformation LoadInfo(string login)
        {
            WebRequest request = WebRequest.Create($"{SERVER}/api/GetInfoForAccount?login={login}");
            WebResponse response = request.GetResponse();

            AccountInformation accountInformation;

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                accountInformation = JsonConvert.DeserializeObject<AccountInformation>(streamReader.ReadToEnd());
            }

            return accountInformation;
        }
    }
}
