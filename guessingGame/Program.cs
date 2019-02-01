using System;

namespace guessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumber guess_me = new RandomNumber();
            guess_me.Cheat(3);
            //take in 4 guesses and match against the number
            Console.WriteLine("{0}", guess_me.guess_this);
        }
    }
    class RandomNumber
    {
        private Random rnd = new Random();

        public RandomNumber()
        {
            guess_this = rnd.Next(1, 10);
        }
        public void Cheat(int selected_number)
        {
            this.guess_this = selected_number;
        }
        public int guess_this { get; private set; }
    }

    class PlayGame
    {


    }

    /*Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. 
            If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program 
            is behaving correctly, you can display the secret number on the console first.) */
}
