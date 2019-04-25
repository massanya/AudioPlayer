using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Player
    {

		[Flags]
		public enum Genres
		{
			None = 0,       //0000
			Pop = 1,        //0001
			Rock = 2,       //0010
			Rap = 4,      //0100
			Metall = 8 //1000
		}
	}
}
