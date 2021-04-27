using GestionRestaurant.Models;
using GestionRestaurant.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Repositories.Implementations
{
    public class ServeurRepository : IServeurRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ServeurRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<Serveur> GetAll()
        {
            return _dbContext.Serveurs.ToList();

            //var serveurs = _dbContext.Serveurs.ToList();
            //return serveurs;
        }
        public void Add(Serveur serveur)
        {
            _dbContext.Serveurs.Add(serveur);
        }
        public Serveur GetByID(int Id)
        {
            return _dbContext.Serveurs.Find(Id);
        }

        public void Update(Serveur serveur)
        {
            _dbContext.Entry(serveur).State = EntityState.Modified;

        }
        public void DeleteByID(int Id)
        {
            var serveurToDelete = _dbContext.Serveurs.Find(Id);
            _dbContext.Serveurs.Remove(serveurToDelete);
        }
        public void Save()
        {

            _dbContext.SaveChanges();
        }

    }
}
