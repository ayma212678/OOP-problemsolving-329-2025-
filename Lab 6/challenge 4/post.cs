using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_4
{
     
         public class Post
        {
            public string Content;
            public string Author;
            public int Likes;
            public List<Comment> Comments = new List<Comment>();
    }
}
