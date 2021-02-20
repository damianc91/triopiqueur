using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Resultats
    {
        public DateTime date { get; set; }
        public string image { get; set; }
        public string id { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string km { get; set; }
        public string meteo { get; set; }
        public string vent { get; set; }
        public string ventDirection { get; set; }
        public List<ResultatsCoureur> resultatsCoureurs { get; set; }
        public List<ResultatsEquipe> resultatsEquipes { get; set; }
        public List<ResultatsCoursesDispos> resultatsCoursesDispos { get; set; }


        public Resultats()
        {
            this.resultatsCoureurs = new List<ResultatsCoureur>();
            this.resultatsEquipes = new List<ResultatsEquipe>();
            this.resultatsCoursesDispos = new List<ResultatsCoursesDispos>();
        }
    }
}
