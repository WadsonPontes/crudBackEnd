using Microsoft.EntityFrameworkCore;
using aprendendoAPI.Models;

namespace aprendendoAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Estudo> Estudos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=W-PC;Database=aprendendo;User ID=sa; Password=123;");
        }
    }

}