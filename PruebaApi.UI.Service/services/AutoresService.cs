using Newtonsoft.Json;
using PruebaApi.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.UI.Service.services
{
    public class AutoresService : ServiceBase
    {
        public AutoresService()
            : base()
        {
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiURL"]);
        }

        public async Task<IEnumerable<AutoresDTO>> GetAsync()
        {
            var response = Client.GetAsync("Autores").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<AutoresDTO>>();
                return (IEnumerable<AutoresDTO>)result;
            }
            return null;
        }

        public async Task<AutoresDTO> GetAsync(int id)
        {
            var response = Client.GetAsync("Autores/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<AutoresDTO>();
                return (AutoresDTO)result;
            }
            return null;
        }

        public async Task<bool> InsertAsync(AutoresDTO autor)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(autor), Encoding.UTF8, "application/json");
            var response = Client.PostAsync("Autores", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<bool>();
                return result;
            }
            return false;
        }
    }
}
