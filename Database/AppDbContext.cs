using Microsoft.EntityFrameworkCore;
using Demoexam.Models;

namespace Demoexam.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<PickupPoint> PickupPoints => Set<PickupPoint>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=demoexam;Username=postgres;Password=pos234");
        }
    }
}
