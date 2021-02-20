using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    public class Calendrier
    {
        public DateTime date { get; set; }
        public string dateAsText { get; set; }
        public string nom { get; set; }
        public string distance { get; set; }
        public string typeCourse { get; set; }
        public string image { get; set; }
        public string registered { get; set; }
        public string registeredColor { get; set; }
        public string registeredTooltip { get; set; }
        public string idTour { get; set; }
        public string nomTour { get; set; }
        public string idCourse { get; set; }
        public string profil1 { get; set; }
        public string profil2 { get; set; }
        public string inscriptionVisibility { get; set; }

        public Calendrier()
        {

        }

        public Calendrier(Resultats cal)
        {
            this.date = cal.date;
            this.nom = cal.nom;
            this.distance = cal.km;
            this.image = cal.image;
            this.registered = "None";
            this.idCourse = cal.id;
        }
    }
}
