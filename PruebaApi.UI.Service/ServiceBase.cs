using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.UI.Service
{
    public class ServiceBase
    {
        public HttpClient Client = new HttpClient();
        public ServiceBase()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            Client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

        }
    }
}
