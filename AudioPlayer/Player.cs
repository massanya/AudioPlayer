using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class Player
    {
        public int volume;
        public bool isLock;
        public Song[] Songs; //cdzpm jlby rj vyjubv

        public void Play()
        {
            for (int i = 0; i < Songs.Length; i++)
            {
                Console.WriteLine(Songs[i].title);
                System.Threading.Thread.Sleep(2000);
            }
           
        }

        public void VolumeUp()
        {
            volume += 5;
            Console.WriteLine($"volume={volume}");
        }

        public void VolumeDown()
        {
            volume -= 5;
            Console.WriteLine($"volume={volume}");
        }
    }
}
