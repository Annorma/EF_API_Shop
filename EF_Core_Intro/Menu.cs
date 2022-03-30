using System;
using ShopDb;
using ShopDbApp;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class Menu
{
    public ShopDbQueries queries;
    public Menu(ShopDbQueries q)
    {
        queries = q;
    }

    private int CheckMenu()
    {
        Console.Clear();
        Console.WriteLine("1 - Show all workers");
        Console.WriteLine("2 - Show all shops");
        Console.WriteLine("3 - Show all countries");
        Console.WriteLine("4 - Show all cities");
        Console.WriteLine("5 - Show all positions");
        Console.WriteLine("6 - Add country");
        Console.WriteLine("7 - Add city");
        Console.WriteLine("8 - Add shop");
        Console.WriteLine("9 - Add worker");
        Console.WriteLine("10 - Delete city by id");
        Console.WriteLine("11 - Exit");
        int num = 0;
        try
        {
            num = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        if (num < 1 || num > 11)
        {
            Console.WriteLine("Error!\a");
            Console.ReadLine();
            return 0;
        }
        else
        {
            return num;
        }   
    }
    public void Start()
    {
        bool flag = true;
        while(flag)
        {
            int num = CheckMenu();
            if (num == 1)
            {
                Console.Clear();
                var result = queries.GetAllWorkers();
                foreach (var item in result)
                {
                    Console.WriteLine($"Worker #{item.Id} {item.Name} {item.Surname} {item.Salary} {item.Email} {item.PhoneNumber} {item.Position} {item.Shop}");
                }
                Console.ReadKey();
            }
            else if (num == 2)
            {
                Console.Clear();
                var result = queries.GetAllShops();
                foreach (var item in result)
                {
                    Console.WriteLine($"Shop #{item.Id} {item.Name} {item.Address} Workers: {item.Workers.Count} Products: {item.Products.Count} {item.ParkingArea}");
                }
                Console.ReadKey();
            }
            else if (num == 3)
            {
                Console.Clear();
                var result = queries.GetAllCountries();
                foreach (var item in result)
                {
                    Console.WriteLine($"Country #{item.Id} {item.Name}");
                }
                Console.ReadKey();
            }
            else if (num == 4)
            {
                Console.Clear();
                var result = queries.GetAllCities();
                foreach (var item in result)
                {
                    Console.WriteLine($"City #{item.Id} {item.Name} {item.Country.Name}");
                }
                Console.ReadKey();
            }
            else if (num == 5)
            {
                Console.Clear();
                var result = queries.GetAllPositions();
                foreach (var item in result)
                {
                    Console.WriteLine($"Position #{item.Id} {item.Name}");
                }
                Console.ReadKey();
            }
            else if (num == 6)
            {
                Console.Clear();
                Console.WriteLine("New country:");
                Console.Write("Enter new name: ");
                string name = Console.ReadLine();
                queries.AddCountry(name);
                Console.ReadKey();
            }
            else if (num == 7)
            {
                Console.Clear();
                Console.WriteLine("New city:");
                Console.Write("Enter new city name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new country name: ");
                string countryName = Console.ReadLine();
                queries.AddCity(name, countryName);
                Console.ReadKey();
            }
            else if (num == 8)
            {
                Console.Clear();
                Console.WriteLine("New shop: ");
                Console.Write("Enter new shop name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new address: ");
                string address = Console.ReadLine();
                Console.Write("Enter city name: ");
                string cityName = Console.ReadLine();
                queries.AddShop(name, address, cityName);
                Console.ReadKey();
            }
            else if (num == 9)
            {
                Console.Clear();
                Console.WriteLine("New worker:");
                Console.Write("Enter new name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new surname: ");
                string surname = Console.ReadLine();
                Console.Write("Enter new salary: ");
                decimal salary = int.Parse(Console.ReadLine());
                Console.Write("Enter new email: ");
                string email = Console.ReadLine();
                Console.Write("Enter new phone number: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Enter new position id: ");
                int positionId = int.Parse(Console.ReadLine());
                Console.Write("Enter new shop id: ");
                int shopId = int.Parse(Console.ReadLine());
                queries.AddWorker(name, surname, salary, email, phoneNumber, positionId, shopId);
                Console.ReadKey();
            }
            else if (num == 10)
            {
                Console.WriteLine("Enter id: ");
                int cityId = int.Parse(Console.ReadLine());
                queries.DeleteCity(cityId);
            }
            else if (num == 11)
            {
                flag = false;
                Console.Clear();
                Console.WriteLine("Bye!");
            }
        }
    }
}
