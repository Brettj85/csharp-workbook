using System;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = new int[] { 1, 2, 3 };

            var results =
            from i in source
            where isEven(i)
            select Square(i);

            int total = source.Where(isEven).Select(Square).Sum();
            // var total = results.Sum();
        }

        public static bool isEven(int i)
        {
            return i % 2 == 0;
        }

        public static int Square(int value)
        {
            return value * value;
        }
    }
}
