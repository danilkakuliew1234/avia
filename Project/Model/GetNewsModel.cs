using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LocalEntities;
using Newtonsoft.Json;

namespace Project.Model
{
    class GetNewsModel : BaseModel
    {
        public List<News> GetNews()
        {
            WebRequest request = WebRequest.Create($"{SERVER}/api/DataBase");

            WebResponse response = request.GetResponse();

            List<News> news;

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                news = JsonConvert.DeserializeObject<List<News>>(reader.ReadToEnd());
            }

            return news;
        } 
    }
}
