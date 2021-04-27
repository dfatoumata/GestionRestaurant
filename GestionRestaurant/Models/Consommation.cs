using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Models
{
    public class Consommation
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Qty { get; set; }
        public bool Paye { get; set; }


        public virtual TableCmd Table { get; set; }
        public int TableCmdId { get; set; }
        public virtual Produit Produit { get; set; }
        public int produitId { get; set; }
    }
}
