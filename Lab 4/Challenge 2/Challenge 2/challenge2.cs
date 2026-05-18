using System;
using System.Collections.Generic;

namespace MemberApp
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

        public void showBooksBought()
        {
            if (numberOfBooksBought == 0)
            {
                Console.WriteLine("No books bought yet.");
                return;
            }
            Console.WriteLine("Books bought by " + name + ":");
            foreach (Book b in booksBought)
            {
                b.showBook();
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<Member> members = new List<Member>();
            int choice;

            do
            {
                Console.WriteLine("\n===== MEMBER MENU =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Buy a Book");
                Console.WriteLine("4. Show Member by Name");
                Console.WriteLine("5. Show Member by ID");
                Console.WriteLine("6. Update Member Name");
                Console.WriteLine("7. Update Member ID");
                Console.WriteLine("8. Show Books Bought by Member");
                Console.WriteLine("9. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
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
                else if (choice == 2)
                {
                    Member m = new Member();

                    Console.Write("Enter Name: ");
                    m.name = Console.ReadLine();

                    Console.Write("Enter Member ID: ");
                    m.memberID = int.Parse(Console.ReadLine());

                    Console.Write("Enter Money in Bank: ");
                    m.moneyInBank = float.Parse(Console.ReadLine());

                    members.Add(m);
                    Console.WriteLine("Member added!");
                }
                else if (choice == 3)
                {
                    Console.Write("Enter member name: ");
                    string mname = Console.ReadLine();
                    Member foundMember = null;

                    foreach (Member m in members)
                    {
                        if (m.name == mname)
                        {
                            foundMember = m;
                            break;
                        }
                    }

                    if (foundMember == null)
                    {
                        Console.WriteLine("Member not found.");
                    }
                    else
                    {
                        Console.Write("Enter book title to buy: ");
                        string btitle = Console.ReadLine();
                        Book foundBook = null;

                        foreach (Book b in books)
                        {
                            if (b.checkTitle(btitle))
                            {
                                foundBook = b;
                                break;
                            }
                        }

                        if (foundBook == null)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        else if (foundBook.stock == 0)
                        {
                            Console.WriteLine("Book out of stock.");
                        }
                        else
                        {
                            foundMember.addBook(foundBook);
                            foundMember.updateAmountSpent(foundBook.price);
                            foundBook.updateStock(-1);
                            Console.WriteLine("Book bought successfully!");
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter name to search: ");
                    string n = Console.ReadLine();
                    bool found = false;

                    foreach (Member m in members)
                    {
                        if (m.name == n)
                        {
                            m.showMember();
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Member not found.");
                }
                else if (choice == 5)
                {
                    Console.Write("Enter ID to search: ");
                    int id = int.Parse(Console.ReadLine());
                    bool found = false;

                    foreach (Member m in members)
                    {
                        if (m.memberID == id)
                        {
                            m.showMember();
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Member not found.");
                }
                else if (choice == 6)
                {
                    Console.Write("Enter current name: ");
                    string n = Console.ReadLine();
                    bool found = false;

                    foreach (Member m in members)
                    {
                        if (m.name == n)
                        {
                            Console.Write("Enter new name: ");
                            m.setName(Console.ReadLine());
                            Console.WriteLine("Name updated!");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Member not found.");
                }
                else if (choice == 7)
                {
                    Console.Write("Enter member name: ");
                    string n = Console.ReadLine();
                    bool found = false;

                    foreach (Member m in members)
                    {
                        if (m.name == n)
                        {
                            Console.Write("Enter new ID: ");
                            m.setID(int.Parse(Console.ReadLine()));
                            Console.WriteLine("ID updated!");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Member not found.");
                }
                else if (choice == 8)
                {
                    Console.Write("Enter member name: ");
                    string n = Console.ReadLine();
                    bool found = false;

                    foreach (Member m in members)
                    {
                        if (m.name == n)
                        {
                            m.showBooksBought();
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Member not found.");
                }

            } while (choice != 9);
        }
    }
}