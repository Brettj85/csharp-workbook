using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            int firstPlayer = 0;
            int secondPlayer = 0;
            bool keepPlaying = true;
            bool playAgain = true;
            while (keepPlaying == true)
            {
                while (playAgain == true)
                {
                    string hand1 = null;
                    string hand2 = "";
                    Console.Clear();
                    Console.WriteLine("Enter hand 1:");
                    try
                    {
                        hand1 = Console.ReadLine().ToLower();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("invalid selection");
                    }
                    Console.WriteLine("Enter hand 2 or c for a computer player");
                    try
                    {
                        hand2 = Console.ReadLine().ToLower();
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("invalid selection");
                    }
                    string showWinner = (CompareHands(hand1, hand2));
                    string[] splitResults = showWinner.Split('*');
                    string winnerText = splitResults[0];
                    int winnerAdd = Convert.ToInt32(splitResults[1]);
                    Console.WriteLine(winnerText);
                    if (winnerAdd == 1)
                    {
                        firstPlayer++;
                    }
                    else if (winnerAdd == 2)
                    {
                        secondPlayer++;
                    }
                    Console.WriteLine("The score is {0} to {1}", firstPlayer, secondPlayer);

                    playAgain = false;
                }
                Console.WriteLine("Would you like to play again y/n");
                bool playingagain = (restartGame(Console.ReadLine()));
                if (playingagain)
                {
                    playAgain = true;
                }
            }
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        private static readonly Random getrandom = new Random();
        public static string CompareHands(string hand1, string hand2)
        {
            // Your code here
            string hand2c = hand2;
            string ifComputer = "Player 2";
            if (hand2 == "c")
            {
                int computer = getrandom.Next(1, 3);
                string[] computerOptions = { "rock", "paper", "scissors" };
                hand2c = computerOptions[computer];
                ifComputer = "The computer";
            }
            string winner = "";
            string addPoints = "";
            if (hand1 == hand2c)
            {
                winner = "It's a tie!";
            }
            else if (hand1 == "rock" && hand2c != "paper")
            {
                winner = "Player One has won the game!*1";
            }
            else if (hand1 == "scissors" && hand2c != "rock")
            {
                winner = "Player One has won the game!*1";
            }
            else if (hand1 == "paper" && hand2c != "scissors")
            {
                winner = "Player One has won the game!*1";
            }
            else
            {
                winner = ($"{ifComputer} has won the game!*2");
            }
            return winner;
        }
        public static bool restartGame(string answer)
        {
            string play = answer.ToLower();
            if (play == "y" || play == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
