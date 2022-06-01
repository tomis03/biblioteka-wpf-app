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
    public partial class ListaCzytelnikowPage : Page
    {
        public ListaCzytelnikowPage()
        {
            InitializeComponent();

            DataContext = new CzytelnikViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NowyCzytelnikPage page = new NowyCzytelnikPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            LandingPage page = new LandingPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (CzytelnikViewModel)DataContext;
            viewModel.DodajCzytelnikowDoEdycjiCommand.Execute(null);
            if(viewModel.CzytelnicyDoEdycji.Count > 1)
            {
                MessageBox.Show("Możesz edytować tylko jeden element. Wybierz jeszcze raz i kliknij w edycję ponownie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(viewModel.CzytelnicyDoEdycji.Count == 0)
            {
                MessageBox.Show("Żeby edytować najpierw wybierz jeden element.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                EdytujCzytelnikaPage page = new EdytujCzytelnikaPage(viewModel.CzytelnicyDoEdycji[0].id_czytelnika);
                NavigationService.Navigate(page);
            }
        }
    }
}
