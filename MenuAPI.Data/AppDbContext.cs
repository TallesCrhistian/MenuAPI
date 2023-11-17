using MenuAPI.Entites;
using MenuAPI.Shared.Enumerators;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MenuAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt)
        : base(opt) 
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<GroupEnum>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.HasPostgresEnum<GroupEnum>();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Adress> Adresses { get; set; }

        public DbSet<Enterprise> Enterprises { get; set; }
    }
}
