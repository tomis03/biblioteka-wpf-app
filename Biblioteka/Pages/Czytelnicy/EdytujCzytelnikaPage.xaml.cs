using Biblioteka.Core;
using System.Threading;
using System.Windows.Controls;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for NowaKsiazkaPage.xaml
    /// </summary>
    public partial class EdytujCzytelnikaPage : Page
    {
        public EdytujCzytelnikaPage(int IdKsiazki)
        {
            InitializeComponent();

            DataContext = new CzytelnikViewModel(IdKsiazki);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ListaCzytelnikowPage page = new ListaCzytelnikowPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (CzytelnikViewModel)DataContext;
            viewModel.EdytujCzytelnikaCommand.Execute(null);
            ListaCzytelnikowPage page = new ListaCzytelnikowPage();
            NavigationService.Navigate(page);
        }
    }
}
