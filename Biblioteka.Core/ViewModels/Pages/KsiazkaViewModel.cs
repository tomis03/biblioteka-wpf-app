using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Biblioteka;

namespace Biblioteka.Core
{
    public class KsiazkaViewModel : BaseViewModel
    {
        public ObservableCollection<Ksiazka> ListaKsiazek { get; set; } = new ObservableCollection<Ksiazka>();
        public ObservableCollection<Ksiazka> KsiazkiDoEdycji { get; set; } = new ObservableCollection<Ksiazka>();

        public int IdKsiazki { get; set; }
        public string AutorKsiazki { get; set; }
        public string TytulKsiazki { get; set; }
        public int WydawnictwoKsiazki { get; set; }
        public int GatunekKsiazki { get; set; }
        public string RokWydaniaKsiazki { get; set; }

        public ICommand DodajNowaKsiazkeCommand { get; set; }
        public ICommand UsunKsiazkiCommand { get; set; }
        public ICommand DodajKsiazkiDoEdycjiCommand { get; set; }
        public ICommand UstawKsiazkeDoEdycjiCommand { get; set; }
        public ICommand EdytujKsiazkeCommand { get; set; }

        public KsiazkaViewModel()
        {
            DodajNowaKsiazkeCommand = new RelayCommand(DodajNowaKsiazke);
            UsunKsiazkiCommand = new RelayCommand(UsunKsiazki);
            DodajKsiazkiDoEdycjiCommand = new RelayCommand(DodajKsiazkiDoEdycji);
            UstawKsiazkeDoEdycjiCommand = new RelayCommand(UstawKsiazkeDoEdycji);
            EdytujKsiazkeCommand = new RelayCommand(EdytujKsiazke);

            foreach (var ksiazka in DatabaseLocator.Database.Ksiazki.ToList())
            {
                ListaKsiazek.Add(new Ksiazka {
                    id_ksiazki = ksiazka.id_ksiazki,
                    autor = ksiazka.autor,
                    tytul = ksiazka.tytul,
                    id_wydawnictwa = ksiazka.id_wydawnictwa,
                    id_gatunku = ksiazka.id_gatunku,
                    rok_wydania = ksiazka.rok_wydania
                });
            }
        }

        public KsiazkaViewModel(int IdKsiazkiDoEdycji)
        {
            DodajNowaKsiazkeCommand = new RelayCommand(DodajNowaKsiazke);
            UsunKsiazkiCommand = new RelayCommand(UsunKsiazki);
            DodajKsiazkiDoEdycjiCommand = new RelayCommand(DodajKsiazkiDoEdycji);
            UstawKsiazkeDoEdycjiCommand = new RelayCommand(UstawKsiazkeDoEdycji);
            EdytujKsiazkeCommand = new RelayCommand(EdytujKsiazke);

            foreach (var ksiazka in DatabaseLocator.Database.Ksiazki.ToList())
            {
                ListaKsiazek.Add(new Ksiazka
                {
                    id_ksiazki = ksiazka.id_ksiazki,
                    autor = ksiazka.autor,
                    tytul = ksiazka.tytul,
                    id_wydawnictwa = ksiazka.id_wydawnictwa,
                    id_gatunku = ksiazka.id_gatunku,
                    rok_wydania = ksiazka.rok_wydania
                });
                if (ksiazka.id_ksiazki == IdKsiazkiDoEdycji)
                {
                    IdKsiazki = ksiazka.id_ksiazki;
                    AutorKsiazki = ksiazka.autor;
                    TytulKsiazki = ksiazka.tytul;
                    WydawnictwoKsiazki = ksiazka.id_wydawnictwa;
                    GatunekKsiazki = ksiazka.id_gatunku;
                    RokWydaniaKsiazki = ksiazka.rok_wydania;
                }
            }
        }

