using admin.Models;
using System.Text.Json.Serialization;

namespace admin.Models
{
    public class Purchase
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("product")]
        public Product Product { get; set; }
        [JsonPropertyName("quantityPurchase")]
        public int QuantityPurchase { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        public Purchase(Product product, int quantityPurchase)
        { 
            Product = product;
            QuantityPurchase = quantityPurchase;
            

        }
    }
}
