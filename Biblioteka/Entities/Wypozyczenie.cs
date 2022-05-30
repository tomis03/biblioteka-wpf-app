using System.ComponentModel.DataAnnotations;

namespace Biblioteka
{
    public class Wypozyczenie
    {
        [Key]
        public int id_wypozyczenia { get; set; }
        public int id_czytelnika { get; set; }
        public int id_ksiazki { get; set; }
        public string data_wypozyczenia { get; set; }
        public string data_zwrotu { get; set; }
    }
}