using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.answers;

namespace WpfApp1
{
    class Staff
    {
        public List<Scout> scouts { get; set; }

        public string entraineur { get; set; }
        public string dir_sportif { get; set; }
        public string mecano { get; set; }
        public string medecin { get; set; }
        public string recruteur { get; set; }
        
        public Staff()
        {
            this.scouts = new List<Scout>();
        }
    }
}
