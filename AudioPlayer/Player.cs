using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace AudioPlayer
{
    class Player
    {
        
        public bool IsLock;
		private bool _playing;
        public Song[] Songs; //связь один со многими
		public Song songone;
		
		public Skin plskin; //почему-то не видит мой класс skin( не знаю что ему подключить...
		public bool Playing // {get; set;}
		{
			get
			{
				return _playing;	
			}
			private set 
			{
				_playing = value;
			}
		}

        private const int _maxvolume=100;
        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }
            private set //считывается только в рамках класса
            {
                if (value > _maxvolume)
                {
                    _volume = _maxvolume;
                }
                else if (value<0)
                {
                    _volume = 0;
                }
                else
                {
                    _volume = value;
                }

            }
        }
        
        List<Song> songs = new List<Song>();
        public void Play(bool loop =false)
        {
            int repeat;
            repeat = loop == false ? 1 : 5;
            for (int i = 0; i < repeat; i++)
            {
	            
	            if (songs[i].like == true)
	            {
		            Console.ForegroundColor = ConsoleColor.Green;
	            }
				else if (songs[i].like == false)
	            {
		            Console.ForegroundColor = ConsoleColor.Red;
	            }
	            Console.WriteLine(songs[i].Title+" Genre-"+songs[i].Genre);
                System.Threading.Thread.Sleep(2000);
            }
        }

       
        public void VolumeUp()
        {
            Volume += 5;
            Console.WriteLine($"volume={Volume}");
        }

        public void VolumeDown()
        {
            Volume -= 5;
            Console.WriteLine($"volume={Volume}");
        }
        public void VolumeChange(int step)
        {
            Volume += step;
            Console.WriteLine($"volume={Volume}");
        }
		public void Lock()
        {
            IsLock=true;
            Console.WriteLine($"Player is lock");
        }
		public void Unlock()
        {
            IsLock=false;
            Console.WriteLine($"Player is unlock");
        }
		public bool Stop()
        {
            if (IsLock==false)
			{
				Playing=false;
				Console.WriteLine($"Player is stop");
			}
			return Playing;
        }
		public bool Start()
        {
            if (IsLock==false)
			{
				Playing=true;
				Console.WriteLine($"Player is start");
			}
			return Playing;
        }
		public void Add(List<Song> songs)
        {
            this.songs = songs;
        }

        public void Shuffle(List<Song> songs)
        {
            List<Song> songsNew =new List<Song>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j < songs.Count; j+=3)
                {
                    songsNew.Add(songs[j]);
                }
            }
            this.songs = songsNew;
        }

        public void SortByTitle (List<Song> songs)
        {
            var songsTitle = new List<string>();
            foreach (Song sng in songs)
            {
                string title = sng.Title;
                songsTitle.Add(title);
            }
            songsTitle.Sort();
            var sortedSongs = new List<Song>();
            for (int i = 0; i < songsTitle.Count; i++)
            {
                foreach(Song sng in songs)
                {
                    if (songsTitle[i]==sng.Title)
                    {
                        sortedSongs.Add(sng);
                    }
                }
            }
            this.songs = sortedSongs;
        }

        public void WriteLyrics(Song song)
        {
            song.Title = song.Title.Length > 13 ? song.Title.Remove(13)+" ..." : song.Title;
            Console.WriteLine(song.Title);
            if (song.Lyrics!= null)
            {
                string[] massStringLyrics = song.Lyrics.Split(';');
                for (int i = 0; i < massStringLyrics.Length; i++)
                {
                    Console.WriteLine(massStringLyrics[i]);
                }
            }

        }
        public void FilterByGenre(List<Song> songs, Song.Genres fiterGenre)
        {
	        var newsongs = new List<Song>();
	        for (int i = 0; i < songs.Count; i++)
	        {
		        //Song.Genres genreSong = songs[i].Genre;
		        if (fiterGenre == songs[i].Genre)
		        {
			        newsongs.Add(songs[i]);
		        }
	        }
	        this.songs = newsongs;
        }


	}
}
