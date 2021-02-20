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
    public partial class SubtitleResults : Page
    {
        private BrushConverter bc = new BrushConverter();

        public SubtitleResults()
        {
            InitializeComponent();
        }

        private void btnClassements_Click(object sender, RoutedEventArgs e)
        {
            PageClassements p = new PageClassements();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnClassements.Background = color;
        }

        private void btnResultats_Click(object sender, RoutedEventArgs e)
        {
            PageResultats p = new PageResultats();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnResultats.Background = color;
        }

        public void ResetColorButton()
        {
            var color = (Brush)bc.ConvertFrom("#FF929BA7");
            btnClassements.Background = color;
            btnResultats.Background = color;
        }
    }
}
