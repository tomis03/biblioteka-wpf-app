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
    public partial class ListaKsiazekPage : Page
    {
        public ListaKsiazekPage()
        {
            InitializeComponent();

            DataContext = new KsiazkaViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NowaKsiazkaPage page = new NowaKsiazkaPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            LandingPage page = new LandingPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (KsiazkaViewModel)DataContext;
            viewModel.DodajKsiazkiDoEdycjiCommand.Execute(null);
            if(viewModel.KsiazkiDoEdycji.Count > 1)
            {
                MessageBox.Show("Możesz edytować tylko jeden element. Wybierz jeszcze raz i kliknij w edycję ponownie.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if(viewModel.KsiazkiDoEdycji.Count == 0)
            {
                MessageBox.Show("Żeby edytować najpierw wybierz jeden element.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                EdytujKsiazkePage page = new EdytujKsiazkePage(viewModel.KsiazkiDoEdycji[0].id_ksiazki);
                NavigationService.Navigate(page);
            }
        }
    }
}
