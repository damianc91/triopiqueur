using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour PageTransferts.xaml
    /// </summary>
    public partial class PageTransferts : Page
    {
        public double sizeFrame;
        public List<Transfert> allTransferts = new List<Transfert>();
        public string folderImages = "C:\\Users\\Damian\\source\\repos\\WpfApp1\\WpfApp1\\icones\\";
        public string folderVm = "https://www.velo-manager.net/";
        private bool jAsc;
        private bool nivAsc;
        private bool ageAsc;
        private bool nomAsc;
        private bool prixAsc;

        public PageTransferts()
        {
            InitializeComponent();

            List<Transfert> temp50Transferts;
            List<Transfert> transfertsToHide = new List<Transfert>();
            int cpt = 0;

            do
            {
                temp50Transferts = Answers.FindPageTranferts(Requests.PageTranferts(cpt.ToString()));
                allTransferts.AddRange(temp50Transferts);
                cpt += 50;
                //break;
            } while (temp50Transferts.Count == 50);

            foreach (Transfert trans in allTransferts)
            {
                //trans.potentielBaroudeur = CommonLibrary.FindPotentielPla(trans.age, trans.pla, trans.val, trans.end, trans.res);
                trans.potentielGrimpeur = CommonLibrary.FindStarsGrimp(CommonLibrary.FindPotentielMon(trans.age, trans.pla, trans.mon, trans.des, trans.val, trans.end, trans.res, name:trans.nom, joursAvantSaison: PageCalendrier.joursAvantSaison));
                trans.potentielVallon = CommonLibrary.FindStarsVal(CommonLibrary.FindPotentielVal(trans.age, trans.pla, trans.mon, trans.val, trans.end, trans.res, joursAvantSaison: PageCalendrier.joursAvantSaison));
                //trans.potentielPave = CommonLibrary.FindPotentielPav(trans.age, trans.pla, trans.pav, trans.val, trans.end, trans.res);
                //trans.potentielClm = CommonLibrary.FindPotentielClm(trans.age, trans.pla, trans.clm, trans.spr, trans.end, trans.res);
                //trans.potentielAgilite = CommonLibrary.FindPotentielAgi(trans.age, trans.pla, trans.mon, trans.val, trans.agi, trans.end, trans.res);
                //trans.potentielSpr = CommonLibrary.FindPotentielSpr(trans.age, trans.pla, trans.val, trans.spr, trans.end, trans.res);
                trans.potentielMax =  CommonLibrary.FindPotentielMax(trans.potentielBaroudeur, trans.potentielGrimpeur, trans.potentielVallon, trans.potentielPave, trans.potentielAgilite, trans.potentielClm, trans.potentielSpr);
                trans.potentielMaxString = trans.potentielMax.ToString();

                if (trans.potentielMax == 0)
                {
                    transfertsToHide.Add(trans);
                    continue;
                }

                trans.pays = folderVm + trans.pays;

                trans.plaRound = Math.Round(double.Parse(trans.pla, CultureInfo.InvariantCulture)).ToString();
                trans.monRound = Math.Round(double.Parse(trans.mon, CultureInfo.InvariantCulture)).ToString();
                trans.desRound = Math.Round(double.Parse(trans.des, CultureInfo.InvariantCulture)).ToString();
                trans.valRound = Math.Round(double.Parse(trans.val, CultureInfo.InvariantCulture)).ToString();
                trans.pavRound = Math.Round(double.Parse(trans.pav, CultureInfo.InvariantCulture)).ToString();
                trans.agiRound = Math.Round(double.Parse(trans.agi, CultureInfo.InvariantCulture)).ToString();
                trans.clmRound = Math.Round(double.Parse(trans.clm, CultureInfo.InvariantCulture)).ToString();
                trans.sprRound = Math.Round(double.Parse(trans.spr, CultureInfo.InvariantCulture)).ToString();
                trans.endRound = Math.Round(double.Parse(trans.end, CultureInfo.InvariantCulture)).ToString();
                trans.resRound = Math.Round(double.Parse(trans.res, CultureInfo.InvariantCulture)).ToString();

                trans.plaColor = CommonLibrary.FindColor(trans.pla);
                trans.monColor = CommonLibrary.FindColor(trans.mon);
                trans.desColor = CommonLibrary.FindColor(trans.des);
                trans.valColor = CommonLibrary.FindColor(trans.val);
                trans.pavColor = CommonLibrary.FindColor(trans.pav);
                trans.agiColor = CommonLibrary.FindColor(trans.agi);
                trans.clmColor = CommonLibrary.FindColor(trans.clm);
                trans.sprColor = CommonLibrary.FindColor(trans.spr);
                trans.endColor = CommonLibrary.FindColor(trans.end);
                trans.resColor = CommonLibrary.FindColor(trans.res);

                //trans.niveauBaroudeur = CommonLibrary.FindLevelPla( trans.pla, trans.val, trans.end, trans.res);
                trans.niveauGrimpeur = CommonLibrary.FindStarsGrimp(CommonLibrary.FindLevelMon( trans.pla, trans.mon, trans.des, trans.val, trans.end, trans.res));
                trans.niveauVallon = CommonLibrary.FindStarsVal(CommonLibrary.FindLevelVal( trans.pla, trans.mon, trans.val, trans.end, trans.res));
                //trans.niveauPave = CommonLibrary.FindLevelPav( trans.pla, trans.pav, trans.val, trans.end, trans.res);
                //trans.niveauClm = CommonLibrary.FindLevelClm( trans.pla, trans.spr, trans.clm, trans.res);
                //trans.niveauAgilite = CommonLibrary.FindLevelAgi(trans.pla, trans.val, trans.mon, trans.agi, trans.res);
                //trans.niveauSpr = CommonLibrary.FindLevelSpr( trans.pla, trans.val, trans.spr, trans.end, trans.res);
                trans.niveauMax = CommonLibrary.FindLevelMax(trans.niveauBaroudeur, trans.niveauGrimpeur, trans.niveauVallon, trans.niveauPave, trans.niveauAgilite, trans.niveauClm, trans.niveauSpr);
                trans.niveauMaxString = trans.niveauMax.ToString();

                trans.UpdateStars();
              



                CoureurIndividual coureur = Answers.FindPageCoureur(Requests.PageCoureur(trans.id));

                trans.medaille1Lenght = "0";
                trans.medaille2Lenght = "0";
                if (coureur.medailles.Count > 0)
                {
                    trans.medaille1Lenght = "25";
                    trans.medaille1 = folderVm + coureur.medailles[0].lien;
                    if (coureur.medailles.Count > 1)
                    {
                        trans.medaille1Lenght = "25";
                        trans.medaille2 = folderVm + coureur.medailles[1].lien;
                    }
                }

                trans.monEquipe = CommonLibrary.FindMyTeam(coureur.idEquipe);
                trans.champNat = folderVm + coureur.champNat;


                if (coureur.couleurCarte.Contains("JEUNE"))
                {
                    trans.couleurCarte = folderVm + coureur.couleurCarte;
                }
            }

            foreach (var item in transfertsToHide)
            {
                allTransferts.Remove(item);
            }
            

            Lvtransferts.ItemsSource = allTransferts;

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromMilliseconds(500);
            LiveTime.Tick += updateSize;
            LiveTime.Start();
        }

        private void updateSize(object sender, EventArgs e)
        {
            Home objMainWindows = (Home)Window.GetWindow(this);

            try {
                if (sizeFrame != objMainWindows.columnFrameLeft.ActualWidth)
                {
                    sizeFrame = objMainWindows.columnFrameLeft.ActualWidth;

                    GridView gView = Lvtransferts.View as GridView;
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
                            case "PRIX":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 9;
                                break;
                            case "J":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 3;
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
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 23;
                                break;
                            case "PAYS":
                                c.Width = (objMainWindows.columnFrameLeft.ActualWidth) / 100 * 5;
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
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.pla, CultureInfo.InvariantCulture));
                    break;
                case "MON":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.mon, CultureInfo.InvariantCulture));
                    break;
                case "DES":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.des, CultureInfo.InvariantCulture));
                    break;
                case "VAL":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.val, CultureInfo.InvariantCulture));
                    break;
                case "PAV":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.pav, CultureInfo.InvariantCulture));
                    break;
                case "AGI":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.agi, CultureInfo.InvariantCulture));
                    break;
                case "CLM":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.clm, CultureInfo.InvariantCulture));
                    break;
                case "SPR":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.spr, CultureInfo.InvariantCulture));
                    break;
                case "END":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.end, CultureInfo.InvariantCulture));
                    break;
                case "RES":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => double.Parse(t.res, CultureInfo.InvariantCulture));
                    break;
                case "PRIX":
                    if (prixAsc)
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderBy(t => int.Parse(t.prix.Replace(" ", "")));
                        prixAsc = false;
                    }
                    else
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => int.Parse(t.prix.Replace(" ", "")));
                        prixAsc = true;
                    }
                    break;
                case "J":
                    if (!jAsc)
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderBy(t => int.Parse(t.jours, CultureInfo.InvariantCulture));
                        jAsc = true;
                    }
                    else
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => int.Parse(t.jours, CultureInfo.InvariantCulture));
                        jAsc = false;
                    }
                    break;
                case "NIV":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => t.niveauMax);
                    break;
                case "POT":
                    Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => t.potentielMax);
                    break;
                case "AGE":
                    if (ageAsc)
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderBy(t => int.Parse(t.age, CultureInfo.InvariantCulture));
                        ageAsc = false;
                    }
                    else
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => int.Parse(t.age, CultureInfo.InvariantCulture));
                        ageAsc = true;
                    }
                    break;
                case "NOM":
                    if (!nomAsc)
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderBy(t => t.nom);
                        nomAsc = true;
                    }
                    else
                    {
                        Lvtransferts.ItemsSource = allTransferts.OrderByDescending(t => t.nom);
                        nomAsc = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void SelectRow(object sender, SelectionChangedEventArgs e)
        {
            Lvtransferts.SelectedItem = null;
        }


        private void Tri()
        {
            List<Transfert> filteredTransferts = new List<Transfert>();
            string riderType;

            foreach (var trans in allTransferts)
            {
                if (int.Parse(trans.age) <= int.Parse(((ComboBoxItem)comboBoxAgeMax.SelectedItem).Content.ToString()))
                {
                    if (int.Parse(trans.prix.Replace(" ", "")) <= int.Parse(((ComboBoxItem)comboBoxPrixMax.SelectedItem).Content.ToString().Replace(" ", "")))
                    {
                        riderType = ((ComboBoxItem)comboBoxSpecialite.SelectedItem).Content.ToString();

                        if (riderType == "All")
                        {
                            trans.niveauMax = CommonLibrary.FindLevelMax(trans.niveauBaroudeur, trans.niveauGrimpeur, trans.niveauVallon, trans.niveauPave, trans.niveauAgilite, trans.niveauClm, trans.niveauSpr);
                            trans.UpdateStars();
                        }
                        else if (riderType == "Baroudeur")
                        {
                            trans.niveauMax = trans.niveauBaroudeur;
                            trans.potentielMax = trans.potentielBaroudeur;
                            trans.UpdateStars();
                        }
                        else if (riderType == "Grimpeur")
                        {
                            trans.niveauMax = trans.niveauGrimpeur;
                            trans.potentielMax = trans.potentielGrimpeur;
                            trans.UpdateStars();
                        }
                        else if (riderType == "Vallon")
                        {
                            trans.niveauMax = trans.niveauVallon;
                            trans.potentielMax = trans.potentielVallon;
                            trans.UpdateStars();
                        }
                        else if (riderType == "Pavé")
                        {
                            trans.niveauMax = trans.niveauPave;
                            trans.potentielMax = trans.potentielPave;
                            trans.UpdateStars();
                        }
                        else if (riderType == "Cyclo cross")
                        {
                            trans.niveauMax = trans.niveauAgilite;
                            trans.potentielMax = trans.potentielAgilite;
                            trans.UpdateStars();
                        }
                        else if (riderType == "CLM")
                        {
                            trans.niveauMax = trans.niveauClm;
                            trans.potentielMax = trans.potentielClm;
                            trans.UpdateStars();
                        }
                        else if (riderType == "Omnium")
                        {
                            trans.niveauMax = trans.niveauSpr;
                            trans.potentielMax = trans.potentielSpr;
                            trans.UpdateStars();
                        }
 
                        if (trans.niveauMax >= int.Parse(Regex.Replace(((ComboBoxItem)comboBoxNiveauMin.SelectedItem).Name.ToString(), @"[^\d]", "")))
                        {
                            if (trans.potentielMax >= int.Parse(Regex.Replace(((ComboBoxItem)comboBoxPotentielMin.SelectedItem).Name.ToString(), @"[^\d]", "")))
                            {
                                filteredTransferts.Add(trans);
                            }
                        }
                    }
                }
            }

            Lvtransferts.ItemsSource = filteredTransferts;
        }

        private void Sort(object sender, SelectionChangedEventArgs e)
        {
            Tri();
        }

        private void btnReset_click(object sender, RoutedEventArgs e)
        {
            comboBoxAgeMax.SelectedItem = comboBoxAgeMax.Items[0];
            comboBoxNiveauMin.SelectedItem = comboBoxNiveauMin.Items[0];
            comboBoxPotentielMin.SelectedItem = comboBoxPotentielMin.Items[0];
            comboBoxPrixMax.SelectedItem = comboBoxPrixMax.Items[0];
            comboBoxSpecialite.SelectedItem = comboBoxSpecialite.Items[0];
        }

    }
}
