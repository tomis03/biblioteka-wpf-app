using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Biblioteka;

namespace Biblioteka.Core
{
    public class WypozyczenieViewModel : BaseViewModel
    {
        public ObservableCollection<Wypozyczenie> ListaWypozyczen { get; set; } = new ObservableCollection<Wypozyczenie>();

        public int IdWypozyczenia { get; set; }
        public int IdCzytelnikaWypozyczenia { get; set; }
        public string CzytelnikWypozyczenia { get; set; }
        public int IdKsiazkiWypozyczenia { get; set; }
        public string KsiazkaWypozyczenia { get; set; }

        public ICommand DodajNoweWypozyczenieCommand { get; set; }
        public ICommand UsunWypozyczeniaCommand { get; set; }
        public ICommand ZwrocWypozyczenieCommand { get; set; }

        public WypozyczenieViewModel()
        {
            DodajNoweWypozyczenieCommand = new RelayCommand(DodajNoweWypozyczenie);
            UsunWypozyczeniaCommand = new RelayCommand(UsunWypozyczenia);
            ZwrocWypozyczenieCommand = new RelayCommand(ZwrocWypozyczenia);

            foreach (var wypozyczenie in DatabaseLocator.Database.Wypozyczenia.ToList())
            {
                ListaWypozyczen.Add(new Wypozyczenie {
                    id_wypozyczenia = wypozyczenie.id_wypozyczenia,
                    id_czytelnika = wypozyczenie.id_czytelnika,
                    id_ksiazki = wypozyczenie.id_ksiazki,
                    data_wypozyczenia = wypozyczenie.data_wypozyczenia,
                    data_zwrotu = wypozyczenie.data_zwrotu
                });
            }
        }

        private void DodajNoweWypozyczenie()
        {
            var noweWypozyczenie = new Wypozyczenie
            {
                id_czytelnika = IdCzytelnikaWypozyczenia,
                id_ksiazki = IdKsiazkiWypozyczenia,
                data_wypozyczenia = DateTime.Now
            };

            ListaWypozyczen.Add(noweWypozyczenie);

            DatabaseLocator.Database.Wypozyczenia.Add(new Database.Wypozyczenie {
                id_czytelnika = IdCzytelnikaWypozyczenia,
                id_ksiazki = IdKsiazkiWypozyczenia,
                data_wypozyczenia = DateTime.Now
            });

            DatabaseLocator.Database.SaveChanges();

            IdCzytelnikaWypozyczenia = 0;
            CzytelnikWypozyczenia = string.Empty;
            IdKsiazkiWypozyczenia = 0;
            KsiazkaWypozyczenia = string.Empty;

            OnPropertyChanged(nameof(IdCzytelnikaWypozyczenia));
            OnPropertyChanged(nameof(CzytelnikWypozyczenia));
            OnPropertyChanged(nameof(IdKsiazkiWypozyczenia));
            OnPropertyChanged(nameof(KsiazkaWypozyczenia));
        }

        private void UsunWypozyczenia()
        {
            var wypozyczeniaDoUsuniecia = ListaWypozyczen.Where(x => x.zaznaczone).ToList();
            foreach (var wypozyczenie in wypozyczeniaDoUsuniecia)
            {
                ListaWypozyczen.Remove(wypozyczenie);
                var szukaneWypozyczenieWBazie = DatabaseLocator.Database.Wypozyczenia.FirstOrDefault(x => x.id_wypozyczenia == wypozyczenie.id_wypozyczenia);
                if (szukaneWypozyczenieWBazie != null) DatabaseLocator.Database.Wypozyczenia.Remove(szukaneWypozyczenieWBazie);
            }

            DatabaseLocator.Database.SaveChanges();
        }

        private void ZwrocWypozyczenia()
        {
            var wypozyczeniaDoZwrotu = ListaWypozyczen.Where(x => x.zaznaczone).ToList();
            foreach (var wypozyczenie in wypozyczeniaDoZwrotu)
            {
                var szukaneWypozyczenieWLiscie = ListaWypozyczen.FirstOrDefault(x => x.id_wypozyczenia == wypozyczenie.id_wypozyczenia);
                if (szukaneWypozyczenieWLiscie != null)
                {
                    szukaneWypozyczenieWLiscie.data_zwrotu = DateTime.Now;
                }
                var szukaneWypozyczenieWBazie = DatabaseLocator.Database.Wypozyczenia.FirstOrDefault(x => x.id_wypozyczenia == wypozyczenie.id_wypozyczenia);
                if (szukaneWypozyczenieWBazie != null)
                {
                    szukaneWypozyczenieWBazie.data_zwrotu = DateTime.Now;
                }
                DatabaseLocator.Database.SaveChanges();
                }
        }
    }
}
