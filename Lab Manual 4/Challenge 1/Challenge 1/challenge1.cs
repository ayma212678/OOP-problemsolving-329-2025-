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

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            int choice;

            do
            {
                Console.WriteLine("\n===== BOOKSTORE MENU =====");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Search by Title");
                Console.WriteLine("3. Search by ISBN");
                Console.WriteLine("4. Update Stock");
                Console.WriteLine("5. Exit");
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
                else if (choice == 3)
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
                else if (choice == 4)
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

            } while (choice != 5);
        }
    }
}