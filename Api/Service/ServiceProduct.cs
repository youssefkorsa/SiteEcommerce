using Api.Models;

namespace Api.Service
{
    public class ServiceProduct
    {
        // instancier ma base de données ici et apres je cré un constructeur qui me permet d'avoir accée à ma base de donnée
        MydataBase _dbContext;

        // je crée le constructeur qui me permet d'embarquer ma base de données a chaque fois que j'appel mon service

        public ServiceProduct(MydataBase dbContext)
        {
            _dbContext = dbContext;
        }

        // Trouver un prduit dans la base données a partir de son Id
        public Product GetProduct(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        // je veux afficher ma liste de produit dans ma page client
        public List<Product> GetProducts()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }
        // Ajouter un produit dans la liste 
        public Product Addproduct(Product product)
        {
            var producttoAdd = Addproduct(product);
            _dbContext.Products.Add(producttoAdd);
            _dbContext.SaveChanges();
            return producttoAdd;
        }
        // Modifier un produit dans la base de données
        public Product EditProduct(int id, Product product)
        {
            var producttoEdit = _dbContext.Products.Find(id);
            producttoEdit.Name = product.Name;
            producttoEdit.Description = product.Description;
            producttoEdit.Price = product.Price;
            producttoEdit.Category = product.Category;
    
            _dbContext.SaveChanges();

            return product;
        }

        // Supprimer un produit
        public void  DelectProduct(int id)
        {
             var idProduct = _dbContext.Products.Find(id);
            _dbContext.Remove(idProduct);
            _dbContext.SaveChanges();      
        }

        // Editer la quantité du produit dans la base de données
        public int EditQuantityProduct(int id, int quantity)
        {
            var productToEdit = _dbContext.Products.Find(id);
            var newQuantity = productToEdit.QuantityStock - quantity;
            productToEdit.QuantityStock = newQuantity;
            _dbContext.SaveChanges();

            return newQuantity;
                
        }

    }

}

