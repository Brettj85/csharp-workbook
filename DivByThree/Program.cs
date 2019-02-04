using System;

namespace DivByThree
{
    class Program
    {
        static void Main(string[] args)
        {
            int how_many = 0;

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    how_many++;
                }
            }

            Console.WriteLine(how_many);
        }
    }
}
