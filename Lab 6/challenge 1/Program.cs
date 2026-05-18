using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weeek_06
{
    internal class Program
    {
        static void Main()
        {
           
          
            {
                Author auth = new Author("Robert Greene");
                Book myBook = new Book("The 48 Laws of Power");

                myBook.AssignAuthor(auth);
                myBook.DisplayInfo();

                Console.ReadKey();
            }
        }
    } 
}
