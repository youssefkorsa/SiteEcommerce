using Api.Models;

namespace Api.Service
{
    public class ServiceProduit
    {
        // instancier ma base de données ici et apres je cré un constructeur qui me permet d'avoir accée à ma base de donnée
        MydataBase _dbContext;

        // je crée le constructeur qui me permet d'embarquer ma base de données a chaque fois que j'appel mon service

        public ServiceProduit(MydataBase dbContext)
        {
            _dbContext = dbContext;
        }

        // je veux afficher ma liste de produit dans ma page client
        public List<Product> GetProducts()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }
        // Ajouter un produit dans la liste 
        public Product Addproduct()
        {
            var producttoAdd = Addproduct();
            _dbContext.Products.Add(producttoAdd);
            _dbContext.SaveChanges();
            return producttoAdd;
        }
    }
}
