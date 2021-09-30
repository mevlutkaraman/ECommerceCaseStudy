using ECommerce.Data.Configurations;
using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
    
}
