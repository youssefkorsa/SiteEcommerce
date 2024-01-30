using admin.Models;
using admin.Repository;

namespace admin.Service
{
    public class ServiceProduct
    {
        private readonly ProductRepository _productRepository;

        public ServiceProduct()
        {
            _productRepository = new ProductRepository();
        }

        public Product AddProduct(Product productToAdd)
        {
            var newProduct = _productRepository.AddProduct(productToAdd);

            return newProduct;
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        //Supprimer Produit
        public void DeleteProduct(int Id)
        {

            _productRepository.DeleteProduct(Id);
    
        }
        //Modifier Produit

        public Product EditProduct(int idProduct,  Product product) 
        { 
         return _productRepository.EditProduct(idProduct, product);

        }

        // Editer la quantité d'un produit dans la base de données
        public void EditQuantityProduct(int Id, int quantity)
        {
            _productRepository.EditQuantityProduct(Id, quantity);
        }
    }

}
    

