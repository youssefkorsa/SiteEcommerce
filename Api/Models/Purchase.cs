namespace Api.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int QuantityPurchase { get; set; }
        public DateTime Date { get; set; }


        public Purchase() { }
    }
}
