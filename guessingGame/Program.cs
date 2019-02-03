using System;
using System.Collections.Generic;

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //run game controller           
        }
    }

    // keep track of player data games played cheating lives in each game
    class PlayerStatistics
    {
        private string player_first;
        private string player_last;
        private int[] guessing_game = new int[] { 0, 0, 0, 0 };
        private int lives = 4;

        public PlayerStatistics(string first, string last)
        {

            player_first = first;
            player_last = last;
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
            for (int i = 0; i == game_list.Count; i++)
            {
                Console.WriteLine(top_bot);
                Console.WriteLine("*                                             *");//45
                Console.WriteLine(game_list[i]);
                Console.WriteLine("*Played: {0}                                *", "00" + guessing_game[i]);//make sure all numbers come out to XXX ie 001, 002, 201, 999 max
                Console.WriteLine("*Won: {0}                        Lost: {1}*", "00" + guessing_game[i + 1], "00" + guessing_game[i + 2]);
                Console.WriteLine("*Cheated: {0}                               *", "00" + guessing_game[i + 3]);
            }
            Console.WriteLine(top_bot);
        }
    }
}
