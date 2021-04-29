using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionRestaurant.ViewModels;

namespace GestionRestaurant.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Serveur> Serveurs { get; set; }
        public DbSet<TableCmd> TableCmds { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Consommation> Consommations { get; set; }

        //Test Change
        //Validation
        //Teste 3
    }
}
