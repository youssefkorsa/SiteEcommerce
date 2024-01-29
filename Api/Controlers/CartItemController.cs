using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controlers
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

    }
}
