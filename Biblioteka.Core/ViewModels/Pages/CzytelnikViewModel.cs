using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Biblioteka;

namespace Biblioteka.Core
{
    public class CzytelnikViewModel : BaseViewModel
    {
        public ObservableCollection<Czytelnik> ListaCzytelnikow { get; set; } = new ObservableCollection<Czytelnik>();
        public ObservableCollection<Czytelnik> CzytelnicyDoEdycji { get; set; } = new ObservableCollection<Czytelnik>();

        public int IdCzytelnika { get; set; }
        public string ImieCzytelnika { get; set; }
        public string NazwiskoCzytelnika { get; set; }
        public string MiastoCzytelnika { get; set; }
        public string UlicaCzytelnika { get; set; }
        public string NumerDomuCzytelnika { get; set; }
        public string KodPocztowyCzytelnika { get; set; }
        public string EmailCzytelnika { get; set; }
        public string NrTelefonuCzytelnika { get; set; }

        public ICommand DodajNowegoCzytelnikaCommand { get; set; }
        public ICommand UsunCzytelnikowCommand { get; set; }
        public ICommand DodajCzytelnikowDoEdycjiCommand { get; set; }
        public ICommand UstawCzytelnikaDoEdycjiCommand { get; set; }
        public ICommand EdytujCzytelnikaCommand { get; set; }

        public CzytelnikViewModel()
        {
            DodajNowegoCzytelnikaCommand = new RelayCommand(DodajNowegoCzytelnika);
            UsunCzytelnikowCommand = new RelayCommand(UsunCzytelnikow);
            DodajCzytelnikowDoEdycjiCommand = new RelayCommand(DodajCzytelnikowDoEdycji);
            UstawCzytelnikaDoEdycjiCommand = new RelayCommand(UstawCzytelnikaDoEdycji);
            EdytujCzytelnikaCommand = new RelayCommand(EdytujCzytelnika);

            foreach (var czytelnik in DatabaseLocator.Database.Czytelnicy.ToList())
            {
                ListaCzytelnikow.Add(new Czytelnik {
                    id_czytelnika = czytelnik.id_czytelnika,
                    imie = czytelnik.imie,
                    nazwisko = czytelnik.nazwisko,
                    miasto = czytelnik.miasto,
                    ulica = czytelnik.ulica,
                    numer_domu = czytelnik.numer_domu,
                    kod_pocztowy = czytelnik.kod_pocztowy,
                    email = czytelnik.email,
                    nr_telefonu = czytelnik.nr_telefonu
                });
            }
        }

        public CzytelnikViewModel(int IdCzytelnikaDoEdycji)
        {
            DodajNowegoCzytelnikaCommand = new RelayCommand(DodajNowegoCzytelnika);
            UsunCzytelnikowCommand = new RelayCommand(UsunCzytelnikow);
            DodajCzytelnikowDoEdycjiCommand = new RelayCommand(DodajCzytelnikowDoEdycji);
            UstawCzytelnikaDoEdycjiCommand = new RelayCommand(UstawCzytelnikaDoEdycji);
            EdytujCzytelnikaCommand = new RelayCommand(EdytujCzytelnika);

            foreach (var czytelnik in DatabaseLocator.Database.Czytelnicy.ToList())
            {
                ListaCzytelnikow.Add(new Czytelnik
                {
                    id_czytelnika = czytelnik.id_czytelnika,
                    imie = czytelnik.imie,
                    nazwisko = czytelnik.nazwisko,
                    miasto = czytelnik.miasto,
                    ulica = czytelnik.ulica,
                    numer_domu = czytelnik.numer_domu,
                    kod_pocztowy = czytelnik.kod_pocztowy,
                    email = czytelnik.email,
                    nr_telefonu = czytelnik.nr_telefonu
                });
                if (czytelnik.id_czytelnika == IdCzytelnikaDoEdycji)
                {
                    IdCzytelnika = czytelnik.id_czytelnika;
                    ImieCzytelnika = czytelnik.imie;
                    NazwiskoCzytelnika = czytelnik.nazwisko;
                    MiastoCzytelnika = czytelnik.miasto;
                    UlicaCzytelnika = czytelnik.ulica;
                    NumerDomuCzytelnika = czytelnik.numer_domu;
                    KodPocztowyCzytelnika = czytelnik.kod_pocztowy;
                    EmailCzytelnika = czytelnik.email;
                    NrTelefonuCzytelnika = czytelnik.nr_telefonu;
                }
            }
        }

        private void DodajNowegoCzytelnika()
        {
            var nowyCzytelnik = new Czytelnik
            {
                imie = ImieCzytelnika,
                nazwisko = NazwiskoCzytelnika,
                miasto = MiastoCzytelnika,
                ulica = UlicaCzytelnika,
                numer_domu = NumerDomuCzytelnika,
                kod_pocztowy = KodPocztowyCzytelnika,
                email = EmailCzytelnika,
                nr_telefonu = NrTelefonuCzytelnika
            };

            ListaCzytelnikow.Add(nowyCzytelnik);

            DatabaseLocator.Database.Czytelnicy.Add(new Database.Czytelnik {
                imie = ImieCzytelnika,
                nazwisko = NazwiskoCzytelnika,
                miasto = MiastoCzytelnika,
                ulica = UlicaCzytelnika,
                numer_domu = NumerDomuCzytelnika,
                kod_pocztowy = KodPocztowyCzytelnika,
                email = EmailCzytelnika,
                nr_telefonu = NrTelefonuCzytelnika
            });

            DatabaseLocator.Database.SaveChanges();

            ImieCzytelnika = string.Empty;
            NazwiskoCzytelnika = string.Empty;
            MiastoCzytelnika = string.Empty;
            UlicaCzytelnika = string.Empty;
            NumerDomuCzytelnika = string.Empty;
            KodPocztowyCzytelnika = string.Empty;
            EmailCzytelnika = string.Empty;
            NrTelefonuCzytelnika = string.Empty;

            OnPropertyChanged(nameof(ImieCzytelnika));
            OnPropertyChanged(nameof(NazwiskoCzytelnika));
            OnPropertyChanged(nameof(MiastoCzytelnika));
            OnPropertyChanged(nameof(UlicaCzytelnika));
            OnPropertyChanged(nameof(NumerDomuCzytelnika));
            OnPropertyChanged(nameof(KodPocztowyCzytelnika));
            OnPropertyChanged(nameof(EmailCzytelnika));
            OnPropertyChanged(nameof(NrTelefonuCzytelnika));
        }

