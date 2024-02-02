using System.Text.Json.Serialization;

namespace admin.Models
{
    public class CartItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
        [JsonPropertyName("purchases")]
        public List<Purchase> Purchases { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        public CartItem(List<Purchase> purchase)
        {
            Purchases = purchase;

        }

        public CartItem()
        {
            Purchases = new List<Purchase>();
        }
    }

   

}
