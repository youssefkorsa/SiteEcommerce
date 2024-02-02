using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Api.Models
{
    public class PurchaseService
    {
        public readonly MydataBase _context;

        public PurchaseService(MydataBase context)
        {
            _context = context;
        }
        // Créer un achat
        public Purchase AddPurchase(Purchase purchase)
        {
            _context.Purchases.Add(purchase);        
            _context.SaveChanges();
            return purchase;
        }

        // la liste a afficher en cas de besoin
        public List<Purchase> GetPurchases()
        {
            var purchaseList =  _context.Purchases.Include(s=>s.Product).ToList();
            return purchaseList;
        }

       
    }
}
