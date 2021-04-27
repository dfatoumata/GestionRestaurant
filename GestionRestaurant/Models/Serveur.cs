using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.Models
{
    public class Serveur
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<TableCmd> Tables { get; set; }
    }
}
