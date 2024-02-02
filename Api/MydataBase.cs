using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api
{
    public class MydataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // on va lui donner les information de connection de notre base de donne
            optionsBuilder.UseSqlServer("server=🦁🦁🦁\\SQLEXPRESS;Database=DBEcommerce2;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

    }
}
