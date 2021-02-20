using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class Profil2
    {
        internal static string FindProfil(string idCourse)
        {
            switch (idCourse)
            {
                // return "ProfilItt";
                // return "ProfilTtt";
                // return "ProfilPave";
                case "18":
                    return "ProfilPave";
                case "164":
                    return "ProfilPave";
                case "9":
                    return "ProfilPave";
                case "5":
                    return "ProfilItt";
                case "4":
                    return "ProfilPave";
                case "604":
                    return "ProfilPave";
                case "352":
                    return "ProfilItt";
                case "89":
                    return "ProfilItt";
                case "34":
                    return "ProfilPave";
                case "293":
                    return "ProfilItt";
                case "894":
                    return "ProfilItt";
                case "1272":
                    return "ProfilItt";
                case "172":
                    return "ProfilItt";
                case "1176":
                    return "ProfilPave";
                case "124":
                    return "ProfilPave";
                case "193":
                    return "ProfilItt";
                case "701":
                    return "ProfilPave";
                default:
                    return null;
            }
        }
    }
}
