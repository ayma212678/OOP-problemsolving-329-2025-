using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge_2
{


    public class playlist
    {
        public string PlaylistName;

        private List<song> songs = new List<song>();

        public playlist(string name)
        {
            PlaylistName = name;
        }


        public void AddSong(song s)
        {
            songs.Add(s);
            Console.WriteLine($"Successfully added '{s.Title}' to {PlaylistName}");
        }

        public void DisplayPlaylist()
        {
            Console.WriteLine($"\n--- Playlist: {PlaylistName} ---");
            if (songs.Count == 0)
            {
                Console.WriteLine("The playlist is currently empty.");
            }
            else
            {
                foreach (var song in songs)
                {
                    Console.WriteLine($"- {song.Title} (by {song.Artist})");
                }
            }
            Console.WriteLine("----------------------------\n");
        }
    }
}

           