using System.Windows;
using Biblioteka.Core;
using Biblioteka.Database;

namespace Biblioteka
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var database = new BibliotekaDbContext();
            database.Database.EnsureCreated();
            DatabaseLocator.Database = database;
        }
    }
}
