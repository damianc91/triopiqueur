using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.answers;
using WpfApp1.PagesLeft;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageClassements.xaml
    /// </summary>
    public partial class PageCalendrier : Page
    {
        public List<Calendrier> calendriers = new List<Calendrier>();
        public string folderImages = "C:\\Users\\Damian\\source\\repos\\WpfApp1\\WpfApp1\\";
        public string folderVm = "https://www.velo-manager.net/";
        public static int joursAvantSaison { set; get; }

        public PageCalendrier()
        {
            InitializeComponent();

            Info info;
            Calendrier cal;
            Resultats res;
            Resultats cals = Answers.FindPageResultats(Requests.PageResultatsSimple());
            cals.resultatsCoursesDispos.Reverse();

            foreach (var resultatsCourseDispo in cals.resultatsCoursesDispos)
            {
                res = Answers.FindPageResultats(Requests.PageResultats(resultatsCourseDispo.id, "1"));

                cal = new Calendrier(res);

                cal.profil1 = folderImages + "images\\" + Profil1.FindProfil(cal.idCourse) + ".png";
                cal.profil2 = folderImages + "images\\" + Profil2.FindProfil(cal.idCourse) + ".png";

                cal.dateAsText = cal.date.ToString("dd/MM", DateTimeFormatInfo.InvariantInfo);

                cal.image = folderVm + cal.image;
                cal.inscriptionVisibility = "Hidden";

                calendriers.Add(cal);
            }

            var cal2 = Answers.FindPageCalendrier(Requests.PageCalendrier());



            for (int i = 0; i < cal2.Count; i++)
            {
                try
                {
                    calendriers.Remove(calendriers.Where(c => cal2[i].nom.Trim().Contains(c.nom.Trim())).First());
                }
                catch (Exception) { }

                try
                {
                    if (cal2[i].typeCourse.Contains("couronne") || cal2[i].typeCourse.Contains("selection") || cal2[i].typeCourse.Contains("monde"))
                    {
                        cal2[i].typeCourse = folderImages + cal2[i].typeCourse;
                    }
                    else if (cal2[i].typeCourse.Contains("bis"))
                    {
                        cal2[i].typeCourse = folderImages + "icones\\Vert.png";
                    }
                }
                catch (Exception)
                {
                    cal2[i].typeCourse = folderImages + "icones\\Bleu.png";
                }


                if (cal2[i].registered == "true")
                {
                    cal2[i].registered = "CheckCircleOutline";
                    cal2[i].registeredColor = "#FF21CC71";
                    cal2[i].registeredTooltip = "Inscrit";
                }
                else
                {
                    cal2[i].registered = "HighlightOff";
                    cal2[i].registeredColor = "#FFED3C36";
                    cal2[i].registeredTooltip = "Non inscrit";
                }

                cal2[i].profil1 = folderImages + "images\\" + Profil1.FindProfil(cal2[i].idCourse) + ".png";
                cal2[i].profil2 = folderImages + "images\\" + Profil2.FindProfil(cal2[i].idCourse) + ".png";

                cal2[i].dateAsText = cal2[i].date.ToString("dd/MM", DateTimeFormatInfo.InvariantInfo);

                info = Answers.FindPageInfo(Requests.PageInfo(cal2[i].idCourse));

                cal2[i].image = folderVm + info.image;

                cal2[i].inscriptionVisibility = "Visible";

                calendriers.Add(cal2[i]);
            }

            calendriers = calendriers.OrderBy(c => c.date).ToList<Calendrier>();

            try
            {
                joursAvantSaison = (calendriers.Last().date - DateTime.Now).Days;
            }
            catch (Exception) 
            {
                joursAvantSaison = 0;
            }


            Lvcalendriers.ItemsSource = calendriers;
        }


        private void btnResults(object sender, RoutedEventArgs e)
        {
            var cal = ((sender as Button).DataContext as Calendrier);
            PageEngagements p = new PageEngagements();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);
        }

        private void btnTactic(object sender, RoutedEventArgs e)
        {
            var cal = ((sender as Button).DataContext as Calendrier);
            PageTactique p = new PageTactique();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);
        }

        private void btnRegister(object sender, RoutedEventArgs e)
        {
            var cal = ((sender as Button).DataContext as Calendrier);
            PageResultats p = new PageResultats();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);
        }
    }
}
