using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class Forum2
    {
        public List<bool> orange { get; set; }
        public List<string> nom { get; set; }
        public List<string> lien { get; set; }
        public List<string> maxPage { get; set; }

        public Forum2()
        {
            this.orange = new List<bool>();
            this.nom = new List<string>();
            this.lien = new List<string>();
            this.maxPage = new List<string>();
        }
    }
}
