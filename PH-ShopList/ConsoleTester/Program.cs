using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async() => await GetAllProducts()).Wait();
        }
        private static async Task GetAllProducts()
        {
            HttpClient cliente = new HttpClient
            {
               // BaseAddress = new Uri("http://localhost/ShopListDeploy/api/Products1")
            };

            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await cliente.GetAsync("http://192.168.56.1:3011/ShopListDeploy/api/Products1/");

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Product>>(product);

            }

        }
    }
    

}
