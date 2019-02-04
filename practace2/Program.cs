using System;

namespace practace2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfYards = 0;
            Console.WriteLine("How many yards do you need converted?");
            numberOfYards = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("There are {1} inches in {0} yards", numberOfYards, numberOfYards*36);

        }
    }
}
