using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    
    public class ShopConfig : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> modelBuilder)
        {
            modelBuilder.Property(s => s.Name)
                        .HasMaxLength(100)
                        .IsRequired();
            modelBuilder.Property(s => s.Address)
                        .IsRequired();
            modelBuilder.Property(s => s.ParkingArea)
                        .HasMaxLength(20)
                        .IsRequired();
            modelBuilder.HasMany(s => s.Products)
                        .WithMany(p => p.Shops);
            modelBuilder.HasOne(s => s.City)
                        .WithMany(c => c.Shops);
            modelBuilder.ToTable("Shops");
        }
    }
}