        private void UsunCzytelnikow()
        {
            var czytelnicyDoUsuniecia = ListaCzytelnikow.Where(x => x.zaznaczone).ToList();
            foreach (var czytelnik in czytelnicyDoUsuniecia)
            {
                ListaCzytelnikow.Remove(czytelnik);
                var szukanyCzytelnikWBazie = DatabaseLocator.Database.Czytelnicy.FirstOrDefault(x => x.id_czytelnika == czytelnik.id_czytelnika);
                if (szukanyCzytelnikWBazie != null) DatabaseLocator.Database.Czytelnicy.Remove(szukanyCzytelnikWBazie);
            }

            DatabaseLocator.Database.SaveChanges();
        }

        private void DodajCzytelnikowDoEdycji()
        {
            CzytelnicyDoEdycji.Clear();
            var czytelnicyDoEdycji = ListaCzytelnikow.Where(x => x.zaznaczone).ToList();

            foreach(var czytelnik in czytelnicyDoEdycji)
            {
                var czytelnikDoEdycji = new Czytelnik
                {
                    id_czytelnika = czytelnik.id_czytelnika,
                    imie = czytelnik.imie,
                    nazwisko = czytelnik.nazwisko,
                    miasto = czytelnik.miasto,
                    ulica = czytelnik.ulica,
                    numer_domu = czytelnik.numer_domu,
                    kod_pocztowy = czytelnik.kod_pocztowy,
                    email = czytelnik.email,
                    nr_telefonu = czytelnik.nr_telefonu
                };

                CzytelnicyDoEdycji.Add(czytelnikDoEdycji);
            }
        }

        private void UstawCzytelnikaDoEdycji()
        {
            IdCzytelnika = CzytelnicyDoEdycji[0].id_czytelnika;
            ImieCzytelnika = CzytelnicyDoEdycji[0].imie;
            NazwiskoCzytelnika = CzytelnicyDoEdycji[0].nazwisko;
            MiastoCzytelnika = CzytelnicyDoEdycji[0].miasto;
            UlicaCzytelnika = CzytelnicyDoEdycji[0].ulica;
            NumerDomuCzytelnika = CzytelnicyDoEdycji[0].numer_domu;
            KodPocztowyCzytelnika = CzytelnicyDoEdycji[0].kod_pocztowy;
            EmailCzytelnika = CzytelnicyDoEdycji[0].email;
            NrTelefonuCzytelnika = CzytelnicyDoEdycji[0].nr_telefonu;
        }

        private void EdytujCzytelnika()
        {
            var szukanyCzytelnikWLiscie = ListaCzytelnikow.FirstOrDefault(x => x.id_czytelnika == IdCzytelnika);
            if (szukanyCzytelnikWLiscie != null)
            {
                szukanyCzytelnikWLiscie.id_czytelnika = IdCzytelnika;
                szukanyCzytelnikWLiscie.imie = ImieCzytelnika;
                szukanyCzytelnikWLiscie.nazwisko = NazwiskoCzytelnika;
                szukanyCzytelnikWLiscie.miasto = MiastoCzytelnika;
                szukanyCzytelnikWLiscie.ulica = UlicaCzytelnika;
                szukanyCzytelnikWLiscie.numer_domu = NumerDomuCzytelnika;
                szukanyCzytelnikWLiscie.kod_pocztowy = KodPocztowyCzytelnika;
                szukanyCzytelnikWLiscie.email = EmailCzytelnika;
                szukanyCzytelnikWLiscie.nr_telefonu = NrTelefonuCzytelnika;
            }

            var szukanyCzytelnikWBazie = DatabaseLocator.Database.Czytelnicy.FirstOrDefault(x => x.id_czytelnika == IdCzytelnika);
            if(szukanyCzytelnikWBazie != null)
            {
                szukanyCzytelnikWBazie.id_czytelnika = IdCzytelnika;
                szukanyCzytelnikWBazie.imie = ImieCzytelnika;
                szukanyCzytelnikWBazie.nazwisko = NazwiskoCzytelnika;
                szukanyCzytelnikWBazie.miasto = MiastoCzytelnika;
                szukanyCzytelnikWBazie.ulica = UlicaCzytelnika;
                szukanyCzytelnikWBazie.numer_domu = NumerDomuCzytelnika;
                szukanyCzytelnikWBazie.kod_pocztowy = KodPocztowyCzytelnika;
                szukanyCzytelnikWBazie.email = EmailCzytelnika;
                szukanyCzytelnikWBazie.nr_telefonu = NrTelefonuCzytelnika;

                DatabaseLocator.Database.SaveChanges();
            }
        }
    }
}
