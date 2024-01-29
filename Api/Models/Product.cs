namespace Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int QuantityStock {  get; set; }

        public Product()
        {
            
        }
        public Product (int id, string name, string description, double price, int quantityStock)
        { 
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            QuantityStock = quantityStock;           
        }
    }
}
