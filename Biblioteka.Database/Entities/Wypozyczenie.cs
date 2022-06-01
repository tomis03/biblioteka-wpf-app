using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Database
{
    public class Wypozyczenie
    {
        [Key]
        public int id_wypozyczenia { get; set; }
        public int id_czytelnika { get; set; }
        public int id_ksiazki { get; set; }
        public DateTime data_wypozyczenia { get; set; }
        public DateTime data_zwrotu { get; set; }
    }
}