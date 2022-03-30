using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    
    public class WorkerConfig : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> modelBuilder)
        {
            modelBuilder.Property(w => w.Name)
                        .HasMaxLength(100)
                        .IsRequired();
            modelBuilder.Property(w => w.Surname)
                        .HasMaxLength(100)
                        .IsRequired();
            modelBuilder.Property(w => w.PhoneNumber)
                        .HasMaxLength(40);
            modelBuilder.Property(w => w.Email)
                        .HasMaxLength(70)
                        .IsRequired();
            modelBuilder.HasOne(w => w.Shop)
                        .WithMany(s => s.Workers);
            modelBuilder.HasOne(w => w.Position)
                        .WithMany(p => p.Workers);
            modelBuilder.ToTable("Workers");
        }
    }
}
