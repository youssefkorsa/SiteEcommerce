namespace Api.Models
{
    public class Product
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double price { get; set; }
        int QuantityStock {  get; set; }
        public Product ()
        { 

        }
    }
}
