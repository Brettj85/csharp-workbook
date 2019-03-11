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
            where compLogic(i)
            select i * i;

            var total = results.Sum();
        }

        public static bool compLogic(int i)
        {
            return i % 2 == 0;
        }
    }
}
