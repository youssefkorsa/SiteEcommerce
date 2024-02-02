using System.Text.Json.Serialization;

namespace admin.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
       public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
        [JsonPropertyName("quantityStock")]
        public int QuantityStock { get; set; }
        [JsonPropertyName("imageURL")]
        public string ImageURL {  get; set; }
       public Product(string name, string description, double price, string category, int quantityStock, string imageURL)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            QuantityStock = quantityStock;
            ImageURL= imageURL;
        }
    }
}

