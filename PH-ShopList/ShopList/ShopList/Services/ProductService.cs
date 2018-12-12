using Newtonsoft.Json;
using ShopList.Helpers;
using ShopList.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Services
{
    public class ProductService
    {
        public async Task <List<ProductModel>> GetAllProducts() {
            HttpClient cliente = new HttpClient();
            List<ProductModel> result = new List<ProductModel>();
            {
                // BaseAddress = new Uri("http://localhost/ShopListDeploy/api/Products1")
            };

            cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await cliente.GetAsync(Constants.URLProduct);

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ProductModel>>(product);

            }

            return result;
        }
    }
}
