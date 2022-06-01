using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Core
{
    public class Wydawnictwo : BaseViewModel
    {
        public int id_wydawnictwa { get; set; }
        public string nazwa_wydawnictwa { get; set; }
    }
}