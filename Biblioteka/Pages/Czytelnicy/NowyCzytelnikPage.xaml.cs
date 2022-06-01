using Biblioteka.Core;
using System.Threading;
using System.Windows.Controls;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for NowaKsiazkaPage.xaml
    /// </summary>
    public partial class NowyCzytelnikPage : Page
    {
        public NowyCzytelnikPage()
        {
            InitializeComponent();

            DataContext = new CzytelnikViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (CzytelnikViewModel)DataContext;
            viewModel.DodajNowegoCzytelnikaCommand.Execute(null);
            ListaCzytelnikowPage page = new ListaCzytelnikowPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            ListaCzytelnikowPage page = new ListaCzytelnikowPage();
            NavigationService.Navigate(page);
        }
    }
}
