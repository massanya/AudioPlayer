using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace AudioPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var song1 = new Song();
            song1.title = "Dim";
            song1.duration = 300;
            song1.Artist = new Artist { name = "Nensi" };
            var song2 = new Song();
            song2.title = "Anaconda";
            song2.duration = 270;
            song2.Artist = new Artist { name = "Nicki Minaj" };
            var player = new Player();
            player.Songs = new[] { song1, song2 };

            while (true)
            {
                switch (ReadLine())
                {
                    case "up":
                        {
                            player.VolumeUp();
                        }
                        break;
                    case "down":
                        {
                            player.VolumeDown();
                        }
                        break;
                    case "p":
                        {
                            player.Play();
                        }
                        break;
                }


            }

            Console.ReadLine();
        }
    }
}
