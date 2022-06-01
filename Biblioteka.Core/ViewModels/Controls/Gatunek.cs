using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Core
{
    public class Gatunek : BaseViewModel
    {
        public int id_gatunku { get; set; }
        public string nazwa_gatunku { get; set; }
    }
}