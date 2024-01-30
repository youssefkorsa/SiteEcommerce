using admin.Models;
using admin.Repositories;

namespace admin.Service
{
    public class ServiceCartItem
    {
        public readonly CartItemRepository _cartItemRepository;
        public ServiceCartItem()
        {
            _cartItemRepository = new CartItemRepository();
        }

        //Ajouter un panier 
        public CartItem AddCartItem(CartItem cartItem)
        {
            return _cartItemRepository.AddCartItem(cartItem);
        }

        // Afficher la liste des panier
        public List<CartItem> GetCartItems() 
        { 
            return _cartItemRepository.GetCartItems();
        }

        // Afficher la liste des paniers d'un client 
        public List<CartItem> GetCartItemsById(int id)
        {
            return _cartItemRepository.GetCartItemsById(id);
        }
    }
}
