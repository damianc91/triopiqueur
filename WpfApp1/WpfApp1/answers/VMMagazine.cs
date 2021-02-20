using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class VMMagazine
    {
        public List<string> divisions { get; set; }
        public List<Comment> comments { get; set; }

        public VMMagazine()
        {
            divisions = new List<string>();
            comments = new List<Comment>();
        }
    }
}
