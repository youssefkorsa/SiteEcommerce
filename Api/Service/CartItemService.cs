namespace Api.Models
{
    public class CartItemService
    {
        MydataBase _context;
        public CartItemService(MydataBase context)
        {
            _context = context;
        }

        //Ajouter une nouveau achat au niveau de la base données
        public CartItem AddCartItem(CartItem cartItem) 
        {
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
    }
}
