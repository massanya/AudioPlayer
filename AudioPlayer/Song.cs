using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    
	class Song
    {
	    
	    public enum Genres
	    {
		    None = 0,       //0000
		    Pop,        //0001
		    Rock,       //0010
		    Rap ,		//0100
		    Metall	//1000
	    }
	    public int Duration;
        public string Title;
        public string Path;
        public string Lyrics;
        //public string Genre;
        public Artist Artist;
        public Album Album;
        public Genres Genre;
		public bool? like=null;
        public void Like()
        {
	        like = true;
        }

        public void Dislike()
        {
	        like = false;
        }

        
    }
}
