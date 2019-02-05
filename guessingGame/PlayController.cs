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
                Console.Clear();
                // build menu
                Console.WriteLine("***********************************************");
                Console.WriteLine("*      Play Guessing Game : press g           *");
                Console.WriteLine("*              Cheat: press c                 *");
                Console.WriteLine("*              Exit: press x                  *");
                Console.WriteLine("*          Current Stats: press s             *");
                Console.WriteLine("***********************************************");
                string choice = "void";
                while (choice == "void")
                {
                    try
                    {
                        choice = Console.ReadLine();

                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid Selection. Please try again.");
                    }
                }

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
                    Console.WriteLine("Enter Cheat Code");
                    try
                    {
                        cheats.AddCheat(Console.ReadLine());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Invalid Entry!");
                    }
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

    //Cheat controller
    class CheatController
    {
        private bool not_random = false;
        public bool inf_lives { get; private set; } = false;
        private bool added_cheat = false;
        public void AddCheat(string password)
        {
            if (password == "ch0053#" && !not_random)
            {
                this.not_random = true;
                this.added_cheat = true;
            }
            if (password == "und131ng" && !inf_lives)
            {
                this.inf_lives = true;
                this.added_cheat = true;
            }
            if (!this.added_cheat)
            {
                Console.WriteLine("Invalid Cheat Code or that cheat is already enabled!");
            }
        }
        public bool[] RetriveCheats()
        {
            bool[] cheats = new bool[] { this.not_random, this.inf_lives };
            return cheats;
        }

    }
    //number guess game
}
