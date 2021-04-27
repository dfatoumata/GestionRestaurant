using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Models
{
    public class Produit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Statut { get; set; }
        public string RevenuCenter { get; set; }
        public int NbOfPerson { get; set; }
        public virtual ICollection<Consommation> Consommations { get; set; }
    }
}
