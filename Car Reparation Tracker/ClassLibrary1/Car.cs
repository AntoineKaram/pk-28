using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT.Models
{
    public class Car
    {
        public int Barecode { get; set; }
        public string Marque  { get; set; }
        public string Couleur { get; set; }
        public string Annee { get; set; }
        public string Immatriculation { get; set; }
        public int userId { get; set; }
        public string username { get; set; }
        public string status { get; set; }
        public DateTime dateAccident { get; set; }
        public DateTime debutReparationDate { get; set; }
        public DateTime estimeeFinReparation { get; set; }
    }

}
