using System;

namespace candles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberOfCandles = { 1, 2, 4, 8, 8, 6 };
            int tallest = 1;
            int howManyCandles = numberOfCandles.Length;
            int j = 1;
            foreach (var num in numberOfCandles)
            {
                if (num > tallest)
                {
                    tallest = num;
                    j = 1;
                }
                else if (num == tallest)
                {
                    j++;
                }
            }

            Console.WriteLine("she can blow out {0} candles!", j);
        }
    }
}
