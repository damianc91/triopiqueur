using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class VipSuiviCoureur
    {
        public List<VipSuiviCoureurLine> line { get; set; }
        public string nom { get; set; }

        public VipSuiviCoureur()
        {
            this.line = new List<VipSuiviCoureurLine>();
        }
    }
}
