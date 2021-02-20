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
using System.Windows.Threading;
using WpfApp1.answers;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageVMMagazine.xaml
    /// </summary>
    public partial class PageTransfertsJuniors : Page
    {
        public double sizeFrame;
        public List<TransfertJuniors> allTransfertsJuniors = new List<TransfertJuniors>();
        public string folderImages = "C:\\Users\\Damian\\source\\repos\\WpfApp1\\WpfApp1\\icones\\";
        public string folderVm = "https://www.velo-manager.net/";


        public PageTransfertsJuniors()
        {
            InitializeComponent();

            allTransfertsJuniors = Answers.FindPageTranfertsJuniors(Requests.PageTranfertsJuniors());

            foreach (var item in allTransfertsJuniors)
            {
                CoureurIndividual coureur = Answers.FindPageCoureur(Requests.PageCoureur(item.idCoureur));


                item.monEquipe = CommonLibrary.FindMyTeam(item.idEquipe);
                item.nomCoureur += " ";
                item.pays = folderVm + item.pays;
                item.spe = coureur.spe;
                item.moyenne = Math.Sqrt(double.Parse(coureur.salaire, CultureInfo.InvariantCulture) + 2500.0).ToString("F1");
            }

            Lvtransferts.ItemsSource = allTransfertsJuniors;

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromMilliseconds(500);
            LiveTime.Tick += updateSize;
            LiveTime.Start();
        }

        private void updateSize(object sender, EventArgs e)
        {
            Home objMainWindows = (Home)Window.GetWindow(this);

            try
            {
                if (sizeFrame != objMainWindows.columnFrameLeft.ActualWidth)
                {
                    sizeFrame = objMainWindows.columnFrameLeft.ActualWidth;

                    GridView gView = Lvtransferts.View as GridView;
                    foreach (GridViewColumn c in gView.Columns)
                    {
                        switch (c.Header.ToString())
                        {
                            case "NOM":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 24;
                                break;
                            case "PAYS":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 5;
                                break;
                            case "EQUIPE":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 29;
                                break;
                            case "PRIX":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 14;
                                break;
                            case "SPE":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 14;
                                break;
                            case "MOYENNE":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 14;
                                break;
                            default:
                                c.Width = 0.0;
                                break;
                        }
                    }
                }
            }
            catch (Exception) { }
        }


        private void SelectRow(object sender, SelectionChangedEventArgs e)
        {
            Lvtransferts.SelectedItem = null;
        }

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            switch (headerClicked.Content)
            {
                case "NOM":
                    Lvtransferts.ItemsSource = allTransfertsJuniors.OrderBy(t => t.nomCoureur);
                    break;
                case "EQUIPE":
                    Lvtransferts.ItemsSource = allTransfertsJuniors.OrderBy(t => t.nomEquipe);
                    break;
                case "PRIX":
                    Lvtransferts.ItemsSource = allTransfertsJuniors.OrderByDescending(t => int.Parse(t.prix.Replace(" ", "")));
                    break;
                case "SPE":
                    Lvtransferts.ItemsSource = allTransfertsJuniors.OrderBy(t => t.spe);
                    break;
                case "MOYENNE":
                    Lvtransferts.ItemsSource = allTransfertsJuniors.OrderByDescending(t => double.Parse(t.moyenne, CultureInfo.InvariantCulture));
                    break;
                default:
                    break;
            }
        }

    }
}
