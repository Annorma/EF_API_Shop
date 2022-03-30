using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> modelBuilder)
        {
            modelBuilder.Property(p => p.Name)
                        .HasMaxLength(80)
                        .IsRequired();

            modelBuilder.ToTable("Positions");
        }
    }
}
