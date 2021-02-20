using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class EntrainementCoureur
    {
        public bool reserve { get; set; }
        public string coureur { get; set; }
        public string id { get; set; }
        public string speCoureur { get; set; }
        public string lastGain { get; set; }
        public string lastGainType { get; set; }
        public string entrainement { get; set; }
        public string seuil { get; set; }

        public EntrainementCoureur()
        {
            reserve = false;
        }
    }
}
