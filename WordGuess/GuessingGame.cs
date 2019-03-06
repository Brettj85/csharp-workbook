using System;
using System.Collections.Generic;
using System.IO;

namespace WordGuess
{

    class GuessingGame
    {
        public enum Letters
        {
            a,
            b,
            c,
            d,
            e,
            f,
            g,
            h,
            i,
            j,
            k,
            l,
            m,
            n,
            o,
            p,
            q,
            r,
            s,
            t,
            u,
            v,
            w,
            x,
            y,
            z,
        }
        public string GuessThis = "";
        public Dictionary<string, int> possibleWords { get; set; } = new Dictionary<string, int>();
        public GuessingGame()
        {
            Random rnd = new Random();
            ReadToArray builtArray = new ReadToArray();
            int guessMe = rnd.Next(0, builtArray.lines.Length);
            GuessThis = builtArray.lines[guessMe];
            for (int i = 0; i < builtArray.lines.Length; i++)
            {
                possibleWords.Add(builtArray.lines[i], i);
            }
        }
        public void Run()
        {
            Dictionary<string, string> previousGuess = new Dictionary<string, string>();
            string guess = "";
            string check = "";
            int index = 0;
            while (guess != GuessThis)
            {
                string wordToGuess = GuessThis;
                Console.WriteLine("*" + GuessThis + "*");
                if (index > 0)
                {
                    Console.Clear();
                    Console.WriteLine("*" + GuessThis + "*");
                    foreach (var pair in previousGuess)
                    {
                        Console.WriteLine("{0} {1}", pair.Key, pair.Value);
                    }
                }
                index++;
                Console.WriteLine("Guess a Word");
                guess = Console.ReadLine();
                int toGuess = (int)System.Enum.Parse(typeof(Letters), wordToGuess.Substring(0, 1), true);
                int fromGuess = (int)System.Enum.Parse(typeof(Letters), guess.Substring(0, 1), true);
                if (fromGuess > toGuess)
                {
                    Console.Write("Higher ");
                    previousGuess.Add(guess, "Higher");
                }
                else if (fromGuess < toGuess)
                {
                    Console.Write("Lower ");
                    previousGuess.Add(guess, "Lower");
                }
                else
                {
                    CheckEquality checkguess = new CheckEquality();
                    check = checkguess.compareTwo(guess, wordToGuess);
                    previousGuess.Add(guess, check);
                    Console.Write(check);
                }
                Console.Write(guess);
            }
            Console.WriteLine();
            Console.WriteLine("you have Won the word was {0}", guess);


        }
    }
}