using System;
using System.Text;

namespace TicTacToe
{
    public class Menu
    {
        public static void mainMenu(string[][,] returnedResults, string how_many)
        {
            int howMany = Convert.ToInt32(how_many);
            Console.WriteLine("*************************************************");
            Console.WriteLine("*                   Main Menu                   *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*   Play Games: p               View Games: v   *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*************************************************");
            string request = Console.ReadLine();
            string[] results = new string[howMany];

            if (request == "p")
            {
                setupGame();
            }
            else if (request == "v")
            {
                if (!string.IsNullOrEmpty(results[0]))
                {
                    showResults(results);
                }
            }

        }
        public static void showResults(string[] returnedResults)
        {
            string[] resultsToPrint = returnedResults;

            for (int i = 1; i >= Convert.ToInt32(resultsToPrint[0]); i++)
            {
                string resultString = resultsToPrint[i];

            }

        }
        public static string[][,] setupGame()
        {
            bool playerOneAI = false;
            bool playerTwoAI = true;
            int levelOne = 1;
            int levelTwo = 1;

            Console.WriteLine("Is player 1 an AI y/n");
            string answer = Console.ReadLine();
            if (answer.Substring(0, 1).ToLower() == "y")
            {
                playerOneAI = true;
                Console.WriteLine("Which difficulty level");
                Console.WriteLine("Easy: 0 | Medium: 1 | Hard: 2");
                int difficultyRequest = Convert.ToInt32(Console.ReadLine());
                if (difficultyRequest == 0 || Convert.ToInt32(difficultyRequest) == 1 || Convert.ToInt32(difficultyRequest) == 2)
                {
                    levelOne = Convert.ToInt32(difficultyRequest);
                }

            }
            else
            {
                playerOneAI = false;
            }
            Console.WriteLine("Is player 2 an AI y/n");
            string answerTwo = Console.ReadLine();
            if (answer.Substring(0, 1).ToLower() == "y")
            {
                playerOneAI = true;
                Console.WriteLine("Which difficulty level");
                Console.WriteLine("Easy: 0 | Medium: 1 | Hard: 2");
                int difficultyRequest = Convert.ToInt32(Console.ReadLine());
                if (difficultyRequest == 0 || Convert.ToInt32(difficultyRequest) == 1 || Convert.ToInt32(difficultyRequest) == 2)
                {
                    levelTwo = Convert.ToInt32(difficultyRequest);
                }

            }
            else
            {
                playerOneAI = false;
            }
            Console.WriteLine("*************************************************");
            Console.WriteLine("*     how many games would you like to play?    *");
            Console.WriteLine("*************************************************");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*           Enter a number: 1 and 500           *");
            Console.WriteLine("*                                               *");
            Console.WriteLine("*************************************************");

            int gameAmount = 5;//Convert.ToInt32(Console.ReadLine());

            string[][,] gameResults = new string[gameAmount][,];
            //string[,][] = new string[,][]; an array of arrays
            // p = new 
            for (int i = 0; i == gameAmount; i++)
            {
                string[,] gameStorage = new string[3, 3];
                gameResults[i] = runGame.playGame(0, 0, 0, "x", playerOneAI, playerTwoAI, levelOne, levelTwo);

            }
            return gameResults;
        }
    }
}
