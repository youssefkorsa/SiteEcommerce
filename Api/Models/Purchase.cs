namespace Api.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public Product product { get; set; }
        int QuantityPurchase { get; set; }

        public Purchase() { }
    }
}
