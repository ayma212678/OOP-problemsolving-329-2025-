using System;
using System.Collections.Generic;

class Product
{
    public int ID;
    public string Name, Category, Brand, Country;
    public float Price;
    public Product() { ID = 0; Name = "Unknown"; Price = 0; Category = Brand = Country = "N/A"; }
    public Product(int id, string name, float price, string category, string brand, string country)
    {
        ID = id; Name = name; Price = price;
        Category = category; Brand = brand; Country = country;
    }
    public void Display()
    {
        Console.WriteLine("ID: " + ID + " | Name: " + Name + " | Price: " + Price +
                          " | Category: " + Category + " | Brand: " + Brand +
                          " | Country: " + Country);
        Console.WriteLine("----------------------------");
    }
}
class Program
{
    static List<Product> products = new List<Product>();
    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 4)
        {
            Console.WriteLine("\n1.Add Product  2.Show All  3.Total Worth  4.Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) AddProduct();
            else if (choice == 2) { foreach (Product p in products) p.Display(); }
            else if (choice == 3) TotalWorth();
            else if (choice == 4) Console.WriteLine("Goodbye!");
        }
    }
    static void AddProduct()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Price: "); float price = float.Parse(Console.ReadLine());
        Console.Write("Category: "); string cat = Console.ReadLine();
        Console.Write("Brand: "); string brand = Console.ReadLine();
        Console.Write("Country: "); string cntry = Console.ReadLine();
        products.Add(new Product(id, name, price, cat, brand, cntry));
        Console.WriteLine("Product added!");
    }
    static void TotalWorth()
    {
        float total = 0;
        foreach (Product p in products) total += p.Price;
        Console.WriteLine("Total Store Worth: " + total);
    }
}