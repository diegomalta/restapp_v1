using Microsoft.EntityFrameworkCore;
using restapp.Data.Mapping;
using restapp.Domain.Model;

namespace restapp.Data
{
    public class RestAppDbContext : DbContext
    {
        public RestAppDbContext(DbContextOptions<RestAppDbContext> options) : base(options)
        {

        }

        DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}