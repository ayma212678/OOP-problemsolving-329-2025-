using System;
using System.Collections.Generic;

namespace BookstoreApp
{
    class Book
    {
        public string title;
        public string[] authors = new string[4];
        public int authorCount;
        public string publisher;
        public string isbn;
        public float price;
        public int stock;
        public int yearOfPublication;

        public void showBook()
        {
            Console.WriteLine("Title: " + title);
            Console.Write("Authors: ");
            for (int i = 0; i < authorCount; i++)
                Console.Write(authors[i] + " ");
            Console.WriteLine();
            Console.WriteLine("Publisher: " + publisher);
            Console.WriteLine("ISBN: " + isbn);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Stock: " + stock);
            Console.WriteLine("Year: " + yearOfPublication);
        }

        public bool checkTitle(string t)
        {
            return title == t;
        }

        public bool checkISBN(string s)
        {
            return isbn == s;
        }

        public void updateStock(int amount)
        {
            stock += amount;
        }
    }

    class Member
    {
        public string name;
        public int memberID;
        public List<Book> booksBought = new List<Book>();
        public int numberOfBooksBought;
        public float moneyInBank;
        public float amountSpent;

        public Member()
        {
            name = "";
            memberID = 0;
            numberOfBooksBought = 0;
            moneyInBank = 0;
            amountSpent = 0;
        }

        public Member(string n, int id, float money)
        {
            name = n;
            memberID = id;
            numberOfBooksBought = 0;
            moneyInBank = money;
            amountSpent = 0;
        }

        public void setName(string n)
        {
            name = n;
        }

        public void setID(int id)
        {
            memberID = id;
        }

        public void addBook(Book b)
        {
            booksBought.Add(b);
            numberOfBooksBought++;
        }

        public void updateAmountSpent(float amount)
        {
            amountSpent += amount;
            moneyInBank -= amount;
        }

