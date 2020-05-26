using Microsoft.EntityFrameworkCore;
using restapp.Data.Mapping;
using restapp.Domain.Model;
using RestApp.Domain.Model.Queries;

namespace restapp.Data
{
    public class RestAppDbContext : DbContext
    {
        public RestAppDbContext(DbContextOptions<RestAppDbContext> options) : base(options)
        {

        }

        // Entities
        public DbSet<Product> Products { get; set; }

        // Queries
        public DbSet<DailyReport> DailyReport { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());

            // Queries
            modelBuilder.Entity<DailyReport>().HasNoKey();
        }
    }
}