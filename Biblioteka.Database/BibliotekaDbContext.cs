using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Database
{
    public class BibliotekaDbContext : DbContext
    {
        public DbSet<Czytelnik> Czytelnicy { get; set; }
        public DbSet<Gatunek> Gatunki { get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Wydawnictwo> Wydawnictwa { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite("Data Source = database.sqlite");
        }
    }
}
