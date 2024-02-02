using Api.Service;
using Microsoft.EntityFrameworkCore;
namespace Api.Models
{
    public class CartItemService
    {
        MydataBase _context;
        ServiceProduct _serviceProduct;
        public CartItemService(MydataBase context)
        {
            _context = context;
            _serviceProduct = new ServiceProduct(_context);
        }

        //Ajouter un nouveau panier au niveau de la base données
        public CartItem AddCartItem(CartItem cartItem) 
        {   
            foreach (var item in cartItem.Purchases)
            {
                int idproduct = item.Product.Id;
                item.Product=_serviceProduct.GetProduct(idproduct);
                item.Date = DateTime.Now;
            }
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return cartItem;
        }

        // Afficher la liste
        public List<CartItem> GetCartItems()
        {
            var cartItemList= _context.CartItems.ToList();
            return cartItemList;
        }

        // Afficher la liste des Panier 
        public List<CartItem> GetPurchasesById(int IdClient)
        {
            var listCartItemId = _context.CartItems.Where(p => p.Id == IdClient).ToList();
            return listCartItemId;
        }
    }
}
