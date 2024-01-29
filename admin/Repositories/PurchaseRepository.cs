using System.Text.Json;
using System.Text;
using Api.Models;

namespace admin.Repositories
{
    public class PurchaseRepository
    {
  
            private string _baseUrl = "http://localhost:2440/api";
            public Customer GetCustomer(int id)
            {
                string url = $"{_baseUrl}/customers/{id}";
                HttpClient client = new HttpClient();
                var response = client.GetAsync(url).Result;
                var customerJson = response.Content.ReadAsStringAsync().Result;
                Customer customer = JsonSerializer.Deserialize<Customer>(customerJson);

                return customer;
            }
            //  Ajouter un Achat 
            public Purchase AddPurchase(Purchase purchaseToAdd)
            {
                string url = $"{_baseUrl}/purchase/Add";
                HttpClient client = new HttpClient();
                var purchaseJson = JsonSerializer.Serialize(purchaseToAdd);
                var content = new StringContent(purchaseJson, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;

                var newPurchaseJson = response.Content.ReadAsStringAsync().Result;
                Purchase newPurchase = JsonSerializer.Deserialize<Purchase>(newPurchaseJson);

                return newPurchase;
            }
            // Afficher la liste des ventes
            public List<Purchase> GetPurchases()
            {
                string url = $"{_baseUrl}/purchases";
                HttpClient client = new HttpClient();
                var reponse = client.GetAsync(url).Result;
                var purchaseJson = reponse.Content.ReadAsStringAsync().Result;

                List<Purchase> newPurchase = JsonSerializer.Deserialize<List<Purchase>>(purchaseJson);

                return newPurchase;
            }
        
    }
}
