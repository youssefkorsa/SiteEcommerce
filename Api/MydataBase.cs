using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api
{
    public class MydataBase :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // on va lui donner les information de connection de notre base de donne
            optionsBuilder.UseSqlServer("server=DESKTOP-2S6TJSU\\SQLEXPRESS;Database=GestionProduitNew;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        //public DbSet<Produit> Produits { get; set; }

    }
}
