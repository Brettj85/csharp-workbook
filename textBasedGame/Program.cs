using System;

namespace textBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runGame = true;
            bool alive = true;
            bool continueGame = true;
            while(continueGame)
            {
                while (alive)
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
                        //Go toward the EYE!!
                        Console.WriteLine("You approach the object...");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                        clearBoard();
                        //fight spider or not
                        requestResponse(3);
                        string fightSpider = Console.ReadLine();
                        
                        if (choice(fightSpider))
                        {

                        }
                        else
                        {
                            //dont fight
                            clearBoard();
                            Console.WriteLine("You choose not to fight the spider.");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                            clearBoard();
                            Console.WriteLine("Press enter to continue.");
                            alive = false;
                            runGame = false;
                        }
                        
                    }
                    else
                    {
                        //AHHHH run from the Glowing thing
                        clearBoard();
                        Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("But something won't let you....");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("you slowly drift off....");
                        clearBoard();
                        Console.WriteLine("Press enter to continue.");
                        alive = false;
                        runGame = false;
                    }
                    


                    Console.ReadLine();
                }

                if(alive)
                {
                    Console.Write("You managed to escape the cavern alive! Would you like to play again? y/n ");
                }
                else
                {
                Console.Write("You have died! Would you like to play again? y/n ");
                }

                bool continuePlaying = choice(Console.ReadLine());
                
                if (continuePlaying)
                {
                    runGame = true;
                    alive = true;
                }
                else
                {
                    Console.WriteLine("Thanks for playing");
                    continueGame = false;

                }
            }
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
                    string questionThree = ("The eye belongs to a giant spider!*Do you try to fight it?");
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
