using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Database
{
    public class Czytelnik
    {
        [Key]
        public int id_czytelnika { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string miasto { get; set; }
        public string ulica { get; set; }
        public string numer_domu { get; set; }
        public string kod_pocztowy { get; set; }
        public string email { get; set; }
        public string nr_telefonu { get; set; }

    }
}