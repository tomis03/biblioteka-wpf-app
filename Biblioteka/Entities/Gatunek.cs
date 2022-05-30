using System.ComponentModel.DataAnnotations;

namespace Biblioteka
{
    public class Gatunek
    {
        [Key]
        public int id_gatunku { get; set; }
        public string nazwa_gatunku { get; set; }
    }
}