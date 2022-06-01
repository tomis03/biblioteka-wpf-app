using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka.Database;

namespace Biblioteka.Core
{
    public class DatabaseLocator
    {
        public static BibliotekaDbContext Database { get; set; }
    }
}
