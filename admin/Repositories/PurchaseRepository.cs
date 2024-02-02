using System.Text.Json;
using System.Text;
using admin.Models;

namespace admin.Repositories
{
    public class PurchaseRepository
    {
  
            private string _baseUrl = "http://localhost:5250/api/Purchases";
            public Purchase GetPurchase(int id)
            {
                string url = $"{_baseUrl}/{id}";
                HttpClient client = new HttpClient();
                var response = client.GetAsync(url).Result;
                var purchaseJson = response.Content.ReadAsStringAsync().Result;
                Purchase purchase = JsonSerializer.Deserialize<Purchase>(purchaseJson);

                return purchase;
            }
            //  Ajouter un Achat 
            public Purchase AddPurchase(Purchase purchaseToAdd)
            {
                string url = $"{_baseUrl}/Add";
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
                string url = $"{_baseUrl}";
                HttpClient client = new HttpClient();
                var reponse = client.GetAsync(url).Result;
                var purchaseJson = reponse.Content.ReadAsStringAsync().Result;

                List<Purchase> newPurchase = JsonSerializer.Deserialize<List<Purchase>>(purchaseJson);

                return newPurchase;
            }
        
    }
}
