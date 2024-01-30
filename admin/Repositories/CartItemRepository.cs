using System.Text.Json;
using System.Text;
using admin.Models;

namespace admin.Repositories
{
    public class CartItemRepository
    {
        private string _baseUrl = "http://localhost:2440/api/CartItem";



        
        //  Ajouter un panier
        public CartItem AddCartItem(CartItem CartItemToAdd)
        {
            string url = $"{_baseUrl}/Add";
            HttpClient client = new HttpClient();
            var cartItemJson = JsonSerializer.Serialize(CartItemToAdd);
            var content = new StringContent(cartItemJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            var newCartItemJson = response.Content.ReadAsStringAsync().Result;
            CartItem newCartItem = JsonSerializer.Deserialize<CartItem>(newCartItemJson);

            return newCartItem;
        }
        // Afficher la liste des paniers
        public List<CartItem> GetCartItems()
        {
            string url = $"{_baseUrl}";
            HttpClient client = new HttpClient();
            var reponse = client.GetAsync(url).Result;
            var cartItemJson = reponse.Content.ReadAsStringAsync().Result;

            List<CartItem> newPurchase = JsonSerializer.Deserialize<List<CartItem>>(cartItemJson);

            return newPurchase;
        }

        // Afficher la liste des paniers d'un seul client
        public List<CartItem> GetCartItemsById(int id)
        {
            string url = $"{_baseUrl}/{id}/List";
            HttpClient client = new HttpClient();
            var reponse = client.GetAsync(url).Result;
            var cartItemJson = reponse.Content.ReadAsStringAsync().Result;

            List<CartItem> newPurchase = JsonSerializer.Deserialize<List<CartItem>>(cartItemJson);

            return newPurchase;
        }
    }
}
