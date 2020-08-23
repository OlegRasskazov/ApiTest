using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().HasMany<Company>(p => p.Companies).WithOne(c => c.Provider).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>().HasMany<Product>(p => p.Products).WithOne(p => p.Company).OnDelete(DeleteBehavior.Cascade);
        }

    }
}