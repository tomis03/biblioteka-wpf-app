using Biblioteka.Core;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Threading;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for ListaKsiazekPage.xaml
    /// </summary>
    public partial class ListaWypozyczenPage : Page
    {
        public ListaWypozyczenPage()
        {
            InitializeComponent();

            DataContext = new WypozyczenieViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NoweWypozyczeniePage page = new NoweWypozyczeniePage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            LandingPage page = new LandingPage();
            NavigationService.Navigate(page);
        }
    }
}
