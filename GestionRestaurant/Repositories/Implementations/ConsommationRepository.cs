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
    public class ConsommationRepository : IConsommationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ConsommationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<Consommation> GetAll()
        {
            return _dbContext.Consommations.ToList();

            //var Consommations = _dbContext.Consommations.ToList();
            //return Consommations;
        }
        public void Add(Consommation Consommation)
        {
            _dbContext.Consommations.Add(Consommation);
        }
        public Consommation GetByID(int Id)
        {
            var Consommations = _dbContext.Consommations.Find(Id);
            _dbContext.Entry(Consommations).State = EntityState.Detached;
            return Consommations;
        }

        public void Update(Consommation Consommation)
        {
            _dbContext.Entry(Consommation).State = EntityState.Modified;

        }
        public void DeleteByID(int Id)
        {
            var ConsommationToDelete = _dbContext.Consommations.Find(Id);
            _dbContext.Consommations.Remove(ConsommationToDelete);
        }
        public void Save()
        {

            _dbContext.SaveChanges();
        }

    }

}
