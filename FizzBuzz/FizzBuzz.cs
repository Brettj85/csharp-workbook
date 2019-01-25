using System;
using System.Linq;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.Write("FIZZ");
                }
                if (i % 5 == 0)
                {
                    Console.Write("BUZZ");
                }
                if (i % 3 != 0 && i % 5 != 0)
                {
                    Console.Write(i);
                }
                Console.Write("\n\r");
            }
            // Enumerable.Range(1, 100).Select(n => new Dictionary<int, string>
            //     { {15, "FizzBuzz"}, {3, "Fizz"}, {5, "Buzz"}, {1, n.ToString()} }.First(kv => n % kv.Key == 0).Value).ToList().ForEach(Console.WriteLine);
        }
    }
}
