using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class Club
    {
        public string nomEquipe { get; set; }
        public string division { get; set; }
        public string team { get; set; }
        public string victoires { get; set; }
        public string fans { get; set; }
        public string lienMaillot { get; set; }
        public string description { get; set; }
        public string objectif1 { get; set; }
        public string objectif2 { get; set; }
        public List<Transaction> transactionVente { get; set; }
        public List<Transaction> transactionAchat { get; set; }
        public List<Historique> historique { get; set; }

        public Club()
        {
            this.transactionVente = new List<Transaction>();
            this.transactionAchat = new List<Transaction>();
            this.historique = new List<Historique>();
        }

    }
}