        private void DodajNowaKsiazke()
        {
            var nowaKsiazka = new Ksiazka
            {
                autor = AutorKsiazki,
                tytul = TytulKsiazki,
                id_wydawnictwa = WydawnictwoKsiazki,
                id_gatunku = GatunekKsiazki,
                rok_wydania = RokWydaniaKsiazki
            };

            ListaKsiazek.Add(nowaKsiazka);

            DatabaseLocator.Database.Ksiazki.Add(new Database.Ksiazka {
                autor = AutorKsiazki,
                tytul = TytulKsiazki,
                id_wydawnictwa = WydawnictwoKsiazki,
                id_gatunku = GatunekKsiazki,
                rok_wydania = RokWydaniaKsiazki
            });

            DatabaseLocator.Database.SaveChanges();

            AutorKsiazki = string.Empty;
            TytulKsiazki = string.Empty;
            WydawnictwoKsiazki = 0;
            GatunekKsiazki = 0;
            RokWydaniaKsiazki = string.Empty;

            OnPropertyChanged(nameof(AutorKsiazki));
            OnPropertyChanged(nameof(TytulKsiazki));
            OnPropertyChanged(nameof(WydawnictwoKsiazki));
            OnPropertyChanged(nameof(GatunekKsiazki));
            OnPropertyChanged(nameof(RokWydaniaKsiazki));
        }

        private void UsunKsiazki()
        {
            var ksiazkiDoUsuniecia = ListaKsiazek.Where(x => x.zaznaczone).ToList();
            foreach (var ksiazka in ksiazkiDoUsuniecia)
            {
                ListaKsiazek.Remove(ksiazka);
                var szukanaKsiazkaWBazie = DatabaseLocator.Database.Ksiazki.FirstOrDefault(x => x.id_ksiazki == ksiazka.id_ksiazki);
                if (szukanaKsiazkaWBazie != null) DatabaseLocator.Database.Ksiazki.Remove(szukanaKsiazkaWBazie);
            }

            DatabaseLocator.Database.SaveChanges();
        }

        private void DodajKsiazkiDoEdycji()
        {
            KsiazkiDoEdycji.Clear();
            var ksiazkiDoEdycji = ListaKsiazek.Where(x => x.zaznaczone).ToList();

            foreach(var ksiazka in ksiazkiDoEdycji)
            {
                var ksiazkaDoEdycji = new Ksiazka
                {
                    id_ksiazki = ksiazka.id_ksiazki,
                    autor = ksiazka.autor,
                    tytul = ksiazka.tytul,
                    id_wydawnictwa = ksiazka.id_wydawnictwa,
                    id_gatunku = ksiazka.id_gatunku,
                    rok_wydania = ksiazka.rok_wydania
                };

                KsiazkiDoEdycji.Add(ksiazkaDoEdycji);
            }
        }

        private void UstawKsiazkeDoEdycji()
        {
            IdKsiazki = KsiazkiDoEdycji[0].id_ksiazki;
            AutorKsiazki = KsiazkiDoEdycji[0].autor;
            TytulKsiazki = KsiazkiDoEdycji[0].tytul;
            WydawnictwoKsiazki = KsiazkiDoEdycji[0].id_wydawnictwa;
            GatunekKsiazki = KsiazkiDoEdycji[0].id_gatunku;
            RokWydaniaKsiazki = KsiazkiDoEdycji[0].rok_wydania;
        }

        private void EdytujKsiazke()
        {
            var szukanaKsiazkaWLiscie = ListaKsiazek.FirstOrDefault(x => x.id_ksiazki == IdKsiazki);
            if (szukanaKsiazkaWLiscie != null)
            {
                szukanaKsiazkaWLiscie.autor = AutorKsiazki;
                szukanaKsiazkaWLiscie.tytul = TytulKsiazki;
                szukanaKsiazkaWLiscie.id_wydawnictwa = WydawnictwoKsiazki;
                szukanaKsiazkaWLiscie.id_gatunku = GatunekKsiazki;
                szukanaKsiazkaWLiscie.rok_wydania = RokWydaniaKsiazki;
            }

            var szukanaKsiazkaWBazie = DatabaseLocator.Database.Ksiazki.FirstOrDefault(x => x.id_ksiazki == IdKsiazki);
            if(szukanaKsiazkaWBazie != null)
            {
                szukanaKsiazkaWBazie.autor = AutorKsiazki;
                szukanaKsiazkaWBazie.tytul = TytulKsiazki;
                szukanaKsiazkaWBazie.id_wydawnictwa = WydawnictwoKsiazki;
                szukanaKsiazkaWBazie.id_gatunku = GatunekKsiazki;
                szukanaKsiazkaWBazie.rok_wydania = RokWydaniaKsiazki;

                DatabaseLocator.Database.SaveChanges();
            }
        }
    }
}
