using System;

namespace textBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Welcome to the cavern of secrets");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            System.Threading.Thread.Sleep(3000);
            
            for (int i = 0; i <= 3; i++)
            {
            Console.Beep();
            }

            Console.Clear();

            Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
            Console.WriteLine();
            Console.Write("Do you take it y/n ");
            string stickAnswer = Console.ReadLine();
            
            Console.Clear();
            System.Threading.Thread.Sleep(2000);
            Console.Beep();

            int stick = 0;
            if (stickAnswer == "y" || stickAnswer == "Y" || stickAnswer == "yes" || stickAnswer == "Yes"){
                stick = 1;
                Console.WriteLine("You have taken the stick!");
            }
            else
            {
                stick = 0;
                Console.WriteLine("You did not take the stick");
            }

            Console.Clear();
            System.Threading.Thread.Sleep(2000);
            Console.Beep();

            Console.WriteLine("As you proceed further into the cave, you see a small glowing object");
            Console.WriteLine();
            Console.Write("Do you approach the object? y/n ");
            string approachAnswer = Console.ReadLine();
            
            Console.Clear();
            System.Threading.Thread.Sleep(2000);
            Console.Beep();

            if (approachAnswer == "y" || approachAnswer == "Y" || approachAnswer == "yes" || approachAnswer == "Yes"){
                Console.WriteLine("You approach the object...");
                System.Threading.Thread.Sleep(2000);
                Console.Beep();
                Console.Clear();
                Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                System.Threading.Thread.Sleep(2000);
                Console.Beep();
                Console.Clear();
                Console.WriteLine("The eye belongs to a giant spider!");
                Console.WriteLine();
                Console.Write("Do you try to fight it? y/n ");    
            }




            Console.ReadLine();
        }

    }
}
