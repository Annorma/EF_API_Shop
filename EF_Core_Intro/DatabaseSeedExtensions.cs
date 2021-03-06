using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDbApp
{
    public static class DatabaseSeedExtensions
    {
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new[]
            {
                new Position()
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Position()
                {
                    Id = 2,
                    Name = "Designer"
                },
                new Position()
                {
                    Id = 3,
                    Name = "Programmer"
                }
            });
        }
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new[]
            {
                new Country()
                {
                    Id = 1,
                    Name = "Ukraine",
                },
                new Country()
                {
                    Id = 2,
                    Name = "USA",
                },
                new Country()
                {
                    Id = 3,
                    Name = "China",
                },
                new Country()
                {
                    Id = 4,
                    Name = "Turkey",
                }
            });
        }
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category()
                {
                    Id = 1,
                    Name = "Devices"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Food",
                },
                new Category()
                {
                    Id = 3,
                    Name = "Cars",
                },
                new Category()
                {
                    Id = 4,
                    Name = "Furniture",
                }
            });
        }
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new[]
            {
                new
                {
                    Id = 1,
                    Name = "New York",
                    CountryId = 1
                },
                new
                {
                    Id = 2,
                    Name = "Kyiv",
                    CountryId = 2
                },
                new
                {
                    Id = 3,
                    Name = "Paris",
                    CountryId = 3
                },
                new
                {
                    Id = 4,
                    Name = "Washington",
                    CountryId = 4
                }
            });
        }
    }
}
