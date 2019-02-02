using System;

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumber guess_me = new RandomNumber();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What is your age?");
            int age = Convert.ToInt32(Console.ReadLine());
            PlayerStatistics player = new PlayerStatistics(name, age);
            Console.WriteLine("cheat code?");
            guess_me.Cheat(Console.ReadLine());
            PlayGame start = new PlayGame(player, guess_me);
            start.guess_loop(start.number, player);

            //take in 4 guesses and match against the number
            Console.WriteLine("{0}", guess_me.guess_this);
        }
    }
    class RandomNumber
    {
        private bool cheat = false;
        private Random rnd = new Random();
        private int guess_it;
        public RandomNumber()
        {
            guess_this = rnd.Next(1, 10);
            guess_it = guess_this;
        }
        public void Cheat(string selected_number)
        {
            try
            {
                this.guess_it = Convert.ToInt32(selected_number);
                this.cheat = true;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("incorrect CheatCode");
                Console.WriteLine("A random # has been generated");
                Console.ReadLine();
            }

        }
        public int RequestNumber()
        {
            return guess_it;
        }
        public int guess_this { get; private set; }
    }

    class PlayerStatistics
    {
        private int lives = 4;
        private bool cheat = false;

        public PlayerStatistics(string player_name, int player_age)
        {
            this.name = player_name;
            this.age = player_age;
        }

        public string name { get; private set; }
        public int age { get; private set; }

        public int CheckLives()
        {
            return this.lives;
        }

        public void Cheat(int selected_number)
        {
            try
            {
                this.lives = Convert.ToInt32(selected_number);
                cheat = true;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("incorrect CheatCode");
                Console.WriteLine("Good Try, press enter to exit.");
                Console.ReadLine();
            }

        }

    }

    class PlayGame
    {
        private bool cheat = false;
        private int lives;
        private bool winner;
        public PlayGame(PlayerStatistics player, RandomNumber guess_me)
        {
            PlayerStatistics player_data = player;
            number = guess_me.RequestNumber();
            lives = player.CheckLives();
            int num_to_guess = number;
        }

        public void guess_loop(int num_to_guess, PlayerStatistics player_data)
        {
            bool number_guessed = false;
            //bool winner = false;
            int guess_this = number;
            while (lives < 0 && !number_guessed)
            {
                Console.WriteLine("Guess the number");
                int player_guess = Convert.ToInt32(Console.ReadLine());
                try
                {
                    if (player_guess == guess_this)
                    {
                        Console.WriteLine("you have Won");
                        number_guessed = true;
                        winner = true;
                    }
                    else if (lives > 0)
                    {
                        Console.WriteLine("Try Again! you have {0} lives left", lives);
                    }
                    else
                    {
                        Console.WriteLine("You have {0} lives left, Game Over", lives);
                        Console.WriteLine("Cheat?");
                        player_data.Cheat(Convert.ToInt32(Console.ReadLine()));
                    }
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Good Game");
                    Console.ReadLine();
                }
            }
        }

        public object player_data { get; private set; }
        public int number { get; private set; }
        /*Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. 
                If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program 
                is behaving correctly, you can display the secret number on the console first.) */
    }
}
