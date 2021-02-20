using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    public class CoureurIndividual
    {
        public string nom { get; set; }
        public string nomEquipe { get; set; }
        public string idEquipe { get; set; }
        public string division { get; set; }
        public string couleurCarte { get; set; }
        public string pays { get; set; }
        public string age { get; set; }
        public string pla { get; set; }
        public string mon { get; set; }
        public string des { get; set; }
        public string val { get; set; }
        public string pav { get; set; }
        public string agi { get; set; }
        public string clm { get; set; }
        public string spr { get; set; }
        public string end { get; set; }
        public string res { get; set; }
        public string ucv { get; set; }
        public string spe { get; set; }
        public string description { get; set; }
        public string salaire { get; set; }
        public string valeur { get; set; }
        public bool surveille { get; set; }
        public string champNat { get; set; }
        public string nbCourses { get; set; }
        public string prix { get; set; }
        public string jours { get; set; }
        public string nbEnchere { get; set; }
        public List<ParcoursPro> parcours { get; set; }
        public List<Medaille> medailles { get; set; }


        public CoureurIndividual()
        {
            this.parcours = new List<ParcoursPro>();
            this.medailles = new List<Medaille>();
        }

    }
}
