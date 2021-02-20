using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class EngagementCoureur
    {
        public List<string> divisions { get; set; }
        public bool registered { get; set; }
        public string nomCoureur { get; set; }
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
        public string forme { get; set; }
        public string sante { get; set; }
        public string meteo { get; set; }
        public string choixDivision { get; set; }
        public string nbCoursesJuniorRestantes { get; set; }

        public EngagementCoureur()
        {
            this.divisions = new List<string>();
        }
    }
}
