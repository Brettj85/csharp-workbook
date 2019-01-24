using System;

namespace checkpoint1Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number for factorial");
            int userNumber = Convert.ToInt32(Console.ReadLine());
            for (int i = userNumber - 1; i > 0; i--)
            {
                userNumber = userNumber * i;
            }
            Console.WriteLine("the factorial is {0}", userNumber);

        }
    }
}
