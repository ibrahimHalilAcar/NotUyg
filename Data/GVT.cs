using Microsoft.EntityFrameworkCore;

namespace Deneme.Models
{
    public class GVT : DbContext
    {
        public GVT() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=NotUygulamasi.db");
        }

        public DbSet<Not> Notlar { get; set; }
    }
}
