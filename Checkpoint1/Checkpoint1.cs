using System;
using System.Collections.Generic;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            //continue to ask for numbers and add them together
            bool exit = false;
            List<int> playerNumbersList = new List<int> { };
            while (!exit)
            {
                Console.WriteLine("Enter number or ok to exit");
                string userResponse = Console.ReadLine();
                if (userResponse == "ok")
                {
                    exit = true;
                }
                else
                {
                    playerNumbersList.Add(Convert.ToInt32(userResponse));
                }
            }
            int result = 0;
            for (int i = 0; i < playerNumbersList.Count; i++)
            {
                result = result + playerNumbersList[i];
            }
            Console.WriteLine(result);
        }
    }
}
