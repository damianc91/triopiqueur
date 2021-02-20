using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class VipSuivi
    {
        public List<VipSuiviCoureur> coureur { get; set; }

        public VipSuivi()
        {
            this.coureur = new List<VipSuiviCoureur>();
        }
    }
}
