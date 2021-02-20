using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class Entrainement
    {
        public string spe1 { get; set; }
        public string spe2 { get; set; }
        public List<EntrainementCoureur> entCoureur { get; set; }


        public Entrainement()
        {
            this.entCoureur = new List<EntrainementCoureur>();
        }
    }
}
