using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Purchases")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        // Ajouter 
        [Route("Add")]
        [HttpPost]
        public Purchase AddPurchase(Purchase purchase)
        {
            PurchaseService purchaseService = new PurchaseService(new MydataBase());
            purchaseService.AddPurchase(purchase);
            return purchase;
        }

        // Afficher la liste
        [Route("")]
        [HttpGet]
        public List<Purchase> GetPurchases()
        {
            PurchaseService purchaseService = new PurchaseService(new MydataBase());
            var purchaseList = purchaseService.GetPurchases();
            return purchaseList;
        }
        
    }
}
