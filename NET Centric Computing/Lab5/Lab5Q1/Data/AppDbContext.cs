using Microsoft.EntityFrameworkCore;
using Lab5Q1.Models;

namespace Lab5Q1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed some data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 400000},
                new Product { Id = 2, Name = "Mouse", Price = 2000 },
                new Product { Id = 3, Name = "Keyboard", Price = 8000}
            );
        }
    }
}
