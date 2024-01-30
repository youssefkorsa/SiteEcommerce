using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/CartItems")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        //Ajouter un pagner dans notre base de données
        [Route("Add")]
        [HttpPost]
        public CartItem AddCartItem(CartItem cartItem) 
        {
            CartItemService cartItemService = new CartItemService(new MydataBase());
            cartItemService.AddCartItem(cartItem);
            return cartItem;
        }

        // Afficher la liste
        [Route("")]
        [HttpGet]
        public List<CartItem> GetCartItems()
        {
            CartItemService cartItemService = new CartItemService(new MydataBase());
            var cartItemList = cartItemService.GetCartItems();
            return cartItemList;
        }

        //Afficher la liste de mes panier 
        [Route("{IdClient}/List")]
        [HttpGet]
        public List<CartItem> GetCartItemsById(int IdClient)
        {
            {
                CartItemService cartItemService = new CartItemService(new MydataBase());
                var listCartItem = cartItemService.GetPurchasesById(IdClient);
                return listCartItem;
            }
        }

    }
}
