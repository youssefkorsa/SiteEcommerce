using System.Text.Json;
using System.Text;
using Api.Models;

namespace admin.Repositories
{
    public class CartItemRepository
    {
        private string _baseUrl = "http://localhost:2440/api";



        // Afficher la liste des achats
        //  Ajouter un Achat 
        public CartItem AddCartItem(CartItem CartItemToAdd)
        {
            string url = $"{_baseUrl}/CartItem/Add";
            HttpClient client = new HttpClient();
            var cartItemJson = JsonSerializer.Serialize(CartItemToAdd);
            var content = new StringContent(cartItemJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            var newCartItemJson = response.Content.ReadAsStringAsync().Result;
            CartItem newCartItem = JsonSerializer.Deserialize<CartItem>(newCartItemJson);

            return newCartItem;
        }
        // Afficher la liste des ventes
        public List<CartItem> GetCartItems()
        {
            string url = $"{_baseUrl}/CartItems";
            HttpClient client = new HttpClient();
            var reponse = client.GetAsync(url).Result;
            var cartItemJson = reponse.Content.ReadAsStringAsync().Result;

            List<CartItem> newPurchase = JsonSerializer.Deserialize<List<CartItem>>(cartItemJson);

            return newPurchase;
        }
    }
}
