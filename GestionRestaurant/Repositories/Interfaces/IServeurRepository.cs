using GestionRestaurant.Models;
using System.Collections.Generic;

namespace GestionRestaurant.Repositories.Implementations
{
    public interface IServeurRepository
    {
        void Add(Serveur serveur);
        void DeleteByID(int Id);
        ICollection<Serveur> GetAll();
        Serveur GetByID(int Id);
        void Save();
        void Update(Serveur serveur);
    }
}