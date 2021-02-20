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
    public partial class SubtitleVip : Page
    {
        private BrushConverter bc = new BrushConverter();

        public SubtitleVip()
        {
            InitializeComponent();
        }

        private void btnAcheterVIP_Click(object sender, RoutedEventArgs e)
        {
            PageTactique p = new PageTactique();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnAcheterVIP.Background = color;
        }

        private void btnMedailles_Click(object sender, RoutedEventArgs e)
        {
            PageMedailles p = new PageMedailles();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnMedailles.Background = color;
        }

        private void btnBlocNote_Click(object sender, RoutedEventArgs e)
        {
            PageBlocNote p = new PageBlocNote();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnBlocNote.Background = color;
        }

        private void btnSuivi_Click(object sender, RoutedEventArgs e)
        {
            PageSuivi p = new PageSuivi();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnSuivi.Background = color;
        }

        private void btnStatsSpeciales_Click(object sender, RoutedEventArgs e)
        {
            PageStatsSpeciales p = new PageStatsSpeciales();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnStatsSpeciales.Background = color;
        }

        private void btnEquipesSurveillees_Click(object sender, RoutedEventArgs e)
        {
            PageEquipesSurveillees p = new PageEquipesSurveillees();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnEquipesSurveillees.Background = color;
        }

        private void btnCoureursSurveilles_Click(object sender, RoutedEventArgs e)
        {
            PageCoureursSurveilles p = new PageCoureursSurveilles();
            Home objMainWindows = (Home)Window.GetWindow(this);
            objMainWindows.frameLeft.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnCoureursSurveilles.Background = color;
        }

        public void ResetColorButton()
        {
            var color = (Brush)bc.ConvertFrom("#FF929BA7");
            btnAcheterVIP.Background = color;
            btnMedailles.Background = color;
            btnBlocNote.Background = color;
            btnSuivi.Background = color;
            btnStatsSpeciales.Background = color;
            btnEquipesSurveillees.Background = color;
            btnCoureursSurveilles.Background = color;
        }
    }
}
