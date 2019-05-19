using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using static System.Console;
using System.Xml.Serialization;
using System.IO;

//using File=File.TagLib;


namespace AudioPlayer
{
    class Player : IDisposable
    {
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
        public static List<Song> Songs { get; set; } = new List<Song>();
        private static Skin Skin { get; set; }
        public static bool Loop { get; set; }
        public bool IsLock { get; set; }
         private SoundPlayer soundPlayer;
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Skin = null;
                    Clear(); 
                    
                }
                soundPlayer?.Dispose();
                disposed = true;
            }
        }
		~Player()
        {
            Dispose(false);
        }
		private bool _playing;
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
        public void Play(List<Song> songs, bool loop)
        {
            foreach (Song song in songs)
            {
                if (loop == true)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        song.Play = true;
                        Player.WriteSongsList(songs);
                    }
                }
                else
                {
                    song.Play = true;
                    Player.WriteSongsList(songs);
                    song.Play = false;
                    Console.ReadLine();
                }
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
		public static void WriteSongData(Song song, ConsoleColor color)
        {
            
            var (title, minutes, seconds, artistName, album, year) = song;
            Skin.Render($"Title - {title}");
            Skin.Render($"Duration - {minutes}.{seconds}");
            Skin.Render($"Artist - {artistName}");
            Skin.Render($"Album - {album}");
            Skin.Render($"Year - {year}");
            Console.WriteLine();
        }
		public static void WriteSongsList(List<Song> songs)
        {
			foreach (Song song in songs)
            {
				if (song.Play == true)
                {     
					WriteSongData(song, ConsoleColor.DarkRed);
                }
				else
                {
					if (song.Liked.HasValue == true)
                    {
                        if (song.Liked == true)
                        {
                            WriteSongData(song, ConsoleColor.Red);
                        }
                        else
                        {
                            WriteSongData(song, ConsoleColor.Green);
                        }
                    }
                    else WriteSongData(song, ConsoleColor.White);
                }
			}
		}
		
		public Skin plskin; 
		public Player(Skin plskin)
        {
            this.plskin = plskin;
            this.plskin.Clear();
		}
		public void ParametrSong(params Song[] songs)
        {
            foreach (Song item in songs)
            {
                plskin.Render(item.Title);
            }
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

		        //if (fiterGenre == songs[i].Genre)
		        {
			        newsongs.Add(songs[i]);
		        }
	        }
	        this.songs = newsongs;
        }
		public void ChangeSkin()
        {
            
            Console.WriteLine("Choose skin. 1-classic, 2-green, 3-random");
            switch (Console.ReadLine())
            {
                case "1":
                default:
                    plskin = new ClassicSkin();
                    break;
                case "2":
                    plskin = new ColorSkin();
                    break;
                case "3":
                    plskin = new RandomColorSkin();
                    break;
            }
            
        }
		public void Clear()
        {
            songs.Clear();
        }
		public List<Song> Load()
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            List<Song> songs = new List<Song>();
            string path = "d:\\Музыка\\TOPIC9";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (var file in directoryInfo.GetFiles("*.wav"))
            {
                fileInfos.Add(file);
				
            }
			foreach (var song in Directory.GetFiles(path))
            {
                //songs.Add(new Song("son",2,20,"art","alb",1998) { Path = path });
				songs.Add(new Song() { Title = path});
            
            }
			return songs;
            Console.WriteLine($"{songs}");
            //foreach (var file in fileInfos)
            //{

              //  var audio = File.Create(file.FullName);
				//Console.WriteLine($"{audio}");
                //songs.Add(new Song(){Album=new Album(audio.Name,(int)audio.Length)});
				//songs.Add(new Song() { Album = new Album(audio?.Tag.Album, (int)audio.Tag?.Year), Artist = new Artist(audio.Tag?.FirstPerformer), Duration = (int)audio.Properties.Duration.TotalSeconds, Genre = audio.Tag?.FirstGenre, Lyrics = audio.Tag?.Lyrics, Title = audio.Tag?.Title, Path = audio.Name });
            //}

        }
		public void Play(List<Song> songs)
		{

			foreach (var file in songs)
            {
                
                
                soundPlayer = new SoundPlayer(file.Title+".wav");
                soundPlayer.PlaySync();
            }



		}
		public void SaveAsPlaylist(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Song>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, songs);
            }
        }

        public void LoadPlaylist(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Song>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                songs = (List<Song>)xs.Deserialize(fs);
            }
        }
	}
}
