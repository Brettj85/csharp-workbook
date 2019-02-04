using System;

namespace practace1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 1;
            int number2 = 1;
            Console.WriteLine("Enter two numbers.");
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter next number.");
            number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your added numbers are {0}", number1+number2);
        }
    }
}
