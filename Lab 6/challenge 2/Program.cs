using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_2
{
    
    
        static void Main()
        {
        playlist myGymList = new playlist("Hardcore Gym Mix");

     
        song song1 = new song("Lose Yourself", "Eminem");
        song song2 = new song("The Business", "Tiësto");
        song song3 = new song("Stronger", "Kanye West");

    
        myGymList.AddSong(song1);
        myGymList.AddSong(song2);
        myGymList.AddSong(song3);

        
        myGymList.DisplayPlaylist();

       
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    
        }
    
}
