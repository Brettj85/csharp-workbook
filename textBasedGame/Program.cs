﻿using System;

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
            int index = 1;
            bool hasStick = false;
            
            //Take stick or not

            requestResponse(1);
            string stickAnswer = Console.ReadLine();
            
            if (choice(stickAnswer))
            {
                Console.WriteLine("You have taken the stick!");
                hasStick = true;
            }
            else
            {
                Console.WriteLine("You did not take the stick");
            }
                clearBoard();
            //go toward eye or not
            requestResponse(2);
            string towardObject = Console.ReadLine();
            if (choice(towardObject))
            {
                Console.WriteLine("You have taken the stick!");
                hasStick = true;
            }
            else
            {
                Console.WriteLine("You did not take the stick");
            }
            //fight spider or not


            Console.ReadLine();
        }
        //convert users response to a bool
        public static bool choice(string userInput) 
        {   
            string simplifiedResponse = userInput.ToLower().Substring(0,1);
            if (simplifiedResponse == "y")
            {
                bool usersChoice = true;
                return usersChoice;
            }
            else
            {
                bool usersChoice = false;
                return usersChoice;
            }
        }
        public static void clearBoard()
        {   
            System.Threading.Thread.Sleep(1000);
            for (int i = 0; i <= 3; i++)
            {
                Console.Beep();
            }
            Console.Clear();
            
        }
        //ask questions based on what part of the story we are in
        public static void requestResponse(int questionNumber)
        {
            string storyQuestion = returnQuestion(questionNumber);
            string[] splitQuestions = storyQuestion.Split('*');
            string firstQuestion = splitQuestions[0];
            string secondQuestion = splitQuestions[1];
            Console.WriteLine(firstQuestion);
            Console.WriteLine();
            if (secondQuestion.Length > 0)
            {
            Console.Write("{0} y/n ", secondQuestion);
            }
            else
            {

            }

        }
        //return the question to be asked
        public static string returnQuestion(int questionNumber)
        {
            switch (questionNumber)
            {
                case 1:
                    string question = ("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.*Do you take it?");
                    return question;
                    break;
                case 2:
                    string questionTwo = ("As you proceed further into the cave, you see a small glowing object*Do you approach the object?");
                    return questionTwo;
                    break;
                case 3:
                    string questionThree = ("You approach the object...");
                    return questionThree;
                    break;
                default:
                    string gameOver = ("Game Over");
                    return gameOver;
                    break;
            }
        }
    }
}
