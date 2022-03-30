using System;
using ShopDb;
using ShopDbApp;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

ShopDbContext db = new ShopDbContext();
ShopDbQueries queries = new ShopDbQueries(db);
Menu menu = new Menu(queries);
menu.Start();
