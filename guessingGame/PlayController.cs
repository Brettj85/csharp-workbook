using System;
using System.Collections.Generic;

namespace guessingGame
{

    class ProgramController
    {
        private bool quit = false;
        PlayerStatistics data_file;
        CheatController cheats;


        public ProgramController(PlayerStatistics user_data)
        {
            this.data_file = user_data;
            this.cheats = new CheatController();
        }
        public void Start()
        {

            //run software until quit
            while (!quit)
            {
                string choice;
                do
                {
                    Console.Clear();

                    Console.WriteLine("***********************************************");
                    Console.WriteLine("*      Play Guessing Game : press g           *");
                    Console.WriteLine("*              Cheat: press c                 *");
                    Console.WriteLine("*              Exit: press x                  *");
                    Console.WriteLine("*          Current Stats: press s             *");
                    Console.WriteLine("***********************************************");
                    choice = Console.ReadLine();
                } while (choice != "g" && choice != "c" && choice != "x" && choice != "s");

                if (choice == "g")
                {
                    int[] results;
                    PlayGuessingGame play = new PlayGuessingGame(data_file, cheats);
                    results = play.PlayGame();
                    int i = 0;
                    foreach (var item in results)
                    {
                        data_file.guessing_game[i] = data_file.guessing_game[i] + item;
                        i++;
                    }
                }
                else if (choice == "c")
                {
                    Console.Clear();
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("*                   Cheats                    *");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Enter Cheat Code");
                    cheats.AddCheat(Console.ReadLine());
                }
                else if (choice == "s")
                {
                    data_file.GenerateStatistics();
                }
                else if (choice == "x")
                {
                    this.quit = true;
                }
            }
        }
    }
}
