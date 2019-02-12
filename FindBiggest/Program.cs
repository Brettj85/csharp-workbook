using System;

namespace FindBiggest
{
    class Program
    {
        static void Main(string[] args)
        {
            //continue to ask for numbers and return the highest
            int highest_number = 0;
            string current_number;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("enter a number or e for exit");
                try
                {
                    current_number = Console.ReadLine();
                    int number = Convert.ToInt32(current_number);
                    if (number > highest_number)
                    {
                        highest_number = number;
                    }
                }
                catch (System.Exception)
                {

                    exit = true;

                }
            }

            Console.WriteLine("Your Highest Number is {0}", highest_number);
        }
    }
}
