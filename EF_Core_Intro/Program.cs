using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_Core_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopDb db = new ShopDb();

            foreach (var item in db.Cities)
            {
                Console.WriteLine($"City #{item.Id} {item.Name} {item.Country}");
            }

            foreach (var item in db.Countries)
            {
                Console.WriteLine($"Country #{item.Id} {item.Name}");
            }

            foreach (var item in db.Positions)
            {
                Console.WriteLine($"Position #{item.Id} {item.Name}");
            }

            foreach (var item in db.Categories)
            {
                Console.WriteLine($"Category #{item.Id} {item.Name}");
            }
        }
    }
}
