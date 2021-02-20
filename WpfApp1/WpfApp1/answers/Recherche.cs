using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class Recherche
    {
        public List<string> idCoureur { get; set; }
        public List<string> idTeam { get; set; }
        public List<string> nomCoureur { get; set; }
        public List<string> nomTeam { get; set; }
        public List<string> nomPays { get; set; }

        public Recherche()
        {
            this.idCoureur = new List<string>();
            this.idTeam = new List<string>(); 
            this.nomCoureur = new List<string>(); 
            this.nomTeam = new List<string>(); 
            this.nomPays = new List<string>(); 
        }
    }
}
