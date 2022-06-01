using Biblioteka.Core;
using System.Threading;
using System.Windows.Controls;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for NowaKsiazkaPage.xaml
    /// </summary>
    public partial class NoweWypozyczeniePage : Page
    {
        public NoweWypozyczeniePage()
        {
            InitializeComponent();

            DataContext = new WypozyczenieViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (WypozyczenieViewModel)DataContext;
            viewModel.DodajNoweWypozyczenieCommand.Execute(null);
            ListaWypozyczenPage page = new ListaWypozyczenPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            ListaWypozyczenPage page = new ListaWypozyczenPage();
            NavigationService.Navigate(page);
        }
    }
}
