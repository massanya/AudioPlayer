using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Player
    {
        
        public bool IsLock;
		private bool _playing;
        public Song[] Songs; //связь один со многими
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
        public void Play()
        {
            for (int i = 0; i < Songs.Length; i++)
            {
                Console.WriteLine(Songs[i].Title+" "+Songs[i].Artist.Name+" "+Songs[i].Duration);
                System.Threading.Thread.Sleep(Songs[i].Duration);
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
    }
}
