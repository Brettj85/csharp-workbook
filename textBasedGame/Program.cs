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
                while (runGame)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("Welcome to the cavern of secrets");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                    System.Threading.Thread.Sleep(3000);
                    
                    clearBoard();
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
                        clearBoard();
                        Console.WriteLine("You approach the object...");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                        clearBoard();
                        //fight spider or not
                        requestResponse(3);
                        string fightSpider = Console.ReadLine();
                        
                        if (choice(fightSpider))
                        {
                            // Fight Spider
                            bool aliveAfterFight = fightTheSpider(hasStick);
                            if (aliveAfterFight)
                            {
                                clearBoard();
                                runGame = false;
                            } 
                            else
                            {
                                clearBoard();
                                alive = false;
                                runGame = false;
                            }

                        }
                        else
                        {
                            //dont fight
                            clearBoard();
                            Console.WriteLine("You choose not to fight the spider.");
                            System.Threading.Thread.Sleep(2000);
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
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("But something won't let you....");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("you slowly drift off....");
                        clearBoard();
                        Console.WriteLine("Press enter to continue.");
                        alive = false;
                        runGame = false;
                    }
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
                Console.Clear();
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
            System.Threading.Thread.Sleep(2000);
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
        }
        //return the question to be asked
        public static string returnQuestion(int questionNumber)
        {
            switch (questionNumber)
            {
                case 1:
                    string question = ("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.*Do you take it?");
                    return question;
                case 2:
                    string questionTwo = ("As you proceed further into the cave, you see a small glowing object*Do you approach the object?");
                    return questionTwo;
                case 3:
                    string questionThree = ("The eye belongs to a giant spider!*Do you try to fight it?");
                    return questionThree;
                default:
                    string gameOver = ("Game Over");
                    return gameOver;
            }
        }
        public static bool fightTheSpider(bool weapon)
        {
            if(weapon)
            {
                Console.WriteLine("You only have a stick to fight with!");
                Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                clearBoard();
                battleText();
                int result = Autobattle(weapon);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("You don't have anything to fight with!");
                clearBoard();
                battleText();
                int result = Autobattle(weapon);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
         
        }
        private static readonly Random getrandom = new Random();
        public static int Autobattle(bool hasWeapon)
        {
            int attack = getrandom.Next(1, 8);
            int defend = getrandom.Next(1, 5);
            Console.WriteLine("You attacked for {0} damage", attack);
            Console.WriteLine("The spider attacked for {0} damage", defend);
            if (hasWeapon)
            {
                attack = (attack + 2);
            }
            int returnValue = 0;
            if (attack < defend)
            {
                Console.WriteLine("The spider has dealt more damage than you!");
                return returnValue;
            }
            else if (attack < 5)
            {
                Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                returnValue = 1;
                return returnValue;
            }
            else
            {
                Console.WriteLine("You killed the spider!");
                returnValue = 2;
                return returnValue;
            }
        }
        public static void battleText()
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("                  Fighting...                   ");
                Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("");
            }
    }
}
