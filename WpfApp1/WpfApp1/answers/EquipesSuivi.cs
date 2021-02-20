using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    class EquipesSuivi
    {
        public List<EquipeSuivi> coureur { get; set; }

        public EquipesSuivi()
        {
            this.coureur = new List<EquipeSuivi>();
        }
    }
}
