using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
              .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .UseIdentityColumn();

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(c => c.CategoryId);

            builder
                .ToTable("Product");
        }
    }
}
