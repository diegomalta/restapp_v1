using Microsoft.EntityFrameworkCore;
using restapp.Data.Mapping;
using restapp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restapp.Data
{
    public class RestappDbContext : DbContext
    {
        public RestappDbContext(DbContextOptions<RestappDbContext> options) : base (options)
        {

        }

        DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}
