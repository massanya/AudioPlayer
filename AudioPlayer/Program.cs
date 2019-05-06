using System;
using System.Collections;
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
            Player player = new Player(new ClassicSkin());
            Random rand = new Random();
			
			Console.WriteLine($"{0}");
            //var songs = CreateSongs(out min, out max, ref total);
			
			
			List<Song> songs = new List<Song>();
            for (int i = 0; i < 8; i++)
            {
                
                var song = CreateSong($"song {i}" , Convert.ToBoolean(rand.Next(2)));
                songs.Add(song);
            }
            player.Add(songs);

            List<Song> songsGenre = new List<Song>();
            for (int i = 0; i < 8; i++)
            {
	            
	            var songG = CreateSongGenre($"song {i}", rand.Next(4));
	            
	            songsGenre.Add(songG);
            }
            player.Add(songsGenre);
			
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
                            player.Play(true);
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
					case "shuf":
                        {
                            player.Shuffle(songs);
                        }
                        break;
					case "sort":
                        {
                            player.SortByTitle(songs);
                        }
                        break;
                    case "GS":
                    {
	                    player.FilterByGenre(songsGenre, Song.Genres.Pop);
                    }
	                    break;
					case "CHS":
                    {
	                    player.ChangeSkin();
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
		static Song CreateSong()
        {
            Random rand = new Random();
            Song song = new Song();
			song.Artist=new Artist();
			song.Title="song number"+rand.Next(20);
			song.Duration = rand.Next(3000);
            return song;
        }
		static Song CreateSong(string name, bool like)
        {
            Random rand = new Random();
            var song = new Song();
			song.Artist=new Artist();
			song.Title=name;
			song.like=like;
			song.Duration = rand.Next(3000);
            return song;
        }
		static Song CreateSongGenre(string name, int num)
		{
			Random rand = new Random();
			var song = new Song();
			song.Artist=new Artist();
			song.Title=name;
			Song.Genres[] gentxt={Song.Genres.None,Song.Genres.Pop,Song.Genres.Rock,Song.Genres.Rap ,Song.Genres.Metall};
			Song.Genres gen;
			gen =gentxt[num];
			song.Genre=gen;
			
			
			
			song.Duration = rand.Next(3000);
			return song;
		}
		static Artist AddArtist(string Name="Unknown Artist")
		{
			var artist=new Artist();
			artist.Name=Name;
			return artist;
		}
		static Album AddAlbum(string Name="Unknown Album", int Year=0)
		{
			var album=new Album();
			album.Name=Name;
			album.Year=Year;
			return album;
		}

		











    }
}
