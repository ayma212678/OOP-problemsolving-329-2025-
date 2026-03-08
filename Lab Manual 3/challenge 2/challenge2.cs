using System;
using System.Collections.Generic;

class Product
{
    public string Name, Category;
    public float Price;
    public int StockQty, MinStockQty;

    // Default Constructor
    public Product()
    {
        Name = "Unknown"; Category = "General";
        Price = 0; StockQty = 0; MinStockQty = 10;
    }

    // Parameterized Constructor
    public Product(string name, string category, float price, int stock, int minStock)
    {
        Name = name; Category = category; Price = price;
        StockQty = stock; MinStockQty = minStock;
    }

    // Copy Constructor
    public Product(Product p)
    {
        Name = p.Name; Category = p.Category; Price = p.Price;
        StockQty = p.StockQty; MinStockQty = p.MinStockQty;
    }

    // Tax: Groceries=10%, Fresh Fruit=5%, Other=15%
    public float GetSalesTax()
    {
        if (Category == "Groceries") return Price * 0.10f;
        else if (Category == "Fresh Fruit") return Price * 0.05f;
        else return Price * 0.15f;
    }

    public bool NeedsOrdering() { return StockQty < MinStockQty; }

    public void Display()
    {
        Console.WriteLine("Name: " + Name + " | Category: " + Category +
                          " | Price: " + Price + " | Stock: " + StockQty +
                          " | Min Stock: " + MinStockQty +
                          " | Tax: " + GetSalesTax() +
                          " | Needs Order: " + NeedsOrdering());
        Console.WriteLine("----------------------------");
    }
}

class challenge2
{
    static List<Product> products = new List<Product>();

    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine("\n1.Add  2.View All  3.Highest Price  4.Sales Tax  5.Low Stock  6.Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) AddProduct();
            else if (choice == 2) ViewAll();
            else if (choice == 3) HighestPrice();
            else if (choice == 4) ViewTax();
            else if (choice == 5) LowStock();
            else if (choice == 6) Console.WriteLine("Goodbye!");
        }
    }

    static void AddProduct()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Category: "); string cat = Console.ReadLine();
        Console.Write("Price: "); float price = float.Parse(Console.ReadLine());
        Console.Write("Stock Qty: "); int stock = int.Parse(Console.ReadLine());
        Console.Write("Min Stock Qty: "); int min = int.Parse(Console.ReadLine());
        products.Add(new Product(name, cat, price, stock, min));
        Console.WriteLine("Product added!");
    }

    static void ViewAll()
    {
        if (products.Count == 0) { Console.WriteLine("No products yet."); return; }
        foreach (Product p in products) p.Display();
    }

    static void HighestPrice()
    {
        if (products.Count == 0) { Console.WriteLine("No products yet."); return; }
        Product highest = products[0];
        foreach (Product p in products)
            if (p.Price > highest.Price) highest = p;
        Console.WriteLine("\n=== Highest Priced ===");
        highest.Display();
    }

    static void ViewTax()
    {
        foreach (Product p in products)
            Console.WriteLine(p.Name + " (" + p.Category + ") -> Tax: " + p.GetSalesTax());
    }

    static void LowStock()
    {
        bool found = false;
        foreach (Product p in products)
        {
            if (p.NeedsOrdering())
            {
                Console.WriteLine(p.Name + " | Stock: " + p.StockQty + " < Min: " + p.MinStockQty);
                found = true;
            }
        }
        if (!found) Console.WriteLine("All products are sufficiently stocked.");
    }
}