using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Pages;

namespace WpfApp1
{
    public class TransfertJuniors
    {
        public string nomCoureur { get; set; }
        public string idCoureur { get; set; }
        public string nomEquipe { get; set; }
        public string idEquipe { get; set; }
        public string pays { get; set; }
        public string prix { get; set; }

        public string moyenne { get; set; }
        public string spe { get; set; }
        public string monEquipe { get; set; }

        public TransfertJuniors()
        {

        } 
    }
}
