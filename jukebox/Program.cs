using System;
using System.Threading;

namespace jukebox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which song would you like to hear! or exit to exit");
            Console.WriteLine("1: Fur Elise");
            Console.WriteLine("2: Mission Impossible Theme");
            Console.WriteLine("3: Tetris - song: b");
            Console.WriteLine("more to come....");
            try
            {
                int select = Convert.ToInt32(Console.ReadLine()); ;
                Play start = new Play(select);
            }
            catch (System.Exception)
            {

                Console.WriteLine("Invalid selection");
            }
        }
        class Play
        {
            public Play(int song_selection)
            {
                Library song = new Library(song_selection);
                int[] freq = song.frequency;
                int[] dur = song.duration;
                PlaySong(freq, dur);

            }
            public void PlaySong(int[] freq, int[] dur)
            {

                for (int i = 0; i < freq.Length; i++)
                {
                    if (freq[i] == 0)
                    {
                        Thread.Sleep(dur[i]);
                    }
                    else
                    {
                        Console.Beep(freq[i], dur[i]);
                    }
                }
            }
        }
        class Library
        {

            public Library(int song_selection)
            {
                switch (song_selection)
                {
                    case 1:
                        frequency = new int[] { 420, 400, 420, 400, 420, 315, 370, 335, 282, 180, 215, 282, 315, 213, 262, 315, 335, 213, 420, 400, 420, 400, 420, 315, 370, 335, 282, 180, 215, 282, 315, 213, 330, 315, 282 };
                        duration = new int[] { 200, 200, 200, 200, 200, 200, 200, 200, 600, 200, 200, 200, 600, 200, 200, 200, 600, 200, 200, 200, 200, 200, 200, 200, 200, 200, 600, 200, 200, 200, 600, 200, 200, 200, 600 };
                        break;
                    case 2:
                        frequency = new int[] { 0, 784, 0, 784, 0, 784, 0, 932, 0, 1047, 0, 784, 0, 784, 0, 699, 0, 740, 0, 784, 0, 784, 0, 932, 784, 587, 0, 932, 784, 554, 0, 932, 784, 523, 0, 466, 523 };
                        duration = new int[] { 300, 150, 300, 150, 150, 150, 150, 150, 300, 150, 300, 150, 150, 150, 150, 150, 300, 150, 300, 150, 150, 150, 150, 150, 150, 1200, 75, 150, 150, 1200, 75, 150, 150, 1200, 150, 150, 150 };
                        break;
                    case 3:
                        frequency = new int[] { 658, 1320, 990, 1056, 1188, 1320, 1188, 1056, 990, 880, 880, 1056, 1320, 1188, 1056, 990, 1056, 1188, 1320, 1056, 880, 880, 0, 1188, 1408, 1760, 1584, 1408, 1320, 1056, 1320, 1188, 1056, 990, 990, 1056, 1188, 1320, 1056, 880, 880, 0, 1320, 990, 1056, 1188, 1320, 1188, 1056, 990, 880, 880, 1056, 1320, 1188, 1056, 990, 1056, 1188, 1320, 1056, 880, 880, 0, 1188, 1408, 1760, 1584, 1408, 1320, 1056, 1320, 1188, 1056, 990, 990, 1056, 1188, 1320, 1056, 880, 880, 0, 660, 528, 594, 495, 528, 440, 419, 495, 660, 528, 594, 495, 528, 660, 880, 838, 660, 528, 594, 495, 528, 440, 419, 495, 660, 528, 594, 495, 528, 660, 880, 838 };
                        duration = new int[] { 125, 500, 250, 250, 250, 125, 125, 250, 250, 500, 250, 250, 500, 250, 250, 750, 250, 500, 500, 500, 500, 500, 250, 500, 250, 500, 250, 250, 750, 250, 500, 250, 250, 500, 250, 250, 500, 500, 500, 500, 500, 500, 500, 250, 250, 250, 125, 125, 250, 250, 500, 250, 250, 500, 250, 250, 750, 250, 500, 500, 500, 500, 500, 250, 500, 250, 500, 250, 250, 750, 250, 500, 250, 250, 500, 250, 250, 500, 500, 500, 500, 500, 500, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 500, 500, 1000, 2000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 500, 500, 1000, 2000 };
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            public int[] frequency { get; private set; }
            public int[] duration { get; private set; }
        }
    }
}
