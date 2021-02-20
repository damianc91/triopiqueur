using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class StageCoureur
    {
        public string nomCoureur { get; set; }
        public string id { get; set; }
        public string choice { get; set; }
        public List<string> possibilities { get; set; }


        public StageCoureur()
        {
            this.possibilities = new List<string>();
        }
    }
}
