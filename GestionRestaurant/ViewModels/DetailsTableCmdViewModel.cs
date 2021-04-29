using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestaurant.ViewModels
{
    public class DetailsTableCmdViewModel
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int NumberOfPlace { get; set; }
        public bool Occupation { get; set; }
        public string Place { get; set; }

        public int ServeurId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

    }
}
