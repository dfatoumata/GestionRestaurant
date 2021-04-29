using GestionRestaurant.Models;
using GestionRestaurant.Models.Context;
using GestionRestaurant.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Repositories.Implementations
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProduitRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<Produit> GetAll()
        {
            return _dbContext.Produits.ToList();

            //var Produits = _dbContext.Produits.ToList();
            //return Produits;
        }
        public void Add(Produit Produit)
        {
            _dbContext.Produits.Add(Produit);
        }
        public Produit GetByID(int Id)
        {
            var Produits = _dbContext.Produits.Find(Id);
            _dbContext.Entry(Produits).State = EntityState.Detached;
            return Produits;
        }

        public void Update(Produit Produit)
        {
            _dbContext.Entry(Produit).State = EntityState.Modified;

        }
        public void DeleteByID(int Id)
        {
            var ProduitToDelete = _dbContext.Produits.Find(Id);
            _dbContext.Produits.Remove(ProduitToDelete);
        }
        public void Save()
        {

            _dbContext.SaveChanges();
        }

    }

}
