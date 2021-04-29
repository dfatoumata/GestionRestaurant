using GestionRestaurant.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.ViewModels
{
    public class TableCmdViewModel
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int NumberOfPlace { get; set; }
        public bool Occupation { get; set; }
        public string Place { get; set; }
        public virtual Serveur Serveur { get; set; }
        public int ServeurId { get; set; }
        public virtual ICollection<Consommation> Consommations { get; set; }
        public List<SelectListItem> Serveurs { get; set; }
    }
}
