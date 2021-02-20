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
using System.Globalization;
using System.Windows.Threading;
using WpfApp1.Subtitle;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        private BrushConverter bc = new BrushConverter();

        public Home()
        {

            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MinWidth = SystemParameters.MaximizedPrimaryScreenWidth / 2.0;

            //SubtitleEmpty p = new SubtitleEmpty();
            //frameSubtitle.Navigate(p);

            PageCalendrier p2 = new PageCalendrier();
            frameRight.Navigate(p2);

            PageCoureurs p3 = new PageCoureurs("5514");
            frameLeft.Navigate(p3);

            //DispatcherTimer LiveTime = new DispatcherTimer();
            //LiveTime.Interval = TimeSpan.FromSeconds(1);
            //LiveTime.Tick += timer_Tick;
            //LiveTime.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            SubtitleTeam p = new SubtitleTeam();
            frameSubtitle.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnTeam.Background = color;

            TitleChoice.Content = "TEAM";
        }

        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            SubtitleResults p = new SubtitleResults();
            frameSubtitle.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnResults.Background = color;

            TitleChoice.Content = "RESULTS";
        }

        private void btnWorld_Click(object sender, RoutedEventArgs e)
        {
            SubtitleWorld p = new SubtitleWorld();
            frameSubtitle.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnWorld.Background = color;

            TitleChoice.Content = "WORLD";
        }

        private void btnTeams_Click(object sender, RoutedEventArgs e)
        {
            SubtitleTeams p = new SubtitleTeams();
            frameSubtitle.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnTeams.Background = color;

            TitleChoice.Content = "TEAMS";
        }

        private void btnVip_Click(object sender, RoutedEventArgs e)
        {
            SubtitleVip p = new SubtitleVip();
            frameSubtitle.Navigate(p);

            ResetColorButton();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnVip.Background = color;

            TitleChoice.Content = "VIP";
        }

 

        public void ResetColorButton()
        {
            var color = (Brush)bc.ConvertFrom("#FF2C2E30");
            btnTeam.Background = color;
            btnResults.Background = color;
            btnWorld.Background = color;
            btnTeams.Background = color;
            btnVip.Background = color;
        }

        private void btnMessages_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTeam1Choice_Click(object sender, RoutedEventArgs e)
        {
            ResetTeamChoice();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnTeam1Choice.Background = color;
        }

        private void btnTeam2Choice_Click(object sender, RoutedEventArgs e)
        {
            ResetTeamChoice();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnTeam2Choice.Background = color;
        }

        private void btnTeam3Choice_Click(object sender, RoutedEventArgs e)
        {
            ResetTeamChoice();
            var color = (Brush)bc.ConvertFrom("#FFCC951F");
            btnTeam3Choice.Background = color;
        }

        public void ResetTeamChoice()
        {
            var color = System.Windows.Media.Brushes.Transparent;
            btnTeam1Choice.Background = color;
            btnTeam2Choice.Background = color;
            btnTeam3Choice.Background = color;
        }

        //private void ChangeWindowSize(object sender, MouseButtonEventArgs e)
        //{
        //    if (WindowState != WindowState.Maximized)
        //    {
        //        WindowState = WindowState.Maximized;
        //    }
        //    else
        //    {
        //        WindowState = WindowState.Normal;
        //    }
        //    PageTransferts.sizeView = 0;
        //}

        private void btnCollapseFrameRight(object sender, RoutedEventArgs e)
        {
            if (iconFrameRight.Kind == MaterialDesignThemes.Wpf.PackIconKind.ArrowCollapseRight)
            {
                columnFrameRight.Width = new GridLength(0.0);
                iconFrameRight.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowCollapseLeft;
            }
            else
            {
                columnFrameRight.Width = new GridLength(450.0);
                iconFrameRight.Kind = MaterialDesignThemes.Wpf.PackIconKind.ArrowCollapseRight;
            }
        }
    }
}
