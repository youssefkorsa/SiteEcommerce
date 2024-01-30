namespace admin.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Purchase> Purchase { get; set; }
        public DateTime Date { get; set; }
    }
}
