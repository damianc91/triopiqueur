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
    public partial class SubtitleWorld : Page
    {
        private BrushConverter bc = new BrushConverter();

        public SubtitleWorld()
        {
            InitializeComponent();
        }

        private void btnChamNat_Click(object sender, RoutedEventArgs e)
        {
            PageChampNat p = new PageChampNat();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnChamNat.Background = color;
        }

        private void btnSelection_Click(object sender, RoutedEventArgs e)
        {
            PageSelection p = new PageSelection();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnSelection.Background = color;
        }

        private void btnTransferts_Click(object sender, RoutedEventArgs e)
        {
            PageTransfertsGeneral p = new PageTransfertsGeneral();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnTransferts.Background = color;
        }

        private void btnForum_Click(object sender, RoutedEventArgs e)
        {
            PageForum p = new PageForum();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnForum.Background = color;
        }

        private void btnRecherche_Click(object sender, RoutedEventArgs e)
        {
            PageRecherche p = new PageRecherche();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnRecherche.Background = color;
        }
        
        private void btnVMMagazine_Click(object sender, RoutedEventArgs e)
        {
            PageVMMagazine p = new PageVMMagazine();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnVMMagazine.Background = color;
        }

        public void ResetColorButton()
        {
            var color = (Brush)bc.ConvertFrom("#FF929BA7");
            btnSelection.Background = color;
            btnTransferts.Background = color;
            btnForum.Background = color;
            btnChamNat.Background = color;
            btnRecherche.Background = color;
            btnVMMagazine.Background = color;
        }
    }
}
