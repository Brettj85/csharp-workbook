using System;

namespace candles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberOfCandles = { 1, 2, 4, 8, 8, 6 };
            int tallest = 1;
            int howManyCandles = 1;
            foreach (var num in numberOfCandles)
            {
                if (num > tallest)
                {
                    tallest = num;
                    howManyCandles = 1;
                }
                else if (num == tallest)
                {
                    howManyCandles++;
                }
            }

            Console.WriteLine("she can blow out {0} candles!", j);
        }
    }
}
