using System;
using System.Collections.Generic;
using System.IO;

class MUser
{
    public string Username, Password, Role;

    public MUser() { Username = "guest"; Password = "1234"; Role = "User"; }

    public MUser(string username, string password, string role)
    {
        Username = username; Password = password; Role = role;
    }
}

class task6
{
    static List<MUser> users = new List<MUser>();
    static string filePath = "users.txt";

    static void Main(string[] args)
    {
        LoadUsersFromFile();
        int choice = 0;
        while (choice != 3)
        {
            Console.WriteLine("\n1.Sign Up  2.Sign In  3.Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) SignUp();
            else if (choice == 2) SignIn();
            else if (choice == 3) Console.WriteLine("Goodbye!");
        }
    }

    static void SignUp()
    {
        Console.Write("Username: "); string username = Console.ReadLine();
        foreach (MUser u in users)
        {
            if (u.Username == username) { Console.WriteLine("Username taken!"); return; }
        }
        Console.Write("Password: "); string password = Console.ReadLine();
        Console.Write("Role (Admin/User): "); string role = Console.ReadLine();

        MUser newUser = new MUser(username, password, role);
        users.Add(newUser);
        File.AppendAllText(filePath, username + "," + password + "," + role + "\n");
        Console.WriteLine("Signed up successfully!");
    }

    static void SignIn()
    {
        Console.Write("Username: "); string username = Console.ReadLine();
        Console.Write("Password: "); string password = Console.ReadLine();
        foreach (MUser u in users)
        {
            if (u.Username == username && u.Password == password)
            {
                Console.WriteLine("Welcome, " + u.Username + "! Role: " + u.Role);
                return;
            }
        }
        Console.WriteLine("Invalid username or password.");
    }

    static void LoadUsersFromFile()
    {
        if (!File.Exists(filePath)) return;
        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3)
                users.Add(new MUser(parts[0], parts[1], parts[2]));
        }
        Console.WriteLine(users.Count + " user(s) loaded.");
    }
}