namespace Api.Service
{
    public interface IServiceProduits
    {
        // on lui rajoute tout les methodes qui ont été appliquée dans la classe serviceProduct


        // Methode pour ajouter un produit
        Product Addproduct();
        // La methode pour la l'afficage du liste
        List<Product> GetProducts();

    }
}
