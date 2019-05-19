using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    [Serializable]
    public class Song
    {
	    
	    
        public enum Genres
	    {
		    None = 0,       //0000
		    Pop,        //0001
		    Rock,       //0010
		    Rap ,		//0100
		    Metall	//1000
	    }
	    public int Duration { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public string Lyrics { get; set; }
        public string Genre;
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        
		
        public bool? Liked=null;
        private bool _play;
        public bool Play
        {
            get
            {
                return _play;
            }
            set
            {
                _play = value;
            }
        }
        

        private Playlist[] Playlist;

        
        public void Like(Song song)
        {
            song.Liked=true;
        }

       
        public static void Dislike(Song song)
        {
           song.Liked = false;
        }

        public void Deconstruct(out string title, out int min, out int sec, out string nameOfArtist,out string album, out int year)
        {
            title = Title;
            min = Duration / 60;
            sec = Duration % 60;
            nameOfArtist = Artist.Name;
            album = "alb";
            year =10;
        }
		
    }
}
