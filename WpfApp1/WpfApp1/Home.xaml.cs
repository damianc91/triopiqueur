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


            Team1NameTextBlock.Text = Answers.GetAllTeamOwnedNames()[0];
            Team2NameTextBlock.Text = Answers.GetAllTeamOwnedNames()[1];
            Team3NameTextBlock.Text = Answers.GetAllTeamOwnedNames()[2];
            switch (Answers.GetCurrentChoicedTeam())
            {
                case "1":
                    Team1MoneyTextBlock.Text = "D" + Answers.GetCurrentDivision() + ", " + Answers.GetCurrentMoney();
                    ChangeColorButton(1);
                    break;
                case "2":
                    Team2MoneyTextBlock.Text = "D" + Answers.GetCurrentDivision() + ", " + Answers.GetCurrentMoney();
                    ChangeColorButton(2);
                    break;
                default:
                    Team3MoneyTextBlock.Text = "D" + Answers.GetCurrentDivision() + ", " + Answers.GetCurrentMoney();
                    ChangeColorButton(3);
                    break;
            }
            
            var nb = -1 + int.Parse(Answers.GetCurrentChoicedTeam());
            var id = Answers.GetAllTeamsOwned()[nb];
            PageCoureurs p3 = new PageCoureurs(id);
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
            ChangeColorButton(1);

            UpdateXmlForCurrentTeam("1");
        }

        private void UpdateXmlForCurrentTeam(string number)
        {
            var idTeam = Answers.GetAllTeamsOwned()[int.Parse(number) - 1];
            var response = Requests.PageLogin(idTeam);
            Answers.WriteCurrentTeamInXml(number);
            Answers.WriteMoneyInXml(response);
            Answers.WriteDivisionInXml(response);

            Team1MoneyTextBlock.Text = "";
            Team2MoneyTextBlock.Text = "";
            Team3MoneyTextBlock.Text = "";

            Home subWindow = new Home();
            subWindow.Show();
            this.Close();
        }

        private void btnTeam2Choice_Click(object sender, RoutedEventArgs e)
        {
            ChangeColorButton(2);

            UpdateXmlForCurrentTeam("2");
        }

        private void btnTeam3Choice_Click(object sender, RoutedEventArgs e)
        {
            ChangeColorButton(3);

            UpdateXmlForCurrentTeam("3");
        }

        private void ChangeColorButton(int v)
        {
            ResetTeamChoice();

            switch (v)
            {
                case 1:
                    var color = (Brush)bc.ConvertFrom("#FFCC951F");
                    btnTeam1Choice.Background = color;
                    break;
                case 2:
                    var color2 = (Brush)bc.ConvertFrom("#FFCC951F");
                    btnTeam2Choice.Background = color2;
                    break;
                case 3:
                    var color3 = (Brush)bc.ConvertFrom("#FFCC951F");
                    btnTeam3Choice.Background = color3;
                    break;
                default:
                    break;
            }
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
