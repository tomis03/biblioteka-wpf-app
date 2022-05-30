using Microsoft.EntityFrameworkCore;

namespace Biblioteka
{
    class AppDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = database.db");
        }

        public DbSet<Ksiazka> Ksiazki { get; set; }

        public DbSet<Wydawnictwo> Wydawnictwa { get; set; }
        
        public DbSet<Gatunek> Gatunki{ get; set; }

        public DbSet<Czytelnik> Czytelnicy{ get; set; }

        public DbSet<Wypozyczenie> Wypozyczenia{ get; set; }
    }
}
