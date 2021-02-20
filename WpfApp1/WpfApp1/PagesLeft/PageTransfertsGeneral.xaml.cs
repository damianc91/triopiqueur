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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageVMMagazine.xaml
    /// </summary>
    public partial class PageTransfertsGeneral : Page
    {
        public PageTransfertsGeneral()
        {
            InitializeComponent();

            PageTransferts p = new PageTransferts();
            frameBottom.Navigate(p);
        }


        private void btnMarket(object sender, RoutedEventArgs e)
        {
            PageTransferts p = new PageTransferts();
            frameBottom.Navigate(p);
        }

        private void btnDaily(object sender, RoutedEventArgs e)
        {
            PageTransfertsDaily p = new PageTransfertsDaily();
            frameBottom.Navigate(p);
        }

        private void btnJuniors(object sender, RoutedEventArgs e)
        {
            PageTransfertsJuniors p = new PageTransfertsJuniors();
            frameBottom.Navigate(p);
        }
    }
}
