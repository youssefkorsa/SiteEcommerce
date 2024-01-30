using admin.Models;

namespace admin.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public int QuantityPurchase { get; set; }

        public Purchase()
        { 

        }
    }
}
