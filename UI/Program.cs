using System;
using DL.Entities;
using BL;
using UI;
using DL;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UI
{
    class Program
    {
      static void Main(string[] args)
        {

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        string connectionString = configuration.GetConnectionString("MyTest");

    DbContextOptions<MyTestContext> options = new DbContextOptionsBuilder<MyTestContext>()
        .UseSqlServer(connectionString)
        .Options;

    var context = new MyTestContext(options);
  
            IMenu menu = new MainMenu(new ReviewBL(new ReviewRepo(context)));
            menu.Start();
        }
    }
}
