using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Tactique
    {
        public string image { get; set; }
        public string id { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string km { get; set; }
        public string meteo { get; set; }
        public string vent { get; set; }
        public string ventDirection { get; set; }
        public List<Recuperation> recuperation { get; set; }
        public List<TactiqueIndividuelle> tactiqueIndividuelle { get; set; }
        public List<Sprinteur> sprinteur { get; set; }


        public Tactique()
        {
            this.recuperation = new List<Recuperation>();
            this.tactiqueIndividuelle = new List<TactiqueIndividuelle>();          
            this.sprinteur = new List<Sprinteur>();
        }
    }
}
