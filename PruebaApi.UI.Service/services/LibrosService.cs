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
    public class LibrosService : ServiceBase
    {
        public LibrosService()
            : base()
        {
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiURL"]);
        }

        public async Task<IEnumerable<LibrosDTO>> GetAsync()
        {
            var response = Client.GetAsync("Libros").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<LibrosDTO>>();
                return (IEnumerable<LibrosDTO>)result;
            }
            return null;
        }

        public async Task<LibrosDTO> GetAsync(int id)
        {
            var response = Client.GetAsync("Libros" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<LibrosDTO>>();
                return (LibrosDTO)result;
            }
            return null;
        }

        public async Task<bool> InsertAsync(LibrosDTO libro)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(libro), Encoding.UTF8, "application/json");
            var response = Client.PostAsync("Libros", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<bool>();
                return result;
            }
            return false;
        }
    }
}
