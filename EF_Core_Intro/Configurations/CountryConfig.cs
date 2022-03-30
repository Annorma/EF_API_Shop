using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> modelBuilder)
        {
            modelBuilder.Property(c => c.Name)
                        .HasMaxLength(100)
                        .IsRequired();
            modelBuilder.ToTable("Country");
        }
    }
}
