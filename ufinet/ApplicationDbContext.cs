using Microsoft.EntityFrameworkCore;
using ufinet.Entities;

namespace ufinet
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Hotels)
                .WithOne(h => h.Country)
                .HasForeignKey(h => h.CountryId);

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Restaurants)
                .WithOne(r => r.Country)
                .HasForeignKey(r => r.CountryId);
        }
    }
}
