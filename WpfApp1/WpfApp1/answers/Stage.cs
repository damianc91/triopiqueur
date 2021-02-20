using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class Stage
    {
        public List<StageCoureur> coureurs { get; set; }


        public Stage()
        {
            this.coureurs = new List<StageCoureur>();
        }


    }
}
