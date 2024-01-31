namespace admin.Models
{
    public class Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
       public int QuantityStock { get; set; }
       public Product(string name, string description, double price, string category, int quantityStock)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            QuantityStock = quantityStock;
        }
    }
}

