using GestionRestaurant.Models;
using System.Collections.Generic;

namespace GestionRestaurant.Repositories.Interfaces
{
    public interface ITableCmdRepository
    {
        void Add(TableCmd TableCmd);
        void DeleteByID(int Id);
        ICollection<TableCmd> GetAll();
        ICollection<TableCmd> GetAllWithServeurs();
        TableCmd GetByIdWithServer(int Id);
        TableCmd GetByID(int Id);
        void Save();
        void Update(TableCmd TableCmd);
    }
}