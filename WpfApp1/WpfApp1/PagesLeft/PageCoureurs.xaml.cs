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
    /// Logique d'interaction pour PageCoureurs.xaml
    /// </summary>
    public partial class PageCoureurs : Page
    {
        public double sizeFrame;
        public Coureurs allCoureurs = new Coureurs();
        public string folderImages = "C:\\Users\\Damian\\source\\repos\\WpfApp1\\WpfApp1\\icones\\";
        public string folderVm = "https://www.velo-manager.net/";
        private bool jAsc;
        private bool ageAsc;
        private bool ucvAsc;
        private bool santeAsc;
        private bool formeAsc;

        public PageCoureurs(string idTeam)
        {
            InitializeComponent();

            List<Coureurs> itemfertsToHide = new List<Coureurs>();


            allCoureurs = Answers.FindPageCoureurs(Requests.PageCoureurs(idTeam));

            CommonLibrary.initializeLevelMaxMin();

            foreach (Coureur item in allCoureurs.coureur)
            {
                //item.potentielBaroudeur = CommonLibrary.FindPotentielPla(item.age, item.pla, item.val, item.end, item.res);
                //item.potentielPave = CommonLibrary.FindPotentielPav(item.age, item.pla, item.pav, item.val, item.end, item.res);
                //item.potentielClm = CommonLibrary.FindPotentielClm(item.age, item.pla, item.clm, item.spr, item.end, item.res);
                //item.potentielAgilite = CommonLibrary.FindPotentielAgi(item.age, item.pla, item.mon, item.val, item.agi, item.end, item.res);
                //item.potentielSpr = CommonLibrary.FindPotentielSpr(item.age, item.pla, item.val, item.spr, item.end, item.res);
                item.potentielGrimpeur = CommonLibrary.FindStarsGrimp(CommonLibrary.FindPotentielMon(item.age, item.pla, item.mon, item.des, item.val, item.end, item.res, joursAvantSaison: PageCalendrier.joursAvantSaison, name:item.nom));
                item.potentielVallon = CommonLibrary.FindStarsVal(CommonLibrary.FindPotentielVal(item.age, item.pla, item.mon, item.val, item.end, item.res, joursAvantSaison:PageCalendrier.joursAvantSaison));
                item.potentielMax = CommonLibrary.FindPotentielMax(item.potentielBaroudeur, item.potentielGrimpeur, item.potentielVallon, item.potentielPave, item.potentielAgilite, item.potentielClm, item.potentielSpr);
                item.potentielMaxString = item.potentielMax.ToString();

                item.pays = folderVm + item.pays;

                item.plaRound = Math.Round(double.Parse(item.pla, CultureInfo.InvariantCulture)).ToString();
                item.monRound = Math.Round(double.Parse(item.mon, CultureInfo.InvariantCulture)).ToString();
                item.desRound = Math.Round(double.Parse(item.des, CultureInfo.InvariantCulture)).ToString();
                item.valRound = Math.Round(double.Parse(item.val, CultureInfo.InvariantCulture)).ToString();
                item.pavRound = Math.Round(double.Parse(item.pav, CultureInfo.InvariantCulture)).ToString();
                item.agiRound = Math.Round(double.Parse(item.agi, CultureInfo.InvariantCulture)).ToString();
                item.clmRound = Math.Round(double.Parse(item.clm, CultureInfo.InvariantCulture)).ToString();
                item.sprRound = Math.Round(double.Parse(item.spr, CultureInfo.InvariantCulture)).ToString();
                item.endRound = Math.Round(double.Parse(item.end, CultureInfo.InvariantCulture)).ToString();
                item.resRound = Math.Round(double.Parse(item.res, CultureInfo.InvariantCulture)).ToString();

                item.plaColor = CommonLibrary.FindColor(item.pla);
                item.monColor = CommonLibrary.FindColor(item.mon);
                item.desColor = CommonLibrary.FindColor(item.des);
                item.valColor = CommonLibrary.FindColor(item.val);
                item.pavColor = CommonLibrary.FindColor(item.pav);
                item.agiColor = CommonLibrary.FindColor(item.agi);
                item.clmColor = CommonLibrary.FindColor(item.clm);
                item.sprColor = CommonLibrary.FindColor(item.spr);
                item.endColor = CommonLibrary.FindColor(item.end);
                item.resColor = CommonLibrary.FindColor(item.res);

                //item.niveauBaroudeur = CommonLibrary.FindLevelPla(item.pla, item.val, item.end, item.res);
                //item.niveauPave = CommonLibrary.FindLevelPav(item.pla, item.pav, item.val, item.end, item.res);
                //item.niveauClm = CommonLibrary.FindLevelClm(item.pla, item.spr, item.clm, item.res);
                //item.niveauAgilite = CommonLibrary.FindLevelAgi(item.pla, item.val, item.mon, item.agi, item.res);
                //item.niveauSpr = CommonLibrary.FindLevelSpr(item.pla, item.val, item.spr, item.end, item.res);

                var v = CommonLibrary.FindLevelMon(item.pla, item.mon, item.des, item.val, item.end, item.res);
                item.niveauGrimpeur = CommonLibrary.FindStarsGrimp(v);
                //item.niveauGrimpeur = CommonLibrary.FindStarsGrimp(CommonLibrary.FindLevelMon(item.pla, item.mon, item.des, item.val, item.end, item.res));

                var val2 = CommonLibrary.FindLevelVal(item.pla, item.mon, item.val, item.end, item.res);
                item.niveauVallon = CommonLibrary.FindStarsVal(val2);
                item.niveauMax = CommonLibrary.FindLevelMax(item.niveauBaroudeur, item.niveauGrimpeur, item.niveauVallon, item.niveauPave, item.niveauAgilite, item.niveauClm, item.niveauSpr);
                item.niveauMaxString = item.niveauMax.ToString();

                item.UpdateStars();

                item.aVendre = folderVm + item.aVendre;


                CoureurIndividual coureur = Answers.FindPageCoureur(Requests.PageCoureur(item.id));
                item.lenghtMedaille1 = 0;
                item.lenghtMedaille2 = 0;
                if (coureur.medailles.Count > 0)
                {
                    item.lenghtMedaille1 = 25;
                    item.medaille1 = folderVm + coureur.medailles[0].lien;
                    if (coureur.medailles.Count > 1)
                    {
                        item.lenghtMedaille2 = 25;
                        item.medaille2 = folderVm + coureur.medailles[1].lien;
                    }
                }

                item.monEquipe = CommonLibrary.FindMyTeam(coureur.idEquipe);

                if (item.champNat == null)
                {
                    item.lenghtChampNat = 0;
                }
                else
                {
                    item.lenghtChampNat = 25;
                    item.champNat = folderVm + coureur.champNat;
                }

                item.formRounded = " " + (Math.Round(double.Parse(item.form, CultureInfo.InvariantCulture))).ToString("F0") + "%";
                item.santeRounded = " " + (Math.Round(double.Parse(item.sante, CultureInfo.InvariantCulture))).ToString("F0") + "%";
                item.formColor = CommonLibrary.GetFormColor(double.Parse(item.form, CultureInfo.InvariantCulture));
                item.santeColor = CommonLibrary.GetSanteColor(double.Parse(item.sante, CultureInfo.InvariantCulture));

                if (coureur.couleurCarte.Contains("JEUNE"))
                {
                    item.couleurCarte = folderVm + coureur.couleurCarte;
                }
            }


            Lvcoureurs.ItemsSource = allCoureurs.coureur;

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

                    GridView gView = Lvcoureurs.View as GridView;
                    foreach (GridViewColumn c in gView.Columns)
                    {
                        switch (c.Header.ToString())
                        {
                            case "PLA":
                            case "MON":
                            case "DES":
                            case "VAL":
                            case "PAV":
                            case "AGI":
                            case "CLM":
                            case "SPR":
                            case "END":
                            case "RES":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 4;
                                break;
                            case "FORME":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 8;
                                break;
                            case "SANTE":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 8;
                                break;
                            case "NIV":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 8;
                                break;
                            case "POT":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 8;
                                break;
                            case "AGE":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 4;
                                break;
                            case "NOM":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 15;
                                break;
                            case "PAYS":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 5;
                                break;
                            case "UCV":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 4;
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


        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            switch (headerClicked.Content)
            {
                case "PLA":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.pla, CultureInfo.InvariantCulture));
                    break;
                case "MON":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.mon, CultureInfo.InvariantCulture));
                    break;
                case "DES":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.des, CultureInfo.InvariantCulture));
                    break;
                case "VAL":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.val, CultureInfo.InvariantCulture));
                    break;
                case "PAV":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.pav, CultureInfo.InvariantCulture));
                    break;
                case "AGI":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.agi, CultureInfo.InvariantCulture));
                    break;
                case "CLM":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.clm, CultureInfo.InvariantCulture));
                    break;
                case "SPR":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.spr, CultureInfo.InvariantCulture));
                    break;
                case "END":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.end, CultureInfo.InvariantCulture));
                    break;
                case "RES":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.res, CultureInfo.InvariantCulture));
                    break;
                case "UCV":
                    if (ucvAsc)
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderBy(t => int.Parse(t.ucv.Replace(" ", "")));
                        ucvAsc = false;
                    }
                    else
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => int.Parse(t.ucv.Replace(" ", "")));
                        ucvAsc = true;
                    }
                    break;
                case "FORME":
                    if (formeAsc)
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderBy(t => double.Parse(t.form, CultureInfo.InvariantCulture));
                        formeAsc = false;
                    }
                    else
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.form, CultureInfo.InvariantCulture));
                        formeAsc = true;
                    }
                    break;
                case "SANTE":
                    if (santeAsc)
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderBy(t => double.Parse(t.sante, CultureInfo.InvariantCulture));
                        santeAsc = false;
                    }
                    else
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => double.Parse(t.sante, CultureInfo.InvariantCulture));
                        santeAsc = true;
                    }
                    break;
                case "NIV":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => t.niveauMax);
                    break;
                case "POT":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => t.potentielMax);
                    break;
                case "AGE":
                    if (ageAsc)
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderBy(t => int.Parse(t.age, CultureInfo.InvariantCulture));
                        ageAsc = false;
                    }
                    else
                    {
                        Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderByDescending(t => int.Parse(t.age, CultureInfo.InvariantCulture));
                        ageAsc = true;
                    }
                    break;
                case "NOM":
                    Lvcoureurs.ItemsSource = allCoureurs.coureur.OrderBy(t => t.nom);
                    break;
                default:
                    break;
            }
        }

        private void SelectRow(object sender, SelectionChangedEventArgs e)
        {
            Lvcoureurs.SelectedItem = null;
        }
    }
}
