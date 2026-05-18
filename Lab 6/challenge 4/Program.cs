using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_4
{
    internal class Program
    {
        static void Main()
        {
            User user1 = new User { Name = "Alice" };
            User user2 = new User { Name = "Bob" };

            Post myPost = new Post
            {
                Content = "Coding is fun!",
                Author = user1.Name
            };

            
            Comment reply = new Comment
            {
                Text = "I agree!",
                CommenterName = user2.Name
            };
            myPost.Comments.Add(reply);

            
            myPost.Likes++;

        
            Console.WriteLine(myPost.Author + " posted: " + myPost.Content);
            Console.WriteLine("Likes: " + myPost.Likes);
            Console.WriteLine("Comment by " + myPost.Comments[0].CommenterName + ": " + myPost.Comments[0].Text);
        }
    }
    }


