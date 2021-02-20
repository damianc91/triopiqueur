using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class VipStats
    {
        public string nbMontagne { get; set; }
        public string nbResistance { get; set; }
        public string nbVallon { get; set; }
        public string nbEndurance { get; set; }
        public string nbPlat { get; set; }
        public string nbSprint { get; set; }
        public string nbClm { get; set; }
        public string nbPave { get; set; }
        public string nbAgilite { get; set; }
        public string nbDescente { get; set; }
        public List<VipStatsCoureurs> coureurs { get; set; }
        public List<VipStatsEquipes> equipes { get; set; }

        public VipStats()
        {
            this.coureurs = new List<VipStatsCoureurs>();
            this.equipes = new List<VipStatsEquipes>();
        }
    }
}
