using Biblioteka.Core;
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

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new GatunekViewModel();
            var gatunekViewModel = (GatunekViewModel)DataContext;
            if (gatunekViewModel.ListaGatunkow == null || gatunekViewModel.ListaGatunkow.Count == 0) gatunekViewModel.DodajDomyslneGatunkiCommand.Execute(null);

            DataContext = new WydawnictwoViewModel();
            var wydawnictwoViewModel = (WydawnictwoViewModel)DataContext;
            if (wydawnictwoViewModel.ListaWydawnictw == null || wydawnictwoViewModel.ListaWydawnictw.Count == 0) wydawnictwoViewModel.DodajDomyslneWydawnictwaCommand.Execute(null);
        }
    }
}
