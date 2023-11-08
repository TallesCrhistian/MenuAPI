using MenuAPI.Entites;
using Microsoft.EntityFrameworkCore;

namespace MenuAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt)
        : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Adress> Adresses { get; set; }

        public DbSet<Enterprise> Enterprises { get; set; }
    }
}
