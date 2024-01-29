using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controlers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Affichage du liste des produit depuis la base de données
        [Route("")]
        [HttpGet]
        public List<Product> GetProducts()
        {
            ServiceProduct serviceProduct = new ServiceProduct(new MydataBase());
            var products = serviceProduct.GetProducts();
            return products;
        }
        // Création d'un produit dans notre base de données 
        [Route("Add")]
        [HttpPost]
        public Product AddProduct(Product product)
        {
            ServiceProduct serviceProduct = new ServiceProduct(new MydataBase());
            Product producttoAdd = serviceProduct.Addproduct(product);
            return producttoAdd;
        }

        // Modifier un produit
        [Route("Edit")]
        [HttpGet]
        public Product EditProduct(int id, Product product)
        {
            ServiceProduct serviceProduct = new ServiceProduct(new MydataBase());
            var productToEdit = serviceProduct.EditProduct(id, product);
            return productToEdit;
        }



    }
}
