using Microsoft.EntityFrameworkCore;
using ShopDbApp;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ShopDb
{
    //    public class ShopDb : DbContext
    //    {
    //        public ShopDb() {}
    //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //        {
    //            base.OnConfiguring(optionsBuilder);
    //            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Shop_Db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
    //        }
    //        protected override void OnModelCreating(ModelBuilder modelBuilder)
    //        {
    //            base.OnModelCreating(modelBuilder);

    //            // Initialize (Seeder)

    //            modelBuilder.SeedCategories();
    //            modelBuilder.SeedCountries();
    //            modelBuilder.SeedCities();
    //            modelBuilder.SeedPositions();


    //            //Configurations

    //            modelBuilder.ApplyConfiguration(new CategoryConfig());
    //            modelBuilder.ApplyConfiguration(new CityConfig());
    //            modelBuilder.ApplyConfiguration(new CountryConfig());
    //            modelBuilder.ApplyConfiguration(new PositionConfig());
    //            modelBuilder.ApplyConfiguration(new ProductConfig());
    //            modelBuilder.ApplyConfiguration(new ShopConfig());
    //            modelBuilder.ApplyConfiguration(new WorkerConfig());
    //        }

    //        // Collections (tables in db)
    //        public DbSet<City> Cities { get; set; }
    //        public DbSet<Shop> Shops { get; set; }
    //        public DbSet<Worker> Workers { get; set; }
    //        public DbSet<Position> Positions { get; set; }
    //        public DbSet<Country> Countries { get; set; }
    //        public DbSet<Product> Products { get; set; }
    //        public DbSet<Category> Categories { get; set; }
    //    }

    public class ShopDbQueries
    {
        private readonly ShopDbContext db;

        public ShopDbQueries(ShopDbContext context)
        {
            db = context;
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return db.Workers.Include(w => w.Position)
                             .Include(w => w.Shop)
                             .ToList();
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return db.Countries.ToList();
        }

        public IEnumerable<City> GetAllCities()
        {
            return db.Cities.Include(c => c.Country)
                            .ToList();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return db.Positions.ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.Include(p => p.Shops)
                              .Include(p => p.Category)
                              .ToList();
        }

        public IEnumerable<Shop> GetAllShops()
        {
            return db.Shops.Include(s => s.City)
                           .Include(s => s.City.Country)
                           .Include(s => s.Products)
                           .Include(s => s.Workers)
                           .ToList();
        }

        public void AddCountry(string name)
        {
            Country newCountry = new Country()
            {
                Name = name
            };
            db.Countries.Add(newCountry);
            db.SaveChanges();
        }

        public void AddCity(string name, string countryName)
        {
            Country country = null;
            var result = db.Countries;
            foreach (var item in result)
            {
                if (item.Name == countryName)
                {
                    country = item;
                    break;
                }
            }
            if (country != null)
            {
                db.Cities.Add(new() { Name = name, Country = country });
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Country not found!\a\a");
                Console.ReadKey();
            }
        }

        public void AddShop(string name, string address, string cityName, int? parkingArea = null)
        {
            City city = null;
            var result = db.Cities;
            foreach (var item in result)
            {
                if (item.Name == cityName)
                {
                    city = item;
                    break;
                }
            }
            if (city != null)
            {
                db.Shops.Add(new() { Name = name, Address = address, City = city, ParkingArea = parkingArea });
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("City not found!\a\a");
                Console.ReadKey();
            }
        }

        public void AddWorker(string name, string surname, decimal salary, string email, string phoneNumber, int positionId, int shopId)
        {
            Position position = null;
            Shop shop = null;
            var resultPos = db.Positions;
            foreach (var item in resultPos)
            {
                if (item.Id == positionId)
                {
                    position = item;
                    break;
                }
            }
            var resultShop = db.Shops;
            foreach (var item in resultShop)
            {
                if (item.Id == shopId)
                {
                    shop = item;
                    break;
                }
            }
            if (shop != null && position != null)
            {
                db.Workers.Add(new() { Name = name, Surname = surname, Salary = salary, Email = email, PhoneNumber = phoneNumber, Position = position, Shop = shop });
                db.SaveChanges();
            }
            if (shop == null)
            {
                Console.WriteLine("Shop not found!\a\a");
                Console.ReadKey();
            }
            if (position == null)
            {
                Console.WriteLine("Position not found!\a\a");
                Console.ReadKey();
            }
        }

        public void DeleteCity(int cityId)
        {
            City city = null;
            var result = db.Cities;
            foreach (var item in result)
            {
                if (item.Id == cityId)
                {
                    city = item;
                    break;
                }
            }
            db.Cities.Remove(city);
            db.SaveChanges(true);
        }
    }
}
