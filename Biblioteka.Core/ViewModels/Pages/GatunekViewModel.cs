using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Biblioteka;

namespace Biblioteka.Core
{
    public class GatunekViewModel : BaseViewModel
    {
        public ObservableCollection<Gatunek> ListaGatunkow { get; set; } = new ObservableCollection<Gatunek>();

        public ICommand DodajDomyslneGatunkiCommand { get; set; }

        public GatunekViewModel()
        {
            DodajDomyslneGatunkiCommand = new RelayCommand(DodajDomyslneGatunki);

            foreach (var gatunek in DatabaseLocator.Database.Gatunki.ToList())
            {
                ListaGatunkow.Add(new Gatunek {
                    id_gatunku = gatunek.id_gatunku,
                    nazwa_gatunku = gatunek.nazwa_gatunku
                });
            }
        }

        private void DodajDomyslneGatunki()
        {
            List<string> listaGatunkow = new List<string> { "Komedia", "Dramat", "Sci-fi", "Kryminał", "Bajka", "Wiersz" };
            foreach (var gatunek in listaGatunkow)
            {
                ListaGatunkow.Add(new Gatunek { nazwa_gatunku = gatunek });
                DatabaseLocator.Database.Gatunki.Add(new Database.Gatunek { nazwa_gatunku = gatunek });
            }

            DatabaseLocator.Database.SaveChanges();
        }
    }
}
