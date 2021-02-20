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
    public partial class PageTransfertsDaily : Page
    {
        public double sizeFrame;
        public List<TransfertDaily> allTransfertsDaily = new List<TransfertDaily>();
        public string folderImages = "C:\\Users\\Damian\\source\\repos\\WpfApp1\\WpfApp1\\icones\\";
        public string folderVm = "https://www.velo-manager.net/";


        public PageTransfertsDaily()
        {
            InitializeComponent();

            allTransfertsDaily = Answers.FindPageTranfertsDaily(Requests.PageTranfertsDaily());

            foreach (var item in allTransfertsDaily)
            {
                CoureurIndividual coureur = Answers.FindPageCoureur(Requests.PageCoureur(item.idCoureur));

                item.nomCoureur += " ";
                item.spe = coureur.spe;
                item.pays = folderVm + item.pays;
                item.monEquipe = CommonLibrary.FindMyTeam(coureur.idEquipe);
                item.champNat = folderVm + coureur.champNat;

                if (coureur.medailles.Count > 0)
                {
                    item.medaille1 = folderVm + coureur.medailles[0].lien;
                    if (coureur.medailles.Count > 1)
                    {
                        item.medaille2 = folderVm + coureur.medailles[1].lien;
                    }
                }

                if (coureur.couleurCarte.Contains("JEUNE"))
                {
                    item.couleurCarte = folderVm + coureur.couleurCarte;
                }
            }

            Lvtransferts.ItemsSource = allTransfertsDaily;

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
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 19;
                                break;
                            case "PAYS":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 5;
                                break;
                            case "AGE":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 10;
                                break;
                            case "VENDEUR":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 20;
                                break;
                            case "ACHETEUR":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 20;
                                break;
                            case "PRIX":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 13;
                                break;
                            case "SPE":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 13;
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
                case "VENDEUR":
                    Lvtransferts.ItemsSource = allTransfertsDaily.OrderBy(t => t.nomEquipeVendeur);
                    break;
                case "ACHETEUR":
                    Lvtransferts.ItemsSource = allTransfertsDaily.OrderBy(t => t.nomEquipeAcheteur);
                    break;
                case "PRIX":
                    Lvtransferts.ItemsSource = allTransfertsDaily.OrderByDescending(t => int.Parse(t.prix.Replace(" ", "")));
                    break;
                case "SPE":
                    Lvtransferts.ItemsSource = allTransfertsDaily.OrderBy(t => t.spe);
                    break;
                default:
                    break;
            }
        }
    }
}
