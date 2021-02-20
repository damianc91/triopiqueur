using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class VipMedailles
    {
        public string type { get; set; }
        public List<MedailleCoureur> coureurs { get; set; }

        public VipMedailles()
        {
            this.coureurs = new List<MedailleCoureur>();
        }


    }
}
