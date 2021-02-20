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
using WpfApp1.PagesLeft;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class SubtitleTeams : Page
    {
        private BrushConverter bc = new BrushConverter();

        public SubtitleTeams()
        {
            InitializeComponent();
        }


        private void btnProchaineCourse_Click(object sender, RoutedEventArgs e)
        {
            PageProchaineCourse p = new PageProchaineCourse();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnProchaineCourse.Background = color;
        }

        private void btnCreerTeam_Click(object sender, RoutedEventArgs e)
        {
            PageCreerTeam p = new PageCreerTeam();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnCreerTeam.Background = color;
        }

        private void btnGestionDesMembres_Click(object sender, RoutedEventArgs e)
        {
            PageGestionMembres p = new PageGestionMembres();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnGestionDesMembres.Background = color;
        }

        private void btnMaTeam_Click(object sender, RoutedEventArgs e)
        {
            PageMaTeam p = new PageMaTeam();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnMaTeam.Background = color;
        }

        private void btnTeams_Click(object sender, RoutedEventArgs e)
        {
            PageTeams p = new PageTeams();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnTeams.Background = color;
        }

        public void ResetColorButton()
        {
            var color = (Brush)bc.ConvertFrom("#FF929BA7");
            btnProchaineCourse.Background = color;
            btnCreerTeam.Background = color;
            btnGestionDesMembres.Background = color;
            btnTeams.Background = color;
            btnMaTeam.Background = color;
        }
    }
}
