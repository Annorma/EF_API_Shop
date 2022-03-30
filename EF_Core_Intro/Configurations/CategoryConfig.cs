using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.Property(c => c.Name)
                        .HasMaxLength(60)
                        .IsRequired();

            modelBuilder.ToTable("Category");
        }
    }
}
