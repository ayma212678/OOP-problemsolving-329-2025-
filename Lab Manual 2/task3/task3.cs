using System;
using System.Collections.Generic;

class ATM
{
    private float Balance;
    private List<string> TransactionHistory;

    //--constructor initiialization
    public ATM(float initialBalance)
    {
        Balance = initialBalance;
        TransactionHistory = new List<string>();
        TransactionHistory.Add("Account opened with balance: " + initialBalance);
    }

    public void Deposit(float amount)
    {
        if (amount <= 0) { Console.WriteLine("Amount must be > 0."); return; }
        Balance += amount;
        TransactionHistory.Add("Deposited: " + amount + " | Balance: " + Balance);
        Console.WriteLine("Deposit successful! Balance: " + Balance);
    }

    public void Withdraw(float amount)
    {
        if (amount <= 0) { Console.WriteLine("Amount must be > 0."); return; }
        if (amount > Balance) { Console.WriteLine("Insufficient funds!"); return; }
        Balance -= amount;
        TransactionHistory.Add("Withdrawn: " + amount + " | Balance: " + Balance);
        Console.WriteLine("Withdrawal successful! Balance: " + Balance);
    }

    public void CheckBalance()
    {
        Console.WriteLine("Current Balance: " + Balance);
    }

    public void ShowHistory()
    {
        Console.WriteLine("\n=== Transaction History ===");
        foreach (string record in TransactionHistory)
            Console.WriteLine("  > " + record);
        Console.WriteLine("===========================\n");
    }
}

class task3
{
    static void Main(string[] args)
    {
        ATM myAccount = new ATM(10000);
        myAccount.Deposit(5000);
        myAccount.Withdraw(3000);
        myAccount.Withdraw(20000); 
        myAccount.CheckBalance();
        myAccount.ShowHistory();
        Console.ReadKey();
    }
}