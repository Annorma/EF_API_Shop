using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> modelBuilder)
        {
            modelBuilder.Property(p => p.Name)
                         .HasMaxLength(250)
                         .IsRequired();
            modelBuilder.Property(p => p.Price)
                         .IsRequired();
            modelBuilder.Property(p => p.Quantity)
                         .HasMaxLength(10)
                         .IsRequired();
            modelBuilder.Property(p => p.IsInStock)
                        .IsRequired();
            modelBuilder.HasOne(p => p.Category)
                        .WithMany(c => c.Products);
            modelBuilder.ToTable("Products");
        }
    }
}
