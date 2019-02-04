using System;

namespace guessingGame
{
    class Program
    {
        private static readonly Random getrandom = new Random();
        static void Main(string[] args)
        {
            int computer = getrandom.Next(1, 10);
            Console.WriteLine(computer);
            bool win = false;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Guess a number between 1 and 10. You have 4 chances");
                int playerGuess = Convert.ToInt32(Console.ReadLine());
                if (playerGuess == computer)
                {
                    Console.WriteLine("congratulations you guessed correct! The number was {0}", playerGuess);
                    win = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Guess Again!");
                }
            }
            if (win)
            {

            }
            else
            {
                Console.WriteLine("good attempt, but you dident guess the number");
            }
        }
    }
}
