using System;

namespace recursive_RockPaperScissors
{
    class Program
    {
        public static int runGame(int first, int second, string isReplay)
        {
            int player1 = first;
            int player2 = second;
            int findWinner = 0;
            string player2Name = "";
            string replay = isReplay;
            Console.Clear();
            Console.WriteLine("would you like to play a 2 player game {0} y/n", replay);

            if (stringToBool(Console.ReadLine()))
            {
                player2Name = "Player 2";
                Console.WriteLine("enter player one's selection: rock, paper, or scissors");
                string player1Guess = (simplified(Console.ReadLine()));
                Console.WriteLine("enter player two's selection: rock, paper, or scissors");
                string player2Guess = (simplified(Console.ReadLine()));
                findWinner = (whoWins(player1Guess, player2Guess));
            }
            else
            {
                player2Name = "The Computer";
                Console.WriteLine("enter player ones selection: rock, paper, or scissors");
                string player1Guess = (simplified(Console.ReadLine()));
                string aiGuess = (computerGuess());
                findWinner = (whoWins(player1Guess, aiGuess));
            }

            Console.WriteLine("current score is {0} to {1}.", player1, player2);
            if (findWinner == 1)
            {
                Console.WriteLine("Player one has won this round");
                player1++;
            }
            else if (findWinner == 2)
            {
                Console.WriteLine("{0} has won this round!", player2Name);
                player2++;
            }
            else
            {
                Console.WriteLine("Player1 and {0} tied this round!", player2Name);
            }

            Console.Write("");
            Console.Write("play again? y/n ");


            if (stringToBool(Console.ReadLine()))
            {
                replay = "this time";
                return runGame(player1, player2, replay);
            }
            else
            {
                if (player1 > player2)
                {
                    Console.WriteLine("The final score is {0} to {1} Player 1 Wins the game!", player1, player2);
                    System.Threading.Thread.Sleep(2000);
                    return 1;
                }
                else if (player1 < player2)
                {
                    Console.WriteLine("The final score is {0} to {1} {2} Wins the game!", player1, player2, player2Name);
                    System.Threading.Thread.Sleep(2000);
                    return 2;
                }
                else
                {
                    Console.WriteLine("The final score is {0} to {1} the game is a tie!", player1, player2, player2Name);
                    System.Threading.Thread.Sleep(2000);
                    return 0;
                }
            }

        }

        public static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("----ROCK PAPER SCISSOR SHOOT----");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Threading.Thread.Sleep(4000);
            int winner = runGame(0, 0, "");
        }

        public static bool stringToBool(string userInput)
        {
            string simplified = userInput.Substring(0, 1).ToLower();
            if (simplified == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string simplified(string selection)
        {
            string simple = selection.ToLower().Substring(0, 1);
            return simple;
        }

        public static int whoWins(string first, string second)
        {
            int win = 0;
            if (first == second)
            {
                win = 0;
            }
            else if (first == "r" && second != "p")
            {
                win = 1;
            }
            else if (first == "p" && second != "s")
            {
                win = 1;
            }
            else if (first == "s" && second != "r")
            {
                win = 1;
            }
            else
            {
                win = 2;
            }
            return win;

        }

        private static readonly Random getrandom = new Random();

        public static string computerGuess()
        {
            int aiGuess = getrandom.Next(1, 4);
            string guess = "";

            switch (aiGuess)
            {
                case 1:
                    guess = "r";
                    break;
                case 2:
                    guess = "s";
                    break;
                case 3:
                    guess = "p";
                    break;
                default:
                    break;
            }

            return guess;
        }
    }
}