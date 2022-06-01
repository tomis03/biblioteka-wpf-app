using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Database
{
    public class Gatunek
    {
        [Key]
        public int id_gatunku { get; set; }
        public string nazwa_gatunku { get; set; }
    }
}