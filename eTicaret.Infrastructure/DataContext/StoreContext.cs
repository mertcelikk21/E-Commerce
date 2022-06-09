﻿using eTicaret.Core.DbModels;
using Microsoft.EntityFrameworkCore;

namespace eTicaret.Infrastructure.DataContext
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

    }
}
