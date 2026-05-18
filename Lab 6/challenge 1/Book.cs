using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weeek_06
{
    public class Book
    {
       
        
            public string Title;
            public Author BookAuthor;

            public Book(string title)
                { Title = title; }

            public void AssignAuthor(Author author)
            {
                BookAuthor = author;
            }
            public void DisplayInfo()
            {
                Console.WriteLine("--- Book Information ---");
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {(BookAuthor != null ? BookAuthor.Name : "No author assigned")}");
            }
        
    }
}
