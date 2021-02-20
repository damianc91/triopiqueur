using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class Forum1
    {
        public List<bool> orange { get; set; }
        public List<string> nom { get; set; }
        public List<string> lien { get; set; }

        public Forum1()
        {
            this.orange = new List<bool>();
            this.nom = new List<string>();
            this.lien = new List<string>();
        }
    }
}
