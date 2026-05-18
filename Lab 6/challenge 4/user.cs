using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_4
{
    public class User
    {
        public string Name;

        public void WritePost(string text)
        {
            Post p = new Post { Content = text, Author = this.Name };
            Console.WriteLine(Name + " posted: " + text);
        }
    }

}

