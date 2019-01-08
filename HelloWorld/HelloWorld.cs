using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Whats your name?");
            string yourName = Console.ReadLine();
            Console.Write("Hello {0}", yourName);

        }
    }
}
