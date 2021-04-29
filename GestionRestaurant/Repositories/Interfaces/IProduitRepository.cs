using GestionRestaurant.Models;
using System.Collections.Generic;

namespace GestionRestaurant.Repositories.Interfaces
{
    public interface IProduitRepository
    {
        void Add(Produit Produit);
        void DeleteByID(int Id);
        ICollection<Produit> GetAll();
        Produit GetByID(int Id);
        void Save();
        void Update(Produit Produit);
    }
}