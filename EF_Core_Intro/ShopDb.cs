using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Intro
{
    public class ShopDb : DbContext
    {
        public ShopDb()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            // Use Migrations instead: (install NuGet: EFCore.Tools)
            // add-migration <MigrationName> - add new migration with available changes
            // update-migration              - update the database by the newest migration
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Shop_Db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Initialize (Seeder)
            modelBuilder.SeedCategories();
            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedPositions();

            // Fluent API configurations

            // Country
            modelBuilder.Entity<Country>().Property(c => c.Name)
                                          .HasMaxLength(100)
                                          .IsRequired();
            modelBuilder.Entity<Country>().ToTable("Country");

            // City
            modelBuilder.Entity<City>().Property(c => c.Name)
                                       .HasMaxLength(100)
                                       .IsRequired();
            modelBuilder.Entity<City>().Property(c => c.Country)
                                       .IsRequired();
            modelBuilder.Entity<City>().ToTable("Cities");

            // Shop
            modelBuilder.Entity<Shop>().Property(s => s.Name)
                                       .HasMaxLength(100)
                                       .IsRequired();
            modelBuilder.Entity<Shop>().Property(s => s.Address)
                                       .IsRequired();
            modelBuilder.Entity<Shop>().Property(s => s.ParkingArea)
                                       .HasMaxLength(20)
                                       .IsRequired();
            modelBuilder.Entity<Shop>().ToTable("Shops");

            // Worker
            modelBuilder.Entity<Worker>().Property(w => w.Name)
                                         .HasMaxLength(100)
                                         .IsRequired();
            modelBuilder.Entity<Worker>().Property(w => w.Surname)
                                         .HasMaxLength(100)
                                         .IsRequired();
            modelBuilder.Entity<Worker>().Property(w => w.PhoneNumber)
                                         .HasMaxLength(40);
            modelBuilder.Entity<Worker>().Property(w => w.Email)
                                         .HasMaxLength(70)
                                         .IsRequired();
            modelBuilder.Entity<Worker>().Property(w => w.Position)
                                          .IsRequired();
            modelBuilder.Entity<Worker>().Property(w => w.ShopId)
                                         .IsRequired();
            modelBuilder.Entity<Worker>().ToTable("Workers");

            // Position
            modelBuilder.Entity<Position>().Property(p => p.Name)
                                           .HasMaxLength(80)
                                           .IsRequired();

            // Product
            modelBuilder.Entity<Product>().Property(p => p.Name)
                                          .HasMaxLength(250)
                                          .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price)
                                          .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Quantity)
                                          .HasMaxLength(10)
                                          .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.IsInStock)
                                          .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.CategoryId)
                                          .IsRequired();
            modelBuilder.Entity<Product>().ToTable("Products");

            // Category
            modelBuilder.Entity<Category>().Property(c => c.Name)
                                          .HasMaxLength(60)
                                          .IsRequired();
            modelBuilder.Entity<Category>().ToTable("Category");



        }

        // Collections (tables in db)
        public DbSet<City> Cities { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