        public void showMember()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Member ID: " + memberID);
            Console.WriteLine("Books Bought: " + numberOfBooksBought);
            Console.WriteLine("Money in Bank: " + moneyInBank);
            Console.WriteLine("Amount Spent: " + amountSpent);
        }
    }

    class Program
    {
        static List<Book> books = new List<Book>();
        static List<Member> members = new List<Member>();
        static float totalSales = 0;
        static float totalMembershipFee = 0;

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== BOOKSTORE MENU =====");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Search Book by Title");
                Console.WriteLine("3. Search Book by ISBN");
                Console.WriteLine("4. Update Stock of a Book");
                Console.WriteLine("5. Add a Member");
                Console.WriteLine("6. Search Member by Name or ID");
                Console.WriteLine("7. Update Member Information");
                Console.WriteLine("8. Purchase a Book");
                Console.WriteLine("9. Display Total Sales and Membership Stats");
                Console.WriteLine("10. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    addBook();
                else if (choice == 2)
                    searchBookByTitle();
                else if (choice == 3)
                    searchBookByISBN();
                else if (choice == 4)
                    updateStock();
                else if (choice == 5)
                    addMember();
                else if (choice == 6)
                    searchMember();
                else if (choice == 7)
                    updateMember();
                else if (choice == 8)
                    purchaseBook();
                else if (choice == 9)
                    showStats();

            } while (choice != 10);
        }

        static void addBook()
        {
            Book b = new Book();

            Console.Write("Enter Title: ");
            b.title = Console.ReadLine();

            Console.Write("How many authors (max 4): ");
            b.authorCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < b.authorCount; i++)
            {
                Console.Write("Author " + (i + 1) + ": ");
                b.authors[i] = Console.ReadLine();
            }

            Console.Write("Enter Publisher: ");
            b.publisher = Console.ReadLine();

            Console.Write("Enter ISBN: ");
            b.isbn = Console.ReadLine();

            Console.Write("Enter Price: ");
            b.price = float.Parse(Console.ReadLine());

            Console.Write("Enter Stock: ");
            b.stock = int.Parse(Console.ReadLine());

            Console.Write("Enter Year: ");
            b.yearOfPublication = int.Parse(Console.ReadLine());

            books.Add(b);
            Console.WriteLine("Book added!");
        }

        static void searchBookByTitle()
        {
            Console.Write("Enter title to search: ");
            string t = Console.ReadLine();
            bool found = false;

            foreach (Book b in books)
            {
                if (b.checkTitle(t))
                {
                    b.showBook();
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Book not found.");
        }

        static void searchBookByISBN()
        {
            Console.Write("Enter ISBN to search: ");
            string s = Console.ReadLine();
            bool found = false;

            foreach (Book b in books)
            {
                if (b.checkISBN(s))
                {
                    b.showBook();
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Book not found.");
        }

        static void updateStock()
        {
            Console.Write("Enter title or ISBN: ");
            string input = Console.ReadLine();
            bool found = false;

            foreach (Book b in books)
            {
                if (b.checkTitle(input) || b.checkISBN(input))
                {
                    Console.WriteLine("Current stock: " + b.stock);
                    Console.Write("Enter amount (+/-): ");
                    int amount = int.Parse(Console.ReadLine());
                    b.updateStock(amount);
                    Console.WriteLine("New stock: " + b.stock);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Book not found.");
        }

        static void addMember()
        {
            Member m = new Member();

            Console.Write("Enter Name: ");
            m.name = Console.ReadLine();

            Console.Write("Enter Member ID: ");
            m.memberID = int.Parse(Console.ReadLine());

            Console.Write("Enter Money in Bank: ");
            m.moneyInBank = float.Parse(Console.ReadLine());

            // every new member pays $10 membership fee
            m.moneyInBank -= 10;
            totalMembershipFee += 10;

            members.Add(m);
            Console.WriteLine("Member added! $10 membership fee deducted.");
        }

        static void searchMember()
        {
            Console.Write("Search by (1) Name or (2) ID: ");
            int option = int.Parse(Console.ReadLine());
            bool found = false;

            if (option == 1)
            {
                Console.Write("Enter name: ");
                string n = Console.ReadLine();

                foreach (Member m in members)
                {
                    if (m.name == n)
                    {
                        m.showMember();
                        found = true;
                    }
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                foreach (Member m in members)
                {
                    if (m.memberID == id)
                    {
                        m.showMember();
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine("Member not found.");
        }

        static void updateMember()
        {
            Console.Write("Enter member name: ");
            string n = Console.ReadLine();
            bool found = false;

            foreach (Member m in members)
            {
                if (m.name == n)
                {
                    Console.WriteLine("1. Update Name");
                    Console.WriteLine("2. Update ID");
                    Console.WriteLine("3. Update Both");
                    Console.Write("Enter choice: ");
                    int option = int.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        Console.Write("Enter new name: ");
                        m.setName(Console.ReadLine());
                        Console.WriteLine("Name updated!");
                    }
                    else if (option == 2)
                    {
                        Console.Write("Enter new ID: ");
                        m.setID(int.Parse(Console.ReadLine()));
                        Console.WriteLine("ID updated!");
                    }
                    else if (option == 3)
                    {
                        Console.Write("Enter new name: ");
                        m.setName(Console.ReadLine());
                        Console.Write("Enter new ID: ");
                        m.setID(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Name and ID updated!");
                    }
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Member not found.");
        }

        static void purchaseBook()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Member ID (0 if non-member): ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter book title to purchase: ");
            string title = Console.ReadLine();

            Console.Write("Enter quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Book foundBook = null;
            foreach (Book b in books)
            {
                if (b.checkTitle(title))
                {
                    foundBook = b;
                    break;
                }
            }

            if (foundBook == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (foundBook.stock < qty)
            {
                Console.WriteLine("Not enough stock.");
                return;
            }

            float totalCost = foundBook.price * qty;

            //---F. for non-member purchase
            if (id == 0)
            {
                foundBook.updateStock(-qty);
                totalSales += totalCost;
                Console.WriteLine("Purchase successful! Total: " + totalCost);
            }
            else
            {
                //--- F.for finding the member
                Member foundMember = null;
                foreach (Member m in members)
                {
                    if (m.memberID == id && m.name == name)
                    {
                        foundMember = m;
                        break;
                    }
                }

                if (foundMember == null)
                {
                    Console.WriteLine("Member not found.");
                    return;
                }

                //--H. for 5% discount for members
                float discount = totalCost * 0.05f;
                totalCost = totalCost - discount;

                //--H.  every 11th book gets average of last 10 as discount
                if ((foundMember.numberOfBooksBought + qty) % 11 == 0)
                {
                    float avg = foundMember.amountSpent / 10;
                    Console.WriteLine("Every 11th book bonus! Discount of: " + avg);
                    totalCost -= avg;
                    foundMember.amountSpent = 0;
                }

                foundMember.updateAmountSpent(totalCost);
                foundMember.addBook(foundBook);
                foundBook.updateStock(-qty);
                totalSales += totalCost;

                Console.WriteLine("Purchase successful!");
                Console.WriteLine("Discount applied: " + discount);
                Console.WriteLine("Total paid: " + totalCost);
            }
        }

        static void showStats()
        {
            Console.WriteLine("\n===== SALES & MEMBERSHIP STATS =====");
            Console.WriteLine("Total Sales: " + totalSales);
            Console.WriteLine("Total Members: " + members.Count);
            Console.WriteLine("Total Membership Fee Collected: " + totalMembershipFee);
        }
    }
}