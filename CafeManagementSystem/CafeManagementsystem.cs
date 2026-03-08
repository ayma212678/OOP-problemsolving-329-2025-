using EZInput;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace CafeManagementSystem
{
    internal class CafeManagementsystem
    {
        //--- for colours ---
        static void ColorWrite(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        //-- arrays for data storage---
        // for admin
        static string[] adminusername = new string[1];
        static string[] adminpassword = new string[1];
        static int admincount = 0;

        // for employee
        static string[] employeeusername = new string[15];
        static string[] employeepassword = new string[15];
        static int employeecount = 0;

        //--for food menu items and prices--

        static string[,] menu = new string[50, 2];      //2-D arrays
        static int menucount = 0;

        //for order items
        static string[] ordername = new string[100];
        static int[] orderprice = new int[100];
        static int ordercount = 0;


        static void Main(string[] args)
        {
            menucount = LoadMenuFromFile(menu);
            if (menucount == 0)  //--menu
            {
                menu[0, 0] = "Tea"; menu[0, 1] = "100";
                menu[1, 0] = "Coffee"; menu[1, 1] = "150";
                menu[2, 0] = "Cappuccino"; menu[2, 1] = "200";
                menu[3, 0] = "Sandwich"; menu[3, 1] = "300";
                menu[4, 0] = "Chocolate_Cake"; menu[4, 1] = "250";
                menu[5, 0] = "Muffin"; menu[5, 1] = "150";
                menucount = 6;
                SaveMenuToFile(menu, menucount);
            }

            //welcome page 
            WelcomePage();
            while (true)
            {
                Console.Clear();
                int choice = MainMenu();
                if (choice == 1)
                {
                    // Sign Up options
                    int signup;
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. Employee");
                    Console.Write("Enter your choice: ");
                    string signupInput = Console.ReadLine();
                    int.TryParse(signupInput, out signup);

                    if (signup == 1)
                    {
                        adminsignup();
                    }
                    else if (signup == 2)
                    {
                        employeesignup();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice");
                        Thread.Sleep(350);
                    }
                    Console.ReadKey();
                }

                // Sign In option
                else if (choice == 2)
                {
                    string u, p;
                    Console.WriteLine("Enter Username: ");
                    u = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    p = Console.ReadLine();

                    // if user credentials are of admin
                    if (CheckAdminFromFile(u, p))
                    {
                        while (true)
                        {
                            Console.Clear();
                            int adminchoice = adminmenu();

                            if (adminchoice == 1)
                            {
                                DisplayMenu(menu, menucount);
                            }
                            else if (adminchoice == 2)
                            {
                                menucount = AddMenuItem(menu, ref menucount);
                            }
                            else if (adminchoice == 3)
                            {
                                menucount = DeleteMenuItem(menu, ref menucount);
                            }
                            else if (adminchoice == 4)
                                break;
                        }
                    }

                    // if user credentials are of employee
                    else if (CheckEmployeeFromFile(u, p))
                    {
                        while (true)
                        {
                            Console.Clear();
                            int employeechoice = employeemenu();

                            if (employeechoice == 1)
                            {
                                DisplayMenu(menu, menucount);
                            }
                            else if (employeechoice == 2)
                            {
                                ordercount = CreateOrder(menu, menucount, ordername, orderprice, ref ordercount);
                            }
                            else if (employeechoice == 3)
                            {
                                ordercount = DeleteOrderItem(ordername, orderprice, ref ordercount);
                            }
                            else if (employeechoice == 4)
                            {
                                DisplayBill(ordername, orderprice, ordercount);
                            }
                            else if (employeechoice == 5)
                            {
                                ordercount = 0;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Username or Password Entered");
                        Console.ResetColor();
                        Thread.Sleep(250);
                        Console.ReadKey();
                    }
                }

                // if user chooses customer option
                else if (choice == 3)
                {
                    while (true)
                    {
                        Console.Clear();
                        int customerchoice = customermenu();

                        if (customerchoice == 1)
                        {
                            DisplayMenu(menu, menucount);
                        }
                        else if (customerchoice == 2)
                        {
                            ordercount = CreateOrder(menu, menucount, ordername, orderprice, ref ordercount);
                        }
                        else if (customerchoice == 3)
                        {
                            ordercount = DeleteOrderItem(ordername, orderprice, ref ordercount);
                        }
                        else if (customerchoice == 4)
                        {
                            DisplayBill(ordername, orderprice, ordercount);
                        }
                        else if (customerchoice == 5)
                        {
                            ordercount = 0;
                            break;
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("-----Exiting program-----");
                    Thread.Sleep(250);
                    return;
                }
                else
                {
                    Console.WriteLine("-----Invalid choice, Try again (choose from 1,2,3,4)-----");
                    Thread.Sleep(250);
                }
            }

        }
        static void WelcomePage()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("===================================================================================================================================");
            Thread.Sleep(250);
            Console.WriteLine("||                         _    _ _____ _     _____ ________  ___ _____                                                          ||");
            Thread.Sleep(250);
            Console.WriteLine("||                        | |  | |  ___| |   /  __ \\  _  |  \\/  ||  ___|                                                         ||");
            Thread.Sleep(250);
            Console.WriteLine("||                        | |  | | |__ | |   | /  \\/ | | | .  . || |__                                                           ||");
            Thread.Sleep(250);
            Console.WriteLine("||                        | |/\\| |  __|| |   | |   | | | | |\\/| ||  __|                                                          ||");
            Thread.Sleep(250);
            Console.WriteLine("||                        \\  /\\  / |___| |___| \\__/\\ \\_/ / |  | || |___                                                          ||");
            Thread.Sleep(250);
            Console.WriteLine("||                         \\/  \\/\\____/\\_____/\\____/\\___/\\_|  |_/\\____/                                                          ||");
            Thread.Sleep(250);
            Console.WriteLine("||                                                                                                                               ||");
            Thread.Sleep(250);
            Console.WriteLine("||                                                                                                                               ||");
            Thread.Sleep(250);
            Console.WriteLine("||             ( (                        _                       ((                                                             ||");
            Thread.Sleep(250);
            Console.WriteLine("||             ) )                       | |                      ) )                                                            ||");
            Thread.Sleep(250);
            Console.WriteLine("||          ........                     | |_ ___               ........                                                         ||");
            Thread.Sleep(250);
            Console.WriteLine("||          |       |]                   | __/ _ \\             |        |]                                                       ||");
            Thread.Sleep(250);
            Console.WriteLine("||          \\      /                     | || (_) |             \\      /                                                         ||");
            Thread.Sleep(250);
            Console.WriteLine("||           `----'                       \\__\\___/               `----'                                                          ||");
            Thread.Sleep(250);
            Console.WriteLine("||                                                                                                                               ||");
            Thread.Sleep(250);
            Console.WriteLine("||     _____       __      ___  ___                                                  _     _____           _                     ||");
            Thread.Sleep(250);
            Console.WriteLine("||    /  __ \\     / _|     |  \\/  |                                                 | |   /  ___|         | |                    ||");
            Thread.Sleep(250);
            Console.WriteLine("||   |  /  \\/ ___| |_ ___  | .  . | __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_  \\ `--. _   _ ___| |_ ___ _ __ ___      ||");
            Thread.Sleep(250);
            Console.WriteLine("||   | |    / _` |  _/ _ \\ | |\\/| |/ _` | '_ \\ / _` |/ _` |/ _ \\ '_ ` _ \\ / _ \\ '_ \\| __|  `--. \\ | | / __| __/ _ \\ '_ ` _ \\     ||");
            Thread.Sleep(250);
            Console.WriteLine("||   | \\__/\\ (_| | ||  __/ | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_  /\\__/ / |_| \\__ \\ ||  __/ | | | | |    ||");
            Thread.Sleep(250);
            Console.WriteLine("||    \\____/\\__,_|_| \\___| \\_|  |_/\\__,_|_| |_|\\__,_|\\__, |\\___|_| |_| |_|\\___|_| |_|\\__| \\____/ \\__, |___/\\__\\___|_| |_| |_|    ||");
            Thread.Sleep(250);
            Console.WriteLine("||                                                   __/ |                                         __/ |                         ||");
            Thread.Sleep(250);
            Console.WriteLine("||                                                  |___/                                         |___/                          ||");
            Thread.Sleep(250);
            Console.WriteLine("===================================================================================================================================");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        static int MainMenu()         //--Main Menu
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================");
            Thread.Sleep(100);
            Console.WriteLine("===== Main Menu ===== ");
            Thread.Sleep(100);
            Console.WriteLine("====================== ");
            Console.WriteLine("Choose your option:");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign in ");
            Console.WriteLine("3. Customer ");
            Console.WriteLine("4. Exit ");
            Console.WriteLine("==========================");
            Console.ResetColor();
            Thread.Sleep(300);
            int choice;
            Console.WriteLine("Enter Choice: ");
            string input = Console.ReadLine();
            Console.Clear();
            if (int.TryParse(input, out choice))
            {
                return choice;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                Thread.Sleep(250);
                return MainMenu();
            }
        }

        //--Admin Menu--
        static int adminmenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            int adminchoice;
            Console.WriteLine("====================== ");
            Thread.Sleep(100);
            Console.WriteLine("===== Admin Panel =====");
            Thread.Sleep(100);
            Console.WriteLine("====================== ");
            Thread.Sleep(100);
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. Add Item to Menu");
            Console.WriteLine("3. Delete Item from Menu");
            Console.WriteLine("4. Log Out");
            Console.WriteLine("==========================");
            Console.ResetColor();
            Thread.Sleep(200);

            Console.WriteLine("Enter Choice: ");
            string input = Console.ReadLine();
            int.TryParse(input, out adminchoice);
            return adminchoice;
        }

        //--Employee Menu--
        static int employeemenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int employeechoice;
            Console.WriteLine("====================== ");
            Thread.Sleep(100);
            Console.WriteLine("===== Employee Panel =====");
            Thread.Sleep(100);
            Console.WriteLine("====================== ");
            Thread.Sleep(100);
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. Create Order");
            Console.WriteLine("3. Delete Order Item");
            Console.WriteLine("4. Display Bill");
            Console.WriteLine("5. Log Out");
            Console.WriteLine("==========================");
            Thread.Sleep(100);
            Console.ResetColor();
            Console.WriteLine("Enter choice: ");
            Thread.Sleep(100);

            Console.WriteLine("Enter Choice: ");
            string input = Console.ReadLine();
            int.TryParse(input, out employeechoice);
            return employeechoice;
        }

        //--Customer Menu--
        static int customermenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int customerchoice;
            Console.WriteLine("====================== ");
            Thread.Sleep(100);
            Console.WriteLine("===== Customer Panel =====");
            Thread.Sleep(100);
            Console.WriteLine("====================== ");
            Thread.Sleep(100);
            Console.WriteLine("1. View Menu");
            Console.WriteLine("2. Create Order");
            Console.WriteLine("3. Delete Order Item");
            Console.WriteLine("4. Display Bill");
            Console.WriteLine("5. Log Out");
            Console.WriteLine("==========================");
            Console.ResetColor();

            Console.WriteLine("Enter Choice: ");
            string input = Console.ReadLine();
            int.TryParse(input, out customerchoice);
            return customerchoice;
        }

        //--admin sign up and saves to file--
        static void adminsignup()
        {
            string username, password;
            //--admin username--   
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" >--Username can only contain Alphabets! ");
            Thread.Sleep(250);
            Console.WriteLine(" >--Username must begin with Capital Letter! ");
            Thread.Sleep(250);
            Console.WriteLine(" >--Username must contain 4 or more letters!");
            Console.ResetColor();
            Thread.Sleep(250);
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.ResetColor();
            Console.WriteLine("Enter Admin Username: ");
            username = Console.ReadLine();
            if (!isValidUsername(username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Username Entered");
                Console.ResetColor();
                Thread.Sleep(250);
                return;
            }
            //--admin password--
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(" >--Password must contain 4 or more letters! ");
            Console.WriteLine(" >--Password must contain one DIGIT and one Special Character! ");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.ResetColor();

            Console.WriteLine("Enter Admin Password: ");
            password = Console.ReadLine();
            if (!isValidPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Password Entered");
                Console.ResetColor();
                Thread.Sleep(250);
                return;
            }
            SaveAdminToFile(username, password);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Admin account created successfully");
            Console.ResetColor();
            Thread.Sleep(500);
        }

        //--employee sign up and saves to file--
        static void employeesignup()
        {
            string username, password;
            //employee username
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" >--Username can only contain Alphabets! ");
            Console.WriteLine(" >--Username must begin with Capital Letter! ");
            Console.WriteLine(" >--Username must contain 4 or more letters!");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.ResetColor();
            Console.WriteLine("Enter Employee Username: ");
            username = Console.ReadLine();
            if (!isValidUsername(username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Username Entered");
                Console.ResetColor();
                Thread.Sleep(500);
                return;
            }
            //employee password
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" >--Password must contain 4 or more letters! ");
            Thread.Sleep(250);
            Console.WriteLine(" >--Password must contain one DIGIT and one Special Character! ");
            Thread.Sleep(250);
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.ResetColor();
            Console.WriteLine("Enter Employee Password: ");
            password = Console.ReadLine();
            if (!isValidPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Password Entered");
                Console.ResetColor();
                Thread.Sleep(250);
                return;
            }
            SaveEmployeeToFile(username, password);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Employee account created successfully");
            Console.ResetColor();
            Thread.Sleep(250);
        }

        //username validation
        static bool isValidUsername(string username)
        {
            int count = 0;
            if (username.Length < 4)
            {
                return false;
            }
            if (!(username[0] >= 'A' && username[0] <= 'Z'))
            {
                return false;
            }
            for (int i = 0; i < username.Length; i++)
            {
                if (!((username[i] >= 'A' && username[i] <= 'Z') || (username[i] >= 'a' && username[i] <= 'z')))
                {
                    return false;
                }
            }
            return true;
        }

        //password validation
        static bool isValidPassword(string password)
        {
            int count = 0;
            bool digitfound = false;
            bool specialcharfound = false;

            if (password.Length < 4)
            {
                return false;
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= '0' && password[i] <= '9')
                {
                    digitfound = true;
                }
                else if (!((password[i] >= 'A' && password[i] <= 'Z') || (password[i] >= 'a' && password[i] <= 'z')))
                {
                    specialcharfound = true;
                }
                if (digitfound && specialcharfound)
                    return true;
            }
            return false;
        }

        //--diplaying menu--
        static void DisplayMenu(string[,] menu, int menucount)
        {
            for (int i = 0; i < menucount; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine((i + 1) + ". " + menu[i, 0] + " - Rs." + menu[i, 1]);
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        //--Menu Update: Adding Item to Menu (CRUD)--

        static int AddMenuItem(string[,] menu, ref int menucount)
        {
            Console.WriteLine("Enter New Menu Item:");
            Console.WriteLine("----> No Spaces allowed, use '_' instead ----");
            string itemName = Console.ReadLine();
            menu[menucount, 0] = itemName;

            Console.WriteLine("Enter Price of New Item:");
            string priceInput = Console.ReadLine();
            menu[menucount, 1] = priceInput;

            if (!IsValidPrice(priceInput))
            {
                Console.WriteLine("Invalid Price");
                Thread.Sleep(250);
                return menucount;
            }

            menucount++;
            SaveMenuToFile(menu, menucount);
            Console.WriteLine("Item added successfully");
            Thread.Sleep(250);
            return menucount;
        }

        //--New Item Price validation
        static bool IsValidPrice(string price)
        {
            if (price.Length == 0)
                return false;

            foreach (char c in price)
            {
                if (!char.IsDigit(c)) // only digits allowed
                    return false;
            }

            if (!int.TryParse(price, out int value))
                return false;

            if (value <= 0)
                return false;

            return true;
        }

        //--Menu udpate: Item Removal with file handling (CRUD)--
        static int DeleteMenuItem(string[,] menu, ref int menucount)
        {
            DisplayMenu(menu, menucount);

            Console.WriteLine("Enter Number of Item to Delete:");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(700);
                return menucount;
            }

            number--; // 

            if (number < 0 || number >= menucount)
            {
                Console.WriteLine("--Invalid Item Number--");
                Thread.Sleep(700);
                return menucount;
            }

            // 
            for (int i = number; i < menucount - 1; i++)
            {
                menu[i, 0] = menu[i + 1, 0];
                menu[i, 1] = menu[i + 1, 1];
            }

            menucount--;
            SaveMenuToFile(menu, menucount);

            Console.WriteLine("--Item has been deleted successfully--");
            Thread.Sleep(250);
            return menucount;
        }

        //create order
        static int CreateOrder(string[,] menu, int menucount, string[] ordername, int[] orderprice, ref int ordercount)
        {
            while (true)
            {
                DisplayMenu(menu, menucount);

                Console.Write("Enter Item number to order: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    Thread.Sleep(250);
                    Console.ReadKey();
                    continue;
                }

                choice--; //

                if (choice < 0 || choice >= menucount)
                {
                    Console.WriteLine("Invalid Item number entered");
                    Thread.Sleep(250);
                    Console.ReadKey();
                    continue;
                }

                ordername[ordercount] = menu[choice, 0];

                if (!IsValidPrice(menu[choice, 1]))
                {
                    Console.WriteLine("Wrong price entered in menu");
                    Thread.Sleep(250);
                    Console.ReadKey();
                    return ordercount;
                }

                orderprice[ordercount] = int.Parse(menu[choice, 1]);
                ordercount++;

                Console.Write("Do you want to add more Items? (press 'y' for yes and 'n' for no): ");
                string moreInput = Console.ReadLine();
                if (moreInput == null) moreInput = "";
                if (moreInput != "y" && moreInput != "Y")
                {
                    break;
                }
                Console.ReadKey();
            }

            return ordercount;
        }

        //delete order
        static int DeleteOrderItem(string[] ordername, int[] orderprice, ref int ordercount)
        {
            if (ordercount == 0)
            {
                Console.WriteLine("No items in the order yet");
                Console.ReadKey();
                return ordercount;
            }

            Console.WriteLine("Ordered Items:");
            for (int i = 0; i < ordercount; i++)
            {
                Console.WriteLine($"{i + 1}. {ordername[i],-20} --Rs. {orderprice[i]}");
            }

            Console.Write("Enter item number to delete: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Invalid input");
                Thread.Sleep(700);
                Console.ReadKey();
                return ordercount;
            }

            number--; //

            if (number < 0 || number >= ordercount)
            {
                Console.WriteLine("Invalid Number Entered");
                Thread.Sleep(700);
                Console.ReadKey();
                return ordercount;
            }

            for (int i = number; i < ordercount - 1; i++)
            {
                ordername[i] = ordername[i + 1];
                orderprice[i] = orderprice[i + 1];
            }

            ordercount--;
            Console.WriteLine("Item removed successfully");
            Console.ReadKey();
            return ordercount;
        }

        //--display bill
        static void DisplayBill(string[] ordername, int[] orderprice, int ordercount)
        {
            if (ordercount == 0)
            {
                Console.WriteLine("No items ordered yet");
                Console.ReadKey();
                return;
            }

            int total = 0;
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("==========================");
            Thread.Sleep(700);
            Console.WriteLine("========FINAL BILL========");
            Thread.Sleep(700);
            Console.WriteLine("==========================");
            Console.WriteLine($"{"Items",-20} {"Price",-10}");
            Console.WriteLine("------------------------------");
            Console.ResetColor();

            for (int i = 0; i < ordercount; i++)
            {
                Console.WriteLine($"{ordername[i],-20} --Rs. {orderprice[i]}");
                total += orderprice[i];
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------------------");
            Console.WriteLine($"{"Total Amount:",-20} --Rs. {total}");
            Console.WriteLine("==============================");
            Console.ResetColor();
            Console.ReadKey();
        }

        //--file handling for menu
        static void SaveMenuToFile(string[,] menu, int menucount)
        {
            using (StreamWriter file = new StreamWriter("menu.txt"))
            {
                for (int i = 0; i < menucount; i++)
                {
                    file.WriteLine($"{menu[i, 0]} {menu[i, 1]}");
                }
            }
        }
        static int LoadMenuFromFile(string[,] menu)
        {
            if (!File.Exists("menu.txt"))
                return 0;

            string[] lines = File.ReadAllLines("menu.txt");
            int count = 0;

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length >= 2)
                {
                    menu[count, 0] = parts[0];
                    menu[count, 1] = parts[1];
                    count++;
                }
            }

            return count;
        }

        //admin sign up file handling
        static void SaveAdminToFile(string username, string password)
        {
            // 'true' = append so multiple admins can be saved
            using (StreamWriter file = new StreamWriter("admin.txt", true))
            {
                file.WriteLine($"{username} {password}");
            }
        }

        static bool CheckAdminFromFile(string username, string password)
        {
            if (!File.Exists("admin.txt"))
                return false;

            using (StreamReader file = new StreamReader("admin.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 2)
                    {
                        string u = parts[0];
                        string p = parts[1];
                        if (u == username && p == password)
                            return true;
                    }
                }
            }
            return false;
        }

        //file handling for employee sign up
        static void SaveEmployeeToFile(string username, string password)
        {
            using (StreamWriter file = new StreamWriter("employee.txt", true))
            {
                file.WriteLine($"{username} {password}");
            }
        }

        static bool CheckEmployeeFromFile(string username, string password)
        {
            if (!File.Exists("employee.txt"))
                return false;

            using (StreamReader file = new StreamReader("employee.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 2)
                    {
                        string u = parts[0];
                        string p = parts[1];
                        if (u == username && p == password)
                            return true;
                    }
                }
            }
            return false;
        }
    } //class
} //namespace