using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    
    public class CityConfig: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> modelBuilder)
        {
            modelBuilder.Property(c => c.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.HasOne(c => c.Country)
                        .WithMany(c => c.Cities)
                        .IsRequired(true);

            modelBuilder.ToTable("Cities");
        }
    }
}
