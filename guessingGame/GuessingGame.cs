using System;
using System.Threading;

namespace guessingGame
{
    class RandomNumber
    {
        private int guess_me;
        private bool pick_num_cheat = false;
        private Random random = new Random();
        public RandomNumber(CheatController cheats)
        {
            bool[] is_cheating = cheats.RetriveCheats();
            if (is_cheating[0])
            {
                pick_num_cheat = true;
            }
        }
        public int GetNumber()
        {
            if (pick_num_cheat)
            {
                Console.WriteLine("pick a number");
                guess_me = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                guess_me = random.Next(1, 10);
            }
            return guess_me;
        }
    }
    class PlayGuessingGame
    {
        private int lives;
        private bool pick_num_cheat = false;
        private int guess_this;
        private PlayerStatistics player_data;
        private CheatController active_cheats;

        public PlayGuessingGame(PlayerStatistics user_data, CheatController cheats)
        {
            this.player_data = user_data;
            this.active_cheats = cheats;
            this.lives = user_data.lives;
            RandomNumber get_number = new RandomNumber(this.active_cheats);
            guess_this = get_number.GetNumber();

            bool[] is_cheating = active_cheats.RetriveCheats();
            if (is_cheating[0])
            {
                this.pick_num_cheat = true;
            }
            if (is_cheating[1])
            {
                this.lives = -1;
                this.player_data.CheckCheating(is_cheating[1]);
            }
        }
        public bool CheckWin(int user_guess)
        {
            if (user_guess == guess_this)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int[] PlayGame()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("*                Guessing Game                *");
            Console.WriteLine("***********************************************");
            int user_guess = 0;
            bool win = false;
            bool loss = false;
            int[] results = new int[4] { 0, 0, 0, 0 };
            if (lives < 0 || pick_num_cheat)
            {
                results[3]++;
            }

            while ((lives > 0 || lives < 0) && !win)
            {
                Console.WriteLine("enter guess");
                try
                {
                    user_guess = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Invalid Guess!");
                }
                bool guess_correct = CheckWin(user_guess);
                bool[] is_cheating = active_cheats.RetriveCheats();
                // better way to do this is get/private set for 
                // expandability or use public var to get the private values. 
                // More than a couple of these in the array would get confusing.
                if (guess_correct)
                {
                    win = true;
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Clear();

                        if (is_cheating[0] || is_cheating[1])
                        {
                            Thread.Sleep(250);
                            Console.WriteLine("You have WON!!!   ;)");
                            Thread.Sleep(250);
                        }
                        else
                        {
                            Thread.Sleep(250);
                            Console.WriteLine("You have WON!!!");
                            Thread.Sleep(250);
                        }
                    }
                }
                else
                {
                    lives--;
                }
            }
            if (lives == 0)
            {
                loss = true;
            }

            if (loss)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Clear();
                    Thread.Sleep(250);
                    Console.WriteLine("You have LOST!!!");
                    Thread.Sleep(250);
                }
            }
            results[0]++;
            if (loss)
            {
                results[2]++;
            }
            else
            {
                results[1]++;
            }
            return results;
        }
    }
}
