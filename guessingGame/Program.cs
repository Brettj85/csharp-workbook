using System;
using System.Collections.Generic;

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //run profile creation
            string first = "";
            string last = "";
            while (first == "" || last == "")
            {
                if (first == "")
                {
                    Console.Clear();
                    Console.Write("Enter first name: ");
                    first = Console.ReadLine();
                }
                else if (last == "")
                {
                    Console.Clear();
                    Console.Write("Enter last name: ");
                    last = Console.ReadLine();
                }

            }
            PlayerStatistics new_player = new PlayerStatistics(first, last);
            ProgramController start_playing = new ProgramController(new_player);

            start_playing.Start();
            Console.WriteLine("Thanks for playing. Press enter to exit.");
            Console.ReadLine();
        }
    }
}
