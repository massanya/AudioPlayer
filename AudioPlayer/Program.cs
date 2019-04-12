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
            int min, max, total=0;
            var player = new Player();
            var songs = CreateSongs(out min, out max, ref total);
            player.Songs = songs;
            Console.WriteLine($"{min},{max},{total}");

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
                    case "l":
                        {
                            player.Lock();
                        }
                        break;
                    case "ul":
                        {
                            player.Unlock();
                        }
                        break;
                    case "s":
                        {
                            player.Stop();
                        }
                        break;
                    case "start":
                        {
                            player.Start();
                        }
                        break;
                }


            }
            //player.Playing=true;
            Console.ReadLine();
        }

        private static Song[] CreateSongs(out int min, out int max, ref int total )
        {
            Random rand = new Random();
            Song[] songs = new Song[5];
            int MinDuration=3000, MaxDuration=0, TotalDuration=0;
            for (int i = 0; i < songs.Length; i++)
            {
                var song1 = new Song();
                song1.Title = "Song"+i;
                song1.Duration = rand.Next(3000);
                song1.Artist = new Artist("Nensi");
                songs[i] = song1;
                TotalDuration += song1.Duration;
                if (song1.Duration < MinDuration)
                {
                    MinDuration = song1.Duration;
                }
                if (song1.Duration > MaxDuration)
                {
                    MaxDuration = song1.Duration;
                }
            }
            min = MinDuration;
            max = MaxDuration;
            total = TotalDuration;
            return songs;
        }
    }
}
