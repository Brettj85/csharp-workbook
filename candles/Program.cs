using System;

namespace candles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberOfCandles = { 1, 3, 2, 6, 7, 9, 9, 8, 7, 3, 9, };
            int largest = 0;
            int howManyCandles = 1;
            foreach (var num in numberOfCandles)
            {
                if (num > largest)
                {
                    largest = num;
                    howManyCandles = 1;
                }
                else if (num == largest)
                {
                    howManyCandles++;
                }
            }
            Console.WriteLine("they can blow out {0} candles", howManyCandles);
        }
    }
}
