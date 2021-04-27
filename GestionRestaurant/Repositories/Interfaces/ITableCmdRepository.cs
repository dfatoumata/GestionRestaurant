using GestionRestaurant.Models;
using System.Collections.Generic;

namespace GestionRestaurant.Repositories.Implementations
{
    public interface ITableCmdRepository
    {
        void Add(TableCmd TableCmd);
        void DeleteByID(int Id);
        ICollection<TableCmd> GetAll();
        TableCmd GetByID(int Id);
        void Save();
        void Update(TableCmd TableCmd);
    }
}