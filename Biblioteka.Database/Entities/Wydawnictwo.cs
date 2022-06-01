using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Database
{
    public class Wydawnictwo
    {
        [Key]
        public int id_wydawnictwa { get; set; }
        public string nazwa_wydawnictwa { get; set; }
    }
}