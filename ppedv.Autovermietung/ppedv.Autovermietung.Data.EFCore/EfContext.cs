using Microsoft.EntityFrameworkCore;
using ppedv.Autovermietung.Model;

namespace ppedv.Autovermietung.Data.EFCore
{
    public class EfContext : DbContext
    {
        public DbSet<Auto>? Autos { get; set; }
        public DbSet<Vermietung>? Vermietungen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = "Server=(localdb)\\mssqllocaldb;Database=Autovermietung_dev;Trusted_Connection=true";
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conString);
        }
    }
}