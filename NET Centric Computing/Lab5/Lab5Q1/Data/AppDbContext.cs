using Lab5Q1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5Q1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Your LocalDB instance.
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=Lab5Q1DB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}
