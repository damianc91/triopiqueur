using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    public class Coureurs
    {
        public string canva { get; set; }
        public string manager { get; set; }
        public string equipe { get; set; }
        public string division { get; set; }
        public string team { get; set; }
        public string mentor { get; set; }
        public string langue { get; set; }
        public List<Coureur> coureur { get; set; }

 

        public Coureurs()
        {
            this.coureur = new List<Coureur>();
        }
    }
}
