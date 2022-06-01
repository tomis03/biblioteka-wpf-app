using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Core
{
    public class Wypozyczenie : BaseViewModel
    {
        public int id_wypozyczenia { get; set; }
        public int id_czytelnika { get; set; }
        public int id_ksiazki { get; set; }
        public DateTime data_wypozyczenia { get; set; }
        public DateTime data_zwrotu { get; set; }
        public bool zaznaczone { get; set; }
    }
}