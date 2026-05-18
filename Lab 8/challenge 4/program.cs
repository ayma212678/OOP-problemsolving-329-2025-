using System;

class Account
{
    public string accTitle;
    public int accNumber;
    public double balance;
    public void credit(double amount) { balance += amount; }
    public void debit(double amount) { balance -= amount; }
}

class StudentAccount : Account
{
    public double creditLimit = 500000;
}

class Program
{
    static void Main()
    {
        StudentAccount sa = new StudentAccount();
        sa.accTitle = "Ali";
        Console.WriteLine("Account for " + sa.accTitle + " with limit " + sa.creditLimit);
    }
}