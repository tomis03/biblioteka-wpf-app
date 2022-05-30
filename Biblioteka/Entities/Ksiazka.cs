using System.ComponentModel.DataAnnotations;

namespace Biblioteka
{
    public class Ksiazka
    {
        [Key]
        public int id_ksiazki { get; set; }
        public string autor { get; set; }
        public string tytul { get; set; }
        public int id_wydawnictwa { get; set; }
        public int id_gatunku { get; set; }
        public string rok_wydania { get; set; }
    }
}