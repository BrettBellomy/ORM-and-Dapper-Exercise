using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DepartmentRepository(conn);
var productRepo = new ProductRepository(conn);

//INSERT DEPARTMENT METHOD
departmentRepo.InsertDepartment("Brett's New Test Department");

//GET ALL DEPARTMENTS METHOD
var departments = departmentRepo.GetAllDepartments();
foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
    Console.WriteLine();
}

//UPDATE PRODUCT METHOD
var productToupdate = productRepo.GetProduct(940);

productToupdate.Name = "Updated";
productToupdate.Price = 12.99;
productToupdate.CategoryID = 1;
productToupdate.OnSale = false;
productToupdate.StockLevel = 1;

productRepo.UpdateProduct(productToupdate);

//DELETE PRODUCT METHOD
////productRepo.DeleteProduct(940);

var products = productRepo.GetAllProdcuts();
foreach (var product in products)
{
    Console.WriteLine("Product ID: " + product.ProductID);
    Console.WriteLine("Name: " + product.Name);
    Console.WriteLine("Price: " + product.Price);
    Console.WriteLine("Catagory ID: " + product.CategoryID);
    Console.WriteLine("On Sale?: " + product.OnSale);
    Console.WriteLine("Stock Level: " + product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}

