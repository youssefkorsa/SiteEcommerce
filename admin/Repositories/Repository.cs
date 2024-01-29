using System.Text;
using System.Text.Json;
using admin.Models;

namespace admin.Repository
{
    public class Repository
    {
        private string _baseUrl = "http://localhost:2440/api";

        public Product GetProduct(int id)
        {
            string url = $"{_baseUrl}/products/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            Product product = JsonSerializer.Deserialize<Product>(productJson);

            return product;
        }
        public Product AddProduct(Product productToAdd)
        {
            string url = $"{_baseUrl}/products/new";
            HttpClient client = new HttpClient();
            var productJson = JsonSerializer.Serialize(productToAdd);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            var newProductJson = response.Content.ReadAsStringAsync().Result;
            Product newProduct = JsonSerializer.Deserialize<Product>(newProductJson);

            return newProduct;
        }
    }
}
