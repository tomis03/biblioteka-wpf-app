using Biblioteka.Core;
using System.Threading;
using System.Windows.Controls;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for NowaKsiazkaPage.xaml
    /// </summary>
    public partial class NowaKsiazkaPage : Page
    {
        public NowaKsiazkaPage()
        {
            InitializeComponent();

            DataContext = new KsiazkaViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (KsiazkaViewModel)DataContext;
            viewModel.DodajNowaKsiazkeCommand.Execute(null);
            ListaKsiazekPage page = new ListaKsiazekPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            ListaKsiazekPage page = new ListaKsiazekPage();
            NavigationService.Navigate(page);
        }
    }
}
