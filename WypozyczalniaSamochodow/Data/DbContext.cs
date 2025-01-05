using Microsoft.EntityFrameworkCore;
using WypozyczalniaSamochdow.Models;

namespace WypozyczalniaSamochodow
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Samochod> Samochody { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }


    }
}
