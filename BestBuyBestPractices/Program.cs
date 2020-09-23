using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            var departments = repo.GetAllDepartments();
            repo.InsertDepartment("Perfume");
            foreach (var item in departments)
            {
                Console.WriteLine($"{item.DepartmentID} {item.Name}");
            }



            Console.WriteLine("asdfa");
            var repo2 = new DapperProductRepository(conn);
            var products = repo2.GetAllProducts();

            Console.WriteLine("asdfasdfasdfa");
        
            foreach (var item in products)
            {   
                Console.WriteLine($"{item.ProductId} {item.Name} {item.Price} {item.CategoryID} {item.OnSale} {item.StockLevel}");
            }

            repo2.CreateProduct("Mac Book", 2000, 2);


        }
    }
}
