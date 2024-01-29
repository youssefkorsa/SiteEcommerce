using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using admin.Models;

namespace admin.Repository
{
    public class ProductRepository
    {
        private string _baseUrl = "http://localhost:2440/api";

        public Product GetProduct(int id)
        {
            string url = $"{_baseUrl}/products/{id}";
            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var productJson = response.Content.ReadAsStringAsync().Result;
            Product product = JsonSerializer.Deserialize<Product>(productJson);

            return product;
        }
        public Product AddProduct(Product productToAdd)
        {
            string url = $"{_baseUrl}/products/Add";
            HttpClient client = new HttpClient();
            var productJson = JsonSerializer.Serialize(productToAdd);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, content).Result;

            var newProductJson = response.Content.ReadAsStringAsync().Result;
            Product newProduct = JsonSerializer.Deserialize<Product>(newProductJson);

            return newProduct;
        }
        // Afficher la liste des produits
        public List<Product> GetProducts()
        {
            string url = $"{_baseUrl}/products";
            HttpClient client = new HttpClient();
            var reponse = client.GetAsync(url).Result;
            var productJson = reponse.Content.ReadAsStringAsync().Result;

            List<Product> newProduct = JsonSerializer.Deserialize<List<Product>>(productJson);

            return newProduct;
        }


        // Supprimmer un produit
        public void DeleteProduct(int Id) 
        {

            string url = $"{_baseUrl}/products/{Id}";
            HttpClient client = new HttpClient();

            // Envoyer une requête HTTP DELETE à l'API
            var response = client.DeleteAsync(url).Result;
        }


        //Editer un  produit 
        public  Product EditProduct(int Id, Product productToEdit)
        {
            string url = $"{_baseUrl}/products/Edit{Id}";
            HttpClient client = new HttpClient();


            // Convertir le produitToEdit en JSON
            var productJson = JsonSerializer.Serialize(productToEdit);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");

            // Envoyer une requête HTTP PUT à l'API
            var response = client.PutAsync(url, content).Result;
            
       //  Récupérer le produit mis à jour depuis la réponse de l'API
             var updatedProductJson = response.Content.ReadAsStringAsync().Result;
             Product updatedProduct = JsonSerializer.Deserialize<Product>(updatedProductJson);

             return updatedProduct;
   
        }
    }



}
