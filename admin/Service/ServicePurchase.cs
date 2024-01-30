using admin.Models;
using admin.Repositories;

namespace admin.Service
{
    public class ServicePurchase
    {
        public readonly PurchaseRepository _PurchaseRepository;
        public ServicePurchase()
        {
            _PurchaseRepository = new PurchaseRepository();
        }
        // Ajout un achat 
        public Purchase AddPurchase(Purchase purchase)
        {
            return _PurchaseRepository.AddPurchase(purchase);
          
        }
        // Afficher la liste des achats
        public List<Purchase> GetPurchases() 
        {
            return _PurchaseRepository.GetPurchases();
        }

    }
}
