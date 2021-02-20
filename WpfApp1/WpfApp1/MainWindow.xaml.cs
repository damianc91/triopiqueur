using RestSharp;
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
using HtmlAgilityPack;
using Serilog;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MinWidth = SystemParameters.MaximizedPrimaryScreenWidth / 2.0;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyUser(txtUsername.Text, txtPassword.Password))
            {

                Home subWindow = new Home();
                subWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Password = "";
            }
        }
        private bool VerifyUser(string username, string password)
        {


            var response = Requests.PageLogin();

            if (! Answers.FindAllTeamsOwned(response))
            {
                return false;
            }
            Answers.FindAndWriteMoney(response);
            Answers.FindAndWriteDivision(response);

            ///////////////////

            ///////////////////////////////

            return true;
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

        private void ChangeWindowSize(object sender, MouseButtonEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
    }
}
