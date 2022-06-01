using Biblioteka.Core;
using System.Threading;
using System.Windows.Controls;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for NowaKsiazkaPage.xaml
    /// </summary>
    public partial class EdytujKsiazkePage : Page
    {
        public EdytujKsiazkePage(int IdKsiazki)
        {
            InitializeComponent();

            DataContext = new KsiazkaViewModel(IdKsiazki);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ListaKsiazekPage page = new ListaKsiazekPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (KsiazkaViewModel)DataContext;
            viewModel.EdytujKsiazkeCommand.Execute(null);
            ListaKsiazekPage page = new ListaKsiazekPage();
            NavigationService.Navigate(page);
        }
    }
}
