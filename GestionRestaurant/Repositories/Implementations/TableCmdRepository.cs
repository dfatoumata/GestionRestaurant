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
    public class TableCmdRepository : ITableCmdRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TableCmdRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<TableCmd> GetAll()
        {
            return _dbContext.TableCmds.ToList();
        }
        public ICollection<TableCmd> GetAllWithServeurs()
        {
            return _dbContext.TableCmds.Include(tbl=>tbl.Serveur).ToList();
            // .Where(tbl=> tbl.Serveur.ID== )

        }

        public void Add(TableCmd TableCmd)
        {
            _dbContext.TableCmds.Add(TableCmd);
        }
        public TableCmd GetByIdWithServer(int Id)
        {
            return _dbContext.TableCmds.Include(tbl => tbl.Serveur)
                .FirstOrDefault(tbl => tbl.ID == Id);
        }

        public TableCmd GetByID(int Id)
        {
            var TableCmds = _dbContext.TableCmds.Find(Id);
            _dbContext.Entry(TableCmds).State = EntityState.Detached;
            return TableCmds;
        }

        public void Update(TableCmd TableCmd)
        {
            _dbContext.Entry(TableCmd).State = EntityState.Modified;
        }
        public void DeleteByID(int Id)
        {
            var TableCmdToDelete = _dbContext.TableCmds.Find(Id);
            _dbContext.TableCmds.Remove(TableCmdToDelete);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }

}
