using System.ComponentModel.DataAnnotations;

namespace Biblioteka
{
    public class Wydawnictwo
    {
        [Key]
        public int id_wydawnictwa { get; set; }
        public string nazwa_wydawnictwa { get; set; }
    }
}