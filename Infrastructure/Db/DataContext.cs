using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Db
{
    public class DataContext : DbContext
    {

        public DataContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().HasMany<Company>(p => p.Companies).WithOne(c => c.Provider).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Company>().HasMany<Product>(p => p.Products).WithOne(p => p.Company).OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ProductApi.db");
        }

    }
}
