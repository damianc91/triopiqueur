using System;
using System.Collections.Generic;
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
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class SubtitleTeam : Page
    {
        private BrushConverter bc = new BrushConverter();

        public SubtitleTeam()
        {
            InitializeComponent();
        }

        private void btnNationalite_Click(object sender, RoutedEventArgs e)
        {
            PageNationalite p = new PageNationalite();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnNationalite.Background = color;
        }

        private void btnObjectifs_Click(object sender, RoutedEventArgs e)
        {
            PageObjectifs p = new PageObjectifs();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnObjectifs.Background = color;
        }

        private void btnFinances_Click(object sender, RoutedEventArgs e)
        {
            PageFinances p = new PageFinances();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnFinances.Background = color;
        }

        private void btnStage_Click(object sender, RoutedEventArgs e)
        {
            PageStage p = new PageStage();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnStage.Background = color;
        }

        private void btnEntrainements_Click(object sender, RoutedEventArgs e)
        {
            PageEntrainements p = new PageEntrainements();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnEntrainements.Background = color;
        }

        private void btnEquipement_Click(object sender, RoutedEventArgs e)
        {
            PageEquipement p = new PageEquipement();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnEquipement.Background = color;
        }

        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            PageStaff p = new PageStaff();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnStaff.Background = color;
        }

        private void btnCoureurs_Click(object sender, RoutedEventArgs e)
        {
            PageCoureurs p = new PageCoureurs("5514");//DEBUG!!! int.Parse(CommonLibrary.FindMyTeam())
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnCoureurs.Background = color;
        }

        public void ResetColorButton()
        {
            var color = (Brush)bc.ConvertFrom("#FF929BA7");
            btnNationalite.Background = color;
            btnObjectifs.Background = color;
            btnFinances.Background = color;
            btnFinances.Background = color;
            btnStage.Background = color;
            btnEntrainements.Background = color;
            btnEquipement.Background = color;
            btnStaff.Background = color;
            btnCoureurs.Background = color;
        }
    }
}
