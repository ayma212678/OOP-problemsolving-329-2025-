namespace Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            //--- seed a default admin account ---
            MUserDL.AddUser(new MUser("admin", "admin123", "admin"));

            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("\n========= Welcome to DepartStore =========");
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        SignIn();
                        Console.ReadKey();
                        break;
                    case 2:
                        SignUp();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            } while (choice != 3);
        }

        //--- sign in existing user ---
        static void SignIn()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username)) { Console.WriteLine("Username cannot be empty."); return; }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) { Console.WriteLine("Password cannot be empty."); return; }

            MUser user = MUserDL.FindUser(username, password);
            if (user == null) { Console.WriteLine("Invalid credentials. Please try again."); return; }

            Console.WriteLine($"Welcome, {user.Username}!");

            if (user.Role == "admin")
                AdminUI.ShowMenu();
            else
                CustomerUI.ShowMenu(user.Username);
        }

        //--- register a new user ---
        static void SignUp()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username)) { Console.WriteLine("Username cannot be empty."); return; }

            if (MUserDL.UsernameExists(username)) { Console.WriteLine("Username already exists. Please choose another."); return; }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password)) { Console.WriteLine("Password cannot be empty."); return; }

            Console.Write("Enter Role (admin / customer): ");
            string role = Console.ReadLine().ToLower();
            if (role != "admin" && role != "customer") { Console.WriteLine("Invalid role. Must be 'admin' or 'customer'."); return; }

            MUserDL.AddUser(new MUser(username, password, role));
            Console.WriteLine("Account created successfully! You can now sign in.");
        }
    }
}