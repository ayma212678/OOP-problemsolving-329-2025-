using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

class Transaction
{
    public int TransactionId;
    public string ProductName;
    public float Amount;
    public string TransactionDate; 

    //---Default Constructor
    public Transaction()
    {
        TransactionId = 0;
        ProductName = "Unknown";
        Amount = 0.0f;
        TransactionDate = "N/A";
    }

    //---Parameterized Constructor
    public Transaction(int id, string name, float amount, string date)
    {
        TransactionId = id;
        ProductName = name;
        Amount = amount;
        TransactionDate = date;
    }

    //---Copy Constructor
    public Transaction(Transaction t)
    {
        TransactionId = t.TransactionId;
        ProductName = t.ProductName;
        Amount = t.Amount;
        TransactionDate = t.TransactionDate;
    }

    public void Display()
    {
        Console.WriteLine("ID: " + TransactionId);
        Console.WriteLine("Product: " + ProductName);
        Console.WriteLine("Amount: " + Amount);
        Console.WriteLine("Date: " + TransactionDate);
    }
}

class task1
{
    static void Main(string[] args)
    {
        Transaction t1 = new Transaction(101, "Laptop", 75000.0f, "2024-03-01");
        Transaction t2 = new Transaction(t1); // copy constructor

        t2.ProductName = "Mouse";
        t2.Amount = 1500.0f;

        Console.WriteLine("---Original (t1)---");
        t1.Display();

        Console.WriteLine("---Copy (t2) after change---");
        t2.Display();

        Console.ReadKey();
    }
}