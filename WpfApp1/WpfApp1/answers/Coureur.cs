using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.answers
{
    public class Coureur
    {
        public string nom { get; set; }
        public string id { get; set; }
        public string pays { get; set; }
        public string age { get; set; }
        public string pla { get; set; }
        public string mon { get; set; }
        public string des { get; set; }
        public string val { get; set; }
        public string pav { get; set; }
        public string agi { get; set; }
        public string clm { get; set; }
        public string spr { get; set; }
        public string end { get; set; }
        public string res { get; set; }
        public string form { get; set; }
        public string sante { get; set; }
        public string ucv { get; set; }
        public bool reserve { get; set; }
        public string champNat { get; set; }
        public string aVendre { get; set; }
        public string salaire { get; set; }

        public string plaRound { get; set; }
        public string monRound { get; set; }
        public string desRound { get; set; }
        public string valRound { get; set; }
        public string pavRound { get; set; }
        public string agiRound { get; set; }
        public string clmRound { get; set; }
        public string sprRound { get; set; }
        public string endRound { get; set; }
        public string resRound { get; set; }
        public string plaColor { get; set; }
        public string monColor { get; set; }
        public string desColor { get; set; }
        public string valColor { get; set; }
        public string pavColor { get; set; }
        public string agiColor { get; set; }
        public string clmColor { get; set; }
        public string sprColor { get; set; }
        public string endColor { get; set; }
        public string resColor { get; set; }
        public string star1 { get; set; }
        public string star2 { get; set; }
        public string star3 { get; set; }
        public string star4 { get; set; }
        public string star5 { get; set; }
        public string star1Hidden { get; set; }
        public string star2Hidden { get; set; }
        public string star3Hidden { get; set; }
        public string star4Hidden { get; set; }
        public string star5Hidden { get; set; }
        public string medaille1 { get; set; }
        public string medaille2 { get; set; }
        public string monEquipe { get; set; }
        public string couleurCarte { get; set; }
        public string specialite { get; set; }
        public int niveauMax { get; set; }
        public string niveauMaxString { get; set; }
        public int potentielMax { get; set; }
        public string potentielMaxString { get; set; }
        public int niveauBaroudeur { get; set; }
        public int potentielBaroudeur { get; set; }
        public int niveauGrimpeur { get; set; }
        public int potentielGrimpeur { get; set; }
        public int niveauVallon { get; set; }
        public int potentielVallon { get; set; }
        public int niveauPave { get; set; }
        public int potentielPave { get; set; }
        public int niveauAgilite { get; set; }
        public int potentielAgilite { get; set; }
        public int niveauClm { get; set; }
        public int potentielClm { get; set; }
        public int niveauSpr { get; set; }
        public int potentielSpr { get; set; }
        public int lenghtMedaille1 { get; set; }
        public int lenghtMedaille2 { get; set; }
        public int lenghtChampNat { get; set; }
        public string formRounded { get; set; }
        public string santeRounded { get; set; }
        public string formColor { get; set; }
        public string santeColor { get; set; }



        internal void UpdateStars()
        {
            if (niveauMax == 0)
            {
                if (potentielMax == 10)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 7)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 6)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 5)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "StarHalf";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 4)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 3)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "StarHalf";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 2)
                {
                    star1 = "StarOutline";
                    star1Hidden = "None";
                    star2 = "None";
                    star2Hidden = "Star";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 1)
                {
                    star1 = "StarOutline";
                    star1Hidden = "StarHalf";
                    star2 = "None";
                    star2Hidden = "Star";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star1 = "None";
                    star1Hidden = "Star";
                    star2 = "None";
                    star2Hidden = "Star";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 1)
            {
                if (potentielMax == 10)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 7)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 6)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 5)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "StarHalf";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 4)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 3)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "StarOutline";
                    star2Hidden = "StarHalf";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 2)
                {
                    star1 = "StarHalfFull";
                    star1Hidden = "None";
                    star2 = "None";
                    star2Hidden = "Star";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star1 = "StarHalf";
                    star1Hidden = "StarHalf";
                    star2 = "None";
                    star2Hidden = "Star";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 2)
            {
                star1 = "Star";

                star1Hidden = "None";

                if (potentielMax == 10)
                {
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 7)
                {
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 6)
                {
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 5)
                {
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "StarHalf";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 4)
                {
                    star2 = "StarOutline";
                    star2Hidden = "None";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 3)
                {
                    star2 = "StarOutline";
                    star2Hidden = "StarHalf";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star2 = "None";
                    star2Hidden = "Star";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 3)
            {
                star1 = "Star";

                star1Hidden = "None";

                if (potentielMax == 10)
                {
                    star2 = "StarHalfFull";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star2 = "StarHalfFull";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star2 = "StarHalfFull";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 7)
                {
                    star2 = "StarHalfFull";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 6)
                {
                    star2 = "StarHalfFull";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 5)
                {
                    star2 = "StarHalfFull";
                    star2Hidden = "None";
                    star3 = "StarOutline";
                    star3Hidden = "StarHalf";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 4)
                {
                    star2 = "StarHalfFull";
                    star2Hidden = "None";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star2 = "StarHalf";
                    star2Hidden = "StarHalf";
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 4)
            {
                star1 = "Star";
                star2 = "Star";


                star1Hidden = "None";
                star2Hidden = "None";


                if (potentielMax == 10)
                {
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 7)
                {
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 6)
                {
                    star3 = "StarOutline";
                    star3Hidden = "None";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 5)
                {
                    star3 = "StarOutline";
                    star3Hidden = "StarHalf";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star3 = "None";
                    star3Hidden = "Star";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 5)
            {
                star1 = "Star";
                star2 = "Star";


                star1Hidden = "None";
                star2Hidden = "None";


                if (potentielMax == 10)
                {
                    star3 = "StarHalfFull";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star3 = "StarHalfFull";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star3 = "StarHalfFull";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 7)
                {
                    star3 = "StarHalfFull";
                    star3Hidden = "None";
                    star4 = "StarOutline";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 6)
                {
                    star3 = "StarHalfFull";
                    star3Hidden = "None";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star3 = "StarHalfFull";
                    star3Hidden = "StarHalf";
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 6)
            {
                star1 = "Star";
                star2 = "Star";
                star3 = "Star";

                star1Hidden = "None";
                star2Hidden = "None";
                star3Hidden = "None";

                if (potentielMax == 10)
                {
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star4 = "StarOutline";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else if (potentielMax == 7)
                {
                    star4 = "StarOutline";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star4 = "None";
                    star4Hidden = "Star";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 7)
            {
                star1 = "Star";
                star2 = "Star";
                star3 = "Star";

                star1Hidden = "None";
                star2Hidden = "None";
                star3Hidden = "None";

                if (potentielMax == 10)
                {
                    star4 = "StarHalfFull";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star4 = "StarHalfFull";
                    star4Hidden = "None";
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else if (potentielMax == 8)
                {
                    star4 = "StarHalfFull";
                    star4Hidden = "None";
                    star5 = "None";
                    star5Hidden = "Star";
                }
                else
                {
                    star4 = "StarHalf";
                    star4Hidden = "StarHalf";
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 8)
            {
                star1 = "Star";
                star2 = "Star";
                star3 = "Star";
                star4 = "Star";

                star1Hidden = "None";
                star2Hidden = "None";
                star3Hidden = "None";
                star4Hidden = "None";

                if (potentielMax == 10)
                {
                    star5 = "StarOutline";
                    star5Hidden = "None";
                }
                else if (potentielMax == 9)
                {
                    star5 = "StarOutline";
                    star5Hidden = "StarHalf";
                }
                else
                {
                    star5 = "None";
                    star5Hidden = "Star";
                }
            }
            else if (niveauMax == 9)
            {
                star1 = "Star";
                star2 = "Star";
                star3 = "Star";
                star4 = "Star";
                star1Hidden = "None";
                star2Hidden = "None";
                star3Hidden = "None";
                star4Hidden = "None";

                if (potentielMax == 10)
                {
                    star5 = "StarHalfFull";
                    star5Hidden = "None";
                }
                else
                {
                    star5 = "Star";
                    star5Hidden = "StarHalf";
                }
            }
            else if (niveauMax == 10)
            {
                star1 = "Star";
                star2 = "Star";
                star3 = "Star";
                star4 = "Star";
                star5 = "Star";
                star1Hidden = "None";
                star2Hidden = "None";
                star3Hidden = "None";
                star4Hidden = "None";
                star5Hidden = "None";
            }
        }
    }


}
