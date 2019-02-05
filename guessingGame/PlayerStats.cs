using System;
using System.Collections.Generic;

namespace guessingGame
{
    class PlayerStatistics
    {
        private string player_first;
        private string player_last;
        public int[] guessing_game { get; set; }
        public int lives { get; set; }
        private bool lives_cheat { get; set; }

        public void CheckCheating(bool is_cheating)
        {
            if (is_cheating)
            {
                this.lives_cheat = true;
            }
            else
            {

            }
        }
        public PlayerStatistics(string first, string last)
        {
            this.player_first = first;
            this.player_last = last;
            this.guessing_game = new int[] { 0, 0, 0, 0 };
            this.lives = 4;
        }

        //statistics generator
        public void GenerateStatistics()
        {
            List<string> game_list = new List<string>() { "*                Guessing Game                *" };
            //List<int[]> stats_list = new List<int[]>(){};
            // for times sake will have to adapt this to add games to a list and loop through
            //if i have time i will make it generate spacing based off word length
            Console.Clear();
            string top_bot = "***********************************************";
            Console.WriteLine("* Name: {1}, {0} *", player_first, player_last);
            Console.WriteLine(top_bot);
            Console.WriteLine("*                                             *");//45
            Console.WriteLine(game_list[0]);
            Console.WriteLine("* Played: {0}                                 *", "00" + guessing_game[0]);
            Console.WriteLine("* Won: {0}                          Lost: {1} *", "00" + guessing_game[1], "00" + guessing_game[2]);
            Console.WriteLine("* Cheated: {0}                                *", "00" + guessing_game[3]);
            Console.WriteLine(top_bot);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}