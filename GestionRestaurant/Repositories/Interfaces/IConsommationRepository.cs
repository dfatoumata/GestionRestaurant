using GestionRestaurant.Models;
using System.Collections.Generic;

namespace GestionRestaurant.Repositories.Interfaces
{
    public interface IConsommationRepository
    {
        void Add(Consommation Consommation);
        void DeleteByID(int Id);
        ICollection<Consommation> GetAll();
        Consommation GetByID(int Id);
        void Save();
        void Update(Consommation Consommation);
    }
}