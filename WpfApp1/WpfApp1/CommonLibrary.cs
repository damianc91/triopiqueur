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
    public class CommonLibrary
    {
        public const double DAILY_GAIN_JUNIOR = 0.04;
        public const double GAIN_STAGE_SPE1 = 0.68;
        public const double GAIN_STAGE_SPE2 = 0.42;
        public const double GAIN_STAGE_SPE3 = 0.28;
        public const double GAIN_BONUS_LESS80 = 0.04;
        public const double GAIN_BONUS_LESS85 = 0.03;
        public const double GAIN_BONUS_LESS90 = 0.01;
        public const double AGE_SENIOR = 23;
        public const double REGRESSION_30 = 0.3;
        public const double REGRESSION_31 = 0.6;
        public const double NB_TRAINING = 41;
        public static double minGrimp;
        public static double maxGrimp;
        public static double minVal;
        public static double maxVal;

        internal static string FindColor(string mark)
        {
            double number = Double.Parse(mark, CultureInfo.InvariantCulture);
            string color = "";

            if (number < 70.0)
            {
                color = "#FFF7FBFC";
            }
            else if (number < 80.0)
            {
                color = "#FF168A4C" ;
            }
            else if (number < 90.0)
            {
                color = "#FF21CC71" ;
            }
            else if (number <= 101.0)
            {
                color = "#FF28FC8B";
            }

            return color;
        }

        internal static void initializeLevelMaxMin()
        {
            minGrimp = FindPotentielMon(age: "19", pla: "56.88", mon: "66.88", des: "56.88", val: "56.88", end: "60.88", res: "60.88");
            maxGrimp = FindPotentielMon(age:"19", pla:"69.88", mon:"74.28", des:"69.88", val:"69.88", end: "69.88", res: "69.88", name: "Dobromir");
            minVal = FindPotentielVal(age:"19",  pla: "56.88",  mon: "56.88",  val:"66.88",  end: "60.88",  res: "60.88");
            maxVal = FindPotentielVal(age: "19", pla: "69.88", mon: "69.88", val: "74.00", end: "69.88", res: "69.88");
        }

        internal static string FindMyTeam(string idEquipe)
        {
            string[] ids = Answers.GetAllTeamsOwned().ToArray();
            string color = "#FFCC951F";

            if (idEquipe == ids[0])
            {
                color = "#FF21CC71";
            }
            if (ids.Length > 1)
            {
                if (idEquipe == ids[1])
                {
                    color = "#FF7CB1CC";
                }
                if (ids.Length > 1)
                {
                    if (idEquipe == ids[2])
                    {
                        color = "#FFCC1F44";
                    }
                }
            }

            return color;
        }

        internal static string GetSanteColor(double santeLevel)
        {
            if (santeLevel < 80.0)
            {
                return "#FFFDE13B";
            }
            else if (santeLevel < 90.0)
            {
                return "#FF168A4C";
            }
            else
            {
                return "#FF28FC8B";
            }
        }

        internal static string GetFormColor(double formLevel)
        {
            if (formLevel < 85.0)
            {
                return "#FFFDE13B";
            }
            else if (formLevel < 90.0)
            {
                return "#FF168A4C";
            }
            else
            {
                return "#FF28FC8B";
            }
        }


        static public void Train_2_90(ref double type1, ref double type2, ref double type3, int age)
        {
            //Log.Debug("30 ans");
            //Log.Debug((100.0 - 0.69 - (0.69 * Math.Max(0, 31 - 30)) + 0.6 + (0.3 * Math.Min(Math.Max(31 - 30, 0), 1))).ToString());
            //Log.Debug("29 ans");
            //Log.Debug((100.0 - 0.69 - (0.69 * Math.Max(0, 31 - 29)) + 0.6 + (0.3 * Math.Min(Math.Max(31 - 29, 0), 1))).ToString());

            double limit1 = -0.2 + 100.0 - 0.69 - (0.69 * Math.Max(0, 31 - age)) + 0.6 + (0.3 * Math.Min(Math.Max(31 - age, 0), 1));
            double limit2 = -0.2 + 100.0 - 0.43 - (0.43 * Math.Max(0, 31 - age)) + 0.6 + (0.3 * Math.Min(Math.Max(31 - age, 0), 1));

            if (type1 < 90.0)
            {
                type1 = Formula(type1);
            }
            else
            {
                if (type2 < 90.0)
                {
                    type2 = Formula(type2);
                }
                else
                {
                    if (type1 < limit1)
                    {
                        type1 = Formula(type1);
                    }
                    else
                    {
                        if (type2 < limit2)
                        {
                            type2 = Formula(type2);
                        }
                        else
                        {
                            type3 = Formula(type3);
                        }
                    }
                }
            }
        }

        static private double Formula(double niveau)
        {
            var offset = Math.Ceiling(((-1.0) * (0.0006 * niveau) + 0.0975 + Bonus(niveau)) * NB_TRAINING / 47.0 * 100.0) / 100.0;

            return niveau + offset;
        }

        static private double Bonus(double niveau)
        {
            double bonus = 0;

            if (niveau < 80)
            {
                bonus = GAIN_BONUS_LESS80;
            }
            else
            {
                if (niveau < 85)
                {
                    bonus = GAIN_BONUS_LESS85;
                }
                else
                {
                    if (niveau < 90)
                    {
                        bonus = GAIN_BONUS_LESS90;
                    }
                }
            }

            return bonus;
        }

        #region potentiel
        //static internal int FindPotentielSpr(string age, string pla, string val, string spr, string end, string res)
        //{
        //    double tempPla = double.Parse(pla, CultureInfo.InvariantCulture);
        //    double tempVal = double.Parse(val, CultureInfo.InvariantCulture);
        //    double tempSpr = double.Parse(spr, CultureInfo.InvariantCulture);
        //    double tempEnd = double.Parse(end, CultureInfo.InvariantCulture);
        //    double tempRes = double.Parse(res, CultureInfo.InvariantCulture);
        //    int tempAge = int.Parse(age);


        //    for (int i = 0; i <= PageCalendrier.joursAvantSaison; i++)
        //    {
        //        Train_2_90(ref tempSpr, ref tempRes, ref tempPla, tempAge);
        //        if (tempAge < AGE_SENIOR)
        //        {
        //            tempPla += DAILY_GAIN_JUNIOR;
        //            tempVal += DAILY_GAIN_JUNIOR;
        //            tempEnd += DAILY_GAIN_JUNIOR;
        //            tempRes += DAILY_GAIN_JUNIOR;
        //            tempSpr += DAILY_GAIN_JUNIOR;
        //        }
        //    }

        //    while (tempAge < 31)
        //    {
        //        tempAge++;

        //        // Perte age
        //        if (tempAge == 31)
        //        {
        //            tempPla -= REGRESSION_31;
        //            tempVal -= REGRESSION_31;
        //            tempEnd -= REGRESSION_31;
        //            tempRes -= REGRESSION_31;
        //            tempSpr -= REGRESSION_31;
        //        }
        //        else if (tempAge == 30)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempVal -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //            tempSpr -= REGRESSION_30;
        //        }

        //            tempSpr += GAIN_STAGE_SPE1;
        //            tempPla += GAIN_STAGE_SPE2;
        //            tempEnd += GAIN_STAGE_SPE3;

        //        for (int i = 0; i < 47; i++)
        //        {
        //            Train_2_90(ref tempSpr, ref tempRes, ref tempPla, tempAge);
        //            if (tempAge < AGE_SENIOR)
        //            {
        //                tempPla += DAILY_GAIN_JUNIOR;
        //                tempVal += DAILY_GAIN_JUNIOR;
        //                tempEnd += DAILY_GAIN_JUNIOR;
        //                tempRes += DAILY_GAIN_JUNIOR;
        //                tempSpr += DAILY_GAIN_JUNIOR;
        //            }
        //        }
        //    }

        //    //Log.Information("spr " + nom.ToString() + " " + ((14.0 * tempPla + 10.0 * tempVal + 50.0 * tempSpr + 2.0 * tempEnd + 24.0 * tempRes) / 100.0).ToString());


        //    return FindStarsSpr((14.0 * tempPla + 10.0 * tempVal + 50.0 * tempSpr + 2.0 * tempEnd + 24.0 * tempRes) / 100.0);
        //}

        //static internal int FindPotentielAgi(string age, string pla, string mon, string val, string agi, string end, string res)
        //{
        //    double tempPla = double.Parse(pla, CultureInfo.InvariantCulture);
        //    double tempVal = double.Parse(val, CultureInfo.InvariantCulture);
        //    double tempAgi = double.Parse(agi, CultureInfo.InvariantCulture);
        //    double tempMon = double.Parse(mon, CultureInfo.InvariantCulture);
        //    double tempEnd = double.Parse(end, CultureInfo.InvariantCulture);
        //    double tempRes = double.Parse(res, CultureInfo.InvariantCulture);
        //    int tempAge = int.Parse(age);

        //    for (int i = 0; i <= PageCalendrier.joursAvantSaison; i++)
        //    {
        //        Train_2_90(ref tempAgi, ref tempRes, ref tempMon, tempAge);
        //        if (tempAge < AGE_SENIOR)
        //        {
        //            tempPla += DAILY_GAIN_JUNIOR;
        //            tempVal += DAILY_GAIN_JUNIOR;
        //            tempEnd += DAILY_GAIN_JUNIOR;
        //            tempRes += DAILY_GAIN_JUNIOR;
        //            tempAgi += DAILY_GAIN_JUNIOR;
        //            tempMon += DAILY_GAIN_JUNIOR;
        //        }
        //    }

        //    while (tempAge < 31)
        //    {
        //        tempAge++;

        //        // Perte age
        //        if (tempAge == 31)
        //        {
        //            tempPla -= REGRESSION_31;
        //            tempVal -= REGRESSION_31;
        //            tempEnd -= REGRESSION_31;
        //            tempRes -= REGRESSION_31;
        //            tempAgi -= REGRESSION_31;
        //            tempMon -= REGRESSION_31;
        //        }
        //        else if (tempAge == 30)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempVal -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //            tempAgi -= REGRESSION_30;
        //            tempMon -= REGRESSION_30;
        //        }

        //        // Stage
        //        //if (tempAge < 25)
        //        //{
        //            tempAgi += GAIN_STAGE_SPE1;
        //            tempRes += GAIN_STAGE_SPE2;
        //            tempMon += GAIN_STAGE_SPE3;
        //        //}
        //        //else
        //        //{
        //        //    tempEnd += GAIN_STAGE_SPE1;
        //        //    tempRes += GAIN_STAGE_SPE2;
        //        //    tempPla += GAIN_STAGE_SPE3;
        //        //}

        //        for (int i = 0; i < 47; i++)
        //        {
        //            Train_2_90(ref tempAgi, ref tempRes, ref tempMon, tempAge);
        //            if (tempAge < AGE_SENIOR)
        //            {
        //                tempPla += DAILY_GAIN_JUNIOR;
        //                tempVal += DAILY_GAIN_JUNIOR;
        //                tempEnd += DAILY_GAIN_JUNIOR;
        //                tempRes += DAILY_GAIN_JUNIOR;
        //                tempAgi += DAILY_GAIN_JUNIOR;
        //                tempMon += DAILY_GAIN_JUNIOR;
        //            }
        //        }
        //    }
        //    //Log.Information("agi " +  nom.ToString() + " " + ((4.0 * tempPla + 6.0 * tempMon + 3.0 * tempVal + 55.0 * tempAgi + 32.0 * tempRes) / 100.0).ToString());

        //    return FindStarsAgi((4.0 * tempPla + 6.0 * tempMon + 3.0 * tempVal + 55.0 * tempAgi + 32.0 * tempRes) / 100.0);
        //}

        //static internal int FindPotentielClm(string age, string pla, string clm, string spr, string end, string res)
        //{
        //    double tempPla = double.Parse(pla, CultureInfo.InvariantCulture);
        //    double tempClm = double.Parse(clm, CultureInfo.InvariantCulture);
        //    double tempSpr = double.Parse(spr, CultureInfo.InvariantCulture);
        //    double tempEnd = double.Parse(end, CultureInfo.InvariantCulture);
        //    double tempRes = double.Parse(res, CultureInfo.InvariantCulture);
        //    int tempAge = int.Parse(age);

        //    for (int i = 0; i <= PageCalendrier.joursAvantSaison; i++)
        //    {
        //        Train_2_90(ref tempClm, ref tempRes, ref tempPla, tempAge);
        //        if (tempAge < AGE_SENIOR)
        //        {
        //            tempPla += DAILY_GAIN_JUNIOR;
        //            tempEnd += DAILY_GAIN_JUNIOR;
        //            tempRes += DAILY_GAIN_JUNIOR;
        //            tempClm += DAILY_GAIN_JUNIOR;
        //            tempSpr += DAILY_GAIN_JUNIOR;
        //        }
        //    }

        //    while (tempAge < 31)
        //    {
        //        tempAge++;

        //        // Perte age
        //        if (tempAge == 31)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //            tempClm -= REGRESSION_30;
        //            tempSpr -= REGRESSION_30;
        //        }
        //        else if (tempAge == 30)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //            tempClm -= REGRESSION_30;
        //            tempSpr -= REGRESSION_30;
        //        }


        //            tempClm += GAIN_STAGE_SPE1;
        //            tempRes += GAIN_STAGE_SPE2;
        //            tempPla += GAIN_STAGE_SPE3;


        //        for (int i = 0; i < 47; i++)
        //        {
        //            Train_2_90(ref tempClm, ref tempRes, ref tempPla, tempAge);
        //            if (tempAge < AGE_SENIOR)
        //            {
        //                tempPla += DAILY_GAIN_JUNIOR;
        //                tempEnd += DAILY_GAIN_JUNIOR;
        //                tempRes += DAILY_GAIN_JUNIOR;
        //                tempClm += DAILY_GAIN_JUNIOR;
        //                tempSpr += DAILY_GAIN_JUNIOR;
        //            }
        //        }
        //    }

        //    //Log.Information("clm " + nom.ToString() + " " + ((13.0 * tempPla + 49.0 * tempClm + 7.0 * tempSpr + 31.0 * tempRes)/100).ToString());

        //    return FindStarsClm((13.0 * tempPla + 49.0 * tempClm + 7.0 * tempSpr + 31.0 * tempRes) / 100.0);
        //}

        //static internal int FindPotentielPav(string age, string pla, string pav, string val, string end, string res)
        //{
        //    double tempPla = double.Parse(pla, CultureInfo.InvariantCulture);
        //    double tempVal = double.Parse(val, CultureInfo.InvariantCulture);
        //    double tempPav = double.Parse(pav, CultureInfo.InvariantCulture);
        //    double tempEnd = double.Parse(end, CultureInfo.InvariantCulture);
        //    double tempRes = double.Parse(res, CultureInfo.InvariantCulture);
        //    int tempAge = int.Parse(age);

        //    for (int i = 0; i <= PageCalendrier.joursAvantSaison; i++)
        //    {
        //        Train_2_90(ref tempPav, ref tempEnd, ref tempPla, tempAge);
        //        if (tempAge < AGE_SENIOR)
        //        {
        //            tempPla += DAILY_GAIN_JUNIOR;
        //            tempVal += DAILY_GAIN_JUNIOR;
        //            tempEnd += DAILY_GAIN_JUNIOR;
        //            tempRes += DAILY_GAIN_JUNIOR;
        //            tempPav += DAILY_GAIN_JUNIOR;
        //        }
        //    }

        //    while (tempAge < 31)
        //    {
        //        tempAge++;

        //        // Perte age
        //        if (tempAge == 31)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempVal -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //            tempPav -= REGRESSION_30;
        //        }
        //        else if (tempAge == 30)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempVal -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //            tempPav -= REGRESSION_30;
        //        }


        //            tempPav += GAIN_STAGE_SPE1;
        //            tempPla += GAIN_STAGE_SPE2;
        //            tempEnd += GAIN_STAGE_SPE3;


        //        for (int i = 0; i < 47; i++)
        //        {
        //            Train_2_90(ref tempPav, ref tempEnd, ref tempPla, tempAge);
        //            if (tempAge < AGE_SENIOR)
        //            {
        //                tempPla += DAILY_GAIN_JUNIOR;
        //                tempVal += DAILY_GAIN_JUNIOR;
        //                tempEnd += DAILY_GAIN_JUNIOR;
        //                tempRes += DAILY_GAIN_JUNIOR;
        //                tempPav += DAILY_GAIN_JUNIOR;
        //            }
        //        }
        //    }
        //    //Log.Information("pav " + nom.ToString() + " " + ((18.0 * tempPla + 8.0 * tempVal + 42.0 * tempPav + 19.0 * tempEnd + 14.0 * tempRes) / 100.0).ToString());

        //    return FindStarsPav((18.0 * tempPla + 8.0 * tempVal + 42.0 * tempPav + 19.0 * tempEnd + 14.0 * tempRes) / 100.0);
        //}

        //static internal int FindPotentielPla(string age, string pla, string val, string end, string res)
        //{
        //    double tempPla = double.Parse(pla, CultureInfo.InvariantCulture);
        //    double tempVal = double.Parse(val, CultureInfo.InvariantCulture);
        //    double tempEnd = double.Parse(end, CultureInfo.InvariantCulture);
        //    double tempRes = double.Parse(res, CultureInfo.InvariantCulture);
        //    int tempAge = int.Parse(age);

        //    for (int i = 1; i <= PageCalendrier.joursAvantSaison; i++)
        //    {
        //        Train_2_90(ref tempPla, ref tempEnd, ref tempVal, tempAge);
        //        if (tempAge < AGE_SENIOR)
        //        {
        //            tempPla += DAILY_GAIN_JUNIOR;
        //            tempVal += DAILY_GAIN_JUNIOR;
        //            tempEnd += DAILY_GAIN_JUNIOR;
        //            tempRes += DAILY_GAIN_JUNIOR;
        //        }
        //    }

        //    while (tempAge < 31)
        //    {
        //        tempAge++;

        //        // Perte age
        //        if (tempAge == 31)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempVal -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //        }
        //        else if (tempAge == 30)
        //        {
        //            tempPla -= REGRESSION_30;
        //            tempVal -= REGRESSION_30;
        //            tempEnd -= REGRESSION_30;
        //            tempRes -= REGRESSION_30;
        //        }


        //        tempPla += GAIN_STAGE_SPE1;
        //        tempVal += GAIN_STAGE_SPE2;
        //        tempEnd += GAIN_STAGE_SPE3;


        //        for (int i = 0; i < 47; i++)
        //        {
        //            Train_2_90(ref tempPla, ref tempEnd, ref tempVal, tempAge);
        //            if (tempAge < AGE_SENIOR)
        //            {
        //                tempPla += DAILY_GAIN_JUNIOR;
        //                tempVal += DAILY_GAIN_JUNIOR;
        //                tempEnd += DAILY_GAIN_JUNIOR;
        //                tempRes += DAILY_GAIN_JUNIOR;
        //            }
        //        }
        //    }
        //    //Log.Information("Bar " + nom.ToString() + " " + ((64.0 * tempPla + 13.0 * tempVal + 15.0 * tempEnd + 8.0 * tempRes)/100).ToString());

        //    return FindStarsBar((64.0 * tempPla + 13.0 * tempVal + 15.0 * tempEnd + 8.0 * tempRes) / 100.0);
        //}

        #endregion

        #region potentiel2

        static internal double FindPotentielVal(string age, string pla, string mon, string val, string end, string res, int joursAvantSaison = 47)
        {
            double tempPla = double.Parse(pla, CultureInfo.InvariantCulture);
            double tempVal = double.Parse(val, CultureInfo.InvariantCulture);
            double tempMon = double.Parse(mon, CultureInfo.InvariantCulture);
            double tempEnd = double.Parse(end, CultureInfo.InvariantCulture);
            double tempRes = double.Parse(res, CultureInfo.InvariantCulture);
            int tempAge = int.Parse(age);


            for (int i = 0; i < joursAvantSaison; i++)
            {
                Train_2_90(ref tempVal, ref tempEnd, ref tempRes, tempAge);
                if (tempAge < AGE_SENIOR)
                {
                    tempPla += DAILY_GAIN_JUNIOR;
                    tempVal += DAILY_GAIN_JUNIOR;
                    tempEnd += DAILY_GAIN_JUNIOR;
                    tempRes += DAILY_GAIN_JUNIOR;
                    tempMon += DAILY_GAIN_JUNIOR;
                }
            }

            while (tempAge < 31)
            {
                tempAge++;

                // Perte age
                if (tempAge == 31)
                {
                    tempPla -= REGRESSION_31;
                    tempVal -= REGRESSION_31;
                    tempEnd -= REGRESSION_31;
                    tempRes -= REGRESSION_31;
                    tempMon -= REGRESSION_31;
                }
                else if (tempAge == 30)
                {
                    tempPla -= REGRESSION_30;
                    tempVal -= REGRESSION_30;
                    tempEnd -= REGRESSION_30;
                    tempRes -= REGRESSION_30;
                    tempMon -= REGRESSION_30;
                }


                tempVal += GAIN_STAGE_SPE1;
                tempEnd += GAIN_STAGE_SPE2;
                tempRes += GAIN_STAGE_SPE3;

                for (int i = 0; i < 47; i++)
                {
                    Train_2_90(ref tempVal, ref tempEnd, ref tempRes, tempAge);
                    if (tempAge < AGE_SENIOR)
                    {
                        tempPla += DAILY_GAIN_JUNIOR;
                        tempVal += DAILY_GAIN_JUNIOR;
                        tempEnd += DAILY_GAIN_JUNIOR;
                        tempRes += DAILY_GAIN_JUNIOR;
                        tempMon += DAILY_GAIN_JUNIOR;
                    }
                }
            }

            //Log.Information("val " + nom.ToString() + " " + ((17.0 * tempPla + 4.0 * tempMon + 47.0 * tempVal + 16.0 * tempEnd + 15.0 * tempRes) / 100.0).ToString());

            return FormulaVal(tempPla, tempMon, tempVal, tempEnd, tempRes);
        }

        private static double FormulaVal(double tempPla, double tempMon, double tempVal, double tempEnd, double tempRes)
        {
            var r = (15.0 * tempPla + 5.0 * tempMon + 45.0 * tempVal + 20.0 * tempEnd + 15.0 * tempRes) / 100.0;
            return r;
        }

        static internal double FindPotentielMon(string age, string pla, string mon, string des, string val, string end, string res, int joursAvantSaison = 47, string name="")
        {
            double tempPla = double.Parse(pla, CultureInfo.InvariantCulture);
            double tempVal = double.Parse(val, CultureInfo.InvariantCulture);
            double tempMon = double.Parse(mon, CultureInfo.InvariantCulture);
            double tempDes = double.Parse(des, CultureInfo.InvariantCulture);
            double tempEnd = double.Parse(end, CultureInfo.InvariantCulture);
            double tempRes = double.Parse(res, CultureInfo.InvariantCulture);
            int tempAge = int.Parse(age);

            if (name.Contains("Dobromir"))
            {
                //Log.Debug("");
            }


            for (int i = 0; i < joursAvantSaison; i++)
            {
                Train_2_90(ref tempMon, ref tempRes, ref tempEnd, tempAge);
                if (tempAge < AGE_SENIOR)
                {
                    tempPla += DAILY_GAIN_JUNIOR;
                    tempVal += DAILY_GAIN_JUNIOR;
                    tempEnd += DAILY_GAIN_JUNIOR;
                    tempRes += DAILY_GAIN_JUNIOR;
                    tempMon += DAILY_GAIN_JUNIOR;
                    tempDes += DAILY_GAIN_JUNIOR;
                }
            }

            if (name.Contains("Dobromir"))
            {
                //Log.Debug("age " + (FormulaMon(tempPla, tempMon, tempDes, tempVal, tempEnd, tempRes)).ToString());
            }


            while (tempAge < 31)
            {
                tempAge++;

                // Perte age
                if (tempAge == 31)
                {
                    tempPla -= REGRESSION_31;
                    tempVal -= REGRESSION_31;
                    tempEnd -= REGRESSION_31;
                    tempRes -= REGRESSION_31;
                    tempMon -= REGRESSION_31;
                    tempDes -= REGRESSION_31;
                }
                else if (tempAge == 30)
                {
                    tempPla -= REGRESSION_30;
                    tempVal -= REGRESSION_30;
                    tempEnd -= REGRESSION_30;
                    tempRes -= REGRESSION_30;
                    tempMon -= REGRESSION_30;
                    tempDes -= REGRESSION_30;
                }

  
                tempMon += GAIN_STAGE_SPE1;
                tempRes += GAIN_STAGE_SPE2;
                tempDes += GAIN_STAGE_SPE3;


                for (int i = 0; i < 47; i++)
                {
                    Train_2_90(ref tempMon, ref tempRes, ref tempEnd, tempAge);
                    if (tempAge < AGE_SENIOR)
                    {
                        tempPla += DAILY_GAIN_JUNIOR;
                        tempVal += DAILY_GAIN_JUNIOR;
                        tempEnd += DAILY_GAIN_JUNIOR;
                        tempRes += DAILY_GAIN_JUNIOR;
                        tempMon += DAILY_GAIN_JUNIOR;
                        tempDes += DAILY_GAIN_JUNIOR;
                    }
                }
            }
            Log.Information("Gr " + name.ToString() + " tempPla " + tempPla.ToString("F2") + " tempMon " + tempMon.ToString("F2") + " tempDes " + tempDes.ToString("F2") + " tempVal " + tempVal.ToString("F2") + " tempEnd " + tempEnd.ToString("F2") + " tempRes  " + tempRes.ToString("F2"));
            //Log.Information("Gr " + name.ToString() + " " + ((10.0 * tempPla + 44.0 * tempMon + 6.0 * tempDes + 8.0 * tempVal + 14.0 * tempEnd + 18.0 * tempRes) / 100.0));

            return FormulaMon(tempPla, tempMon, tempDes, tempVal, tempEnd, tempRes);
        }

        public static int FindStarsGrimp(double average)
        {
            return (int)(Math.Max((average - minGrimp), 0) * 200 / (maxGrimp - minGrimp)); 
        }

        public static int FindStarsVal(double average)
        {
            var r = (int)(Math.Max((average - minVal), 0) * 200 / (maxVal - minVal));
            return r;
        }

        private static double FormulaMon(double tempPla, double tempMon, double tempDes, double tempVal, double tempEnd, double tempRes)
        {
            return (5.0 * tempPla + 45.0 * tempMon + 5.0 * tempDes + 10.0 * tempVal + 15.0 * tempEnd + 20.0 * tempRes) / 100.0;
        }

        static internal int FindPotentielMax(int potentielBaroudeur = 0, int potentielGrimpeur = 0, int potentielVallon = 0, int potentielPave = 0, int potentielAgilite = 0, int potentielClm = 0, int potentielSpr = 0)
        {
            int[] t = new int[] { potentielBaroudeur, potentielGrimpeur, potentielVallon, potentielPave, potentielAgilite, potentielClm, potentielSpr };
            return t.Max();
        }

        #endregion

        #region find_level
        //static internal int FindLevelSpr(string pla, string val, string spr, string end, string res)
        //{
        //    return FindStarsSpr((14.0 * double.Parse(pla, CultureInfo.InvariantCulture) + 10.0 * double.Parse(val, CultureInfo.InvariantCulture) + 50.0 * double.Parse(spr, CultureInfo.InvariantCulture) + 2.0 * double.Parse(end, CultureInfo.InvariantCulture) + 24.0 * double.Parse(res, CultureInfo.InvariantCulture)) / 100.0);
        //}

        //static internal int FindLevelAgi(string pla, string val, string mon, string agi, string res)
        //{
        //    return FindStarsAgi((4.0 * double.Parse(pla, CultureInfo.InvariantCulture) + 6.0 * double.Parse(mon, CultureInfo.InvariantCulture) + 3.0 * double.Parse(val, CultureInfo.InvariantCulture) + 55.0 * double.Parse(agi, CultureInfo.InvariantCulture) + 32.0 * double.Parse(res, CultureInfo.InvariantCulture)) / 100.0);
        //}

        //static internal int FindLevelClm(string pla, string spr, string clm, string res)
        //{
        //    return FindStarsClm((13.0 * double.Parse(pla, CultureInfo.InvariantCulture) + 49.0 * double.Parse(clm, CultureInfo.InvariantCulture) + 7.0 * double.Parse(spr, CultureInfo.InvariantCulture) + 31.0 * double.Parse(res, CultureInfo.InvariantCulture)) / 100.0);
        //}

        //static internal int FindLevelPav(string pla, string val, string pav, string end, string res)
        //{
        //    return FindStarsPav((18.0 * double.Parse(pla, CultureInfo.InvariantCulture) + 8.0 * double.Parse(val, CultureInfo.InvariantCulture) + 42.0 * double.Parse(pav, CultureInfo.InvariantCulture) + 19.0 * double.Parse(end, CultureInfo.InvariantCulture) + 14.0 * double.Parse(res, CultureInfo.InvariantCulture)) / 100.0);
        //}

        //static internal int FindLevelPla(string pla, string val, string end, string res)
        //{
        //    return FindStarsBar((64.0 * double.Parse(pla, CultureInfo.InvariantCulture) + 13.0 * double.Parse(val, CultureInfo.InvariantCulture) + 15.0 * double.Parse(end, CultureInfo.InvariantCulture) + 8.0 * double.Parse(res, CultureInfo.InvariantCulture)) / 100.0);
        //}

        #endregion

        #region find_level2

        static internal double FindLevelVal(string pla, string mon, string val, string end, string res)
        {
            var r = FormulaVal(double.Parse(pla, CultureInfo.InvariantCulture), double.Parse(mon, CultureInfo.InvariantCulture), double.Parse(val, CultureInfo.InvariantCulture), double.Parse(end, CultureInfo.InvariantCulture), double.Parse(res, CultureInfo.InvariantCulture));
            return r;
        }


        static internal double FindLevelMon(string pla, string mon, string val, string des, string end, string res)
        {
            return FormulaMon(double.Parse(pla, CultureInfo.InvariantCulture), double.Parse(mon, CultureInfo.InvariantCulture), double.Parse(des, CultureInfo.InvariantCulture), double.Parse(val, CultureInfo.InvariantCulture), double.Parse(end, CultureInfo.InvariantCulture), double.Parse(res, CultureInfo.InvariantCulture));
        }


        static internal int FindLevelMax(int niveauBaroudeur=0, int niveauGrimpeur = 0, int niveauVallon = 0, int niveauPave = 0, int niveauAgilite = 0, int niveauClm = 0, int niveauSpr = 0)
        {
            int[] t = new int[] { niveauBaroudeur, niveauGrimpeur, niveauVallon, niveauPave, niveauAgilite, niveauClm, niveauSpr };
            return t.Max();
        }

        #endregion
    }
}
