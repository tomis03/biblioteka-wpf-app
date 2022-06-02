using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Biblioteka;

namespace Biblioteka.Core
{
    public class WydawnictwoViewModel : BaseViewModel
    {
        public ObservableCollection<Wydawnictwo> ListaWydawnictw { get; set; } = new ObservableCollection<Wydawnictwo>();

        public ICommand DodajDomyslneWydawnictwaCommand { get; set; }

        public WydawnictwoViewModel()
        {
            DodajDomyslneWydawnictwaCommand = new RelayCommand(DodajDomyslneWydawnictwa);

            foreach (var wydawnictwo in DatabaseLocator.Database.Wydawnictwa.ToList())
            {
                ListaWydawnictw.Add(new Wydawnictwo {
                    id_wydawnictwa = wydawnictwo.id_wydawnictwa,
                    nazwa_wydawnictwa = wydawnictwo.nazwa_wydawnictwa
                });
            }
        }

        private void DodajDomyslneWydawnictwa()
        {
            List<string> listaWydawnictw = new List<string> { "WERT", "Artemida", "Polskie wydawnictwo", "Luna", "Moon", "Light" };
            foreach(var wydawnictwo in listaWydawnictw)
            {
                ListaWydawnictw.Add(new Wydawnictwo { nazwa_wydawnictwa = wydawnictwo });
                DatabaseLocator.Database.Wydawnictwa.Add(new Database.Wydawnictwo { nazwa_wydawnictwa = wydawnictwo });
            }

            DatabaseLocator.Database.SaveChanges();
        }
    }
}
