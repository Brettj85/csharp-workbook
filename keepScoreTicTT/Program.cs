using System;

namespace TicTacToe
{
    class Program
    {
        public static void Main()
        {
            bool vsAI = true;
            int level = 1;
            playGame(0, 0, 0, "x", vsAI, level);
        }

        public static void playGame(int x, int o, int t, string previousWinner, bool vsAI, int level)
        {
            //keep track of wins and ties
            int xWins = x;
            int oWins = o;
            int timesTied = t;
            //gameplay conditions
            bool win = false;
            string playerTurn = "X";
            if (previousWinner == "X" || previousWinner == "O")
            {
                playerTurn = (previousWinner == "X") ? "X" : "O";
            }
            string winner = "n";
            string tie = "n";
            string[,] board = new string[3, 3];

            bool automaticPlay = true;
            bool playAgain = true;
            //keeps track of the question of manual turns
            bool marker = true;
            //keeps track of a full turn rotation
            int turnTicker = 0;
            int turns = 1;
            while (!win)
            {
                //Make the Board
                printBoard(board);

                //determine if its an NPC or human, and collect the row and column choice. 
                int row;
                int column;
                if (automaticPlay && playerTurn == "O")
                {
                    row = autoSelect(board, level);
                    column = autoSelect(board, level);
                    string computerGuess = (playerTurn + " guess is: " + row.ToString() + " , " + column.ToString());
                    Console.WriteLine();
                    Console.WriteLine(computerGuess);
                    Console.WriteLine();
                }
                else
                {
                    row = manualSelect(playerTurn, marker);
                    marker = false;
                    column = manualSelect(playerTurn, marker);
                    marker = true;
                }

                //check if that spot is taken
                if (isTaken(board, row, column))
                {
                    Console.WriteLine("Sorry that spot is taken");
                }
                else
                {
                    board[row, column] = playerTurn;
                    playerTurn = (playerTurn == "X") ? "O" : "X";
                    turnTicker++;
                    if ((turnTicker % 2) == 0)
                    {
                        turns++;
                    }
                }

                //check for win
                if (turns >= 3)
                {
                    tie = checkTie(board);
                    winner = checkWin(board);
                }

                if (winner == "X")
                {
                    xWins++;
                    Console.Clear();
                    printBoard(board);
                    Console.WriteLine("After {0} turns X is victorious!", turns);
                    Console.WriteLine();
                    Console.WriteLine("There have been {0} Ties the score is", timesTied);
                    Console.WriteLine("X: {0}", xWins);
                    Console.WriteLine("O: {0}", oWins);
                    System.Threading.Thread.Sleep(10000);
                    win = true;
                }
                else if (winner == "O")
                {
                    oWins++;
                    Console.Clear();
                    printBoard(board);
                    Console.WriteLine("After {0} turns O is victorious!", turns);
                    Console.WriteLine();
                    Console.WriteLine("There have been {0} Ties the score is", timesTied);
                    Console.WriteLine("X: {0}", xWins);
                    Console.WriteLine("O: {0}", oWins);
                    System.Threading.Thread.Sleep(10000);
                    win = true;
                }
                else if (tie == "T")
                {
                    timesTied++;
                    Console.Clear();
                    printBoard(board);
                    Console.WriteLine("After {0} turns We have a Tie!", turns);
                    Console.WriteLine("There have been {0} Ties the score is", timesTied);
                    Console.WriteLine("X: {0}", xWins);
                    Console.WriteLine("O: {0}", oWins);
                    System.Threading.Thread.Sleep(10000);
                    win = true;
                }


            }
            if (playAgain)
            {
                playGame(xWins, oWins, timesTied, winner, automaticPlay, level);
            }
        }


        public static bool isTaken(string[,] board, int row, int column)//checks to see if a given tic tac toe spot is occupied
        {
            if (!String.IsNullOrEmpty(board[row, column]) || !String.IsNullOrWhiteSpace(board[row, column]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string checkWin(string[,] board)
        {
            string checkRows = checkHorizontal(board);
            string checkColumns = checkVertical(board);
            string checkCorner2Corner = checkDiagonal(board);

            if (checkRows == "X" || checkColumns == "X" || checkCorner2Corner == "X")
            {
                return "X";
            }
            else if (checkRows == "O" || checkColumns == "O" || checkCorner2Corner == "O")
            {
                return "O";
            }
            else
            {
                return "n";
            }
        }
        public static string checkHorizontal(string[,] board)
        {
            string isWinner = "n";
            for (int i = 0; i <= 2; i++)
            {
                if (!String.IsNullOrWhiteSpace(board[i, 0]) && !String.IsNullOrEmpty(board[i, 0]))
                {
                    if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                    {
                        isWinner = board[i, 0];
                    }
                }
                else
                {
                    isWinner = "n";
                }
            }
            Console.WriteLine(isWinner);
            return isWinner;
        }

        public static string checkVertical(string[,] board)
        {
            string isWinner = "n";
            for (int i = 0; i <= 2; i++)
            {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i] && !String.IsNullOrEmpty(board[0, i]) && !String.IsNullOrWhiteSpace(board[0, 0]))
                {
                    isWinner = board[0, i];
                }
            }
            return isWinner;
        }

        public static string checkDiagonal(string[,] board)
        {
            string isWinner = "n";
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && !String.IsNullOrEmpty(board[0, 0]) && !String.IsNullOrWhiteSpace(board[0, 0]))
            {
                isWinner = board[0, 0];
            }
            else if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && !String.IsNullOrEmpty(board[0, 2]) && !String.IsNullOrWhiteSpace(board[0, 2]))
            {
                isWinner = board[0, 2];
            }
            return isWinner;
        }

        public static string checkTie(string[,] board)
        {
            string isTie = "n";
            for (int i = 0; i <= 2; i++)
            {
                if (String.IsNullOrWhiteSpace(board[i, 0]) || String.IsNullOrWhiteSpace(board[i, 1]) || String.IsNullOrWhiteSpace(board[i, 2]))
                {
                    if (String.IsNullOrEmpty(board[i, 0]) || String.IsNullOrEmpty(board[i, 1]) || String.IsNullOrEmpty(board[i, 2]))
                    {
                        isTie = "n";
                        break;
                    }
                }
                else
                {
                    isTie = "T";
                }
            }
            return isTie;
        }

        public static void printBoard(string[,] board)
        {
            Console.WriteLine("  " + "0" + " 1 " + "2");
            for (int i = 0; i <= 2; i++)
            {
                if (i != 2)
                {

                    Console.WriteLine(i + " " + unlessNull(board[i, 0]) + "|" + unlessNull(board[i, 1]) + "|" + unlessNull(board[i, 2]));
                    Console.WriteLine("  " + "-----");
                }
                else
                {
                    Console.WriteLine(i + " " + unlessNull(board[i, 0]) + "|" + unlessNull(board[i, 1]) + "|" + unlessNull(board[i, 2]));
                }
            }
        }

        public static string unlessNull(string checkValue)
        {
            if (string.IsNullOrEmpty(checkValue))
            {
                return " ";
            }
            else
            {
                return checkValue;
            }
        }
        public static int manualSelect(string player, bool marker)
        {
            int selection;
            if (marker)
            {
                Console.WriteLine("player {0}'s turn!", player);
                Console.Write("Enter Row: ");
                selection = Int32.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("Enter Column: ");
                selection = Int32.Parse(Console.ReadLine());
            }
            return selection;
        }
        //The "AI"
        private static readonly Random getrandom = new Random();
        public static int autoSelect(string[,] board, int level, string playerTurn)
        {
            return easyAI();
        }

        public static int easyAI()
        {
            int aiGuess = getrandom.Next(0, 31);
            int guess = 0;
            if (aiGuess <= 10)
            {
                guess = 0;
            }
            else if (aiGuess <= 20)
            {
                guess = 1;
            }
            else
            {
                guess = 2;
            }
            return guess;
        }

        public static int mediumAI(string[,] board, string playerTurn)
        {
            string checkForWin = lookForWin(board, playerTurn);
        }

        public static string lookForWin(string[,] board, string playerTurn)
        {
            string potentialRowVictory = checkRowpotential(board, playerTurn);
            string potentialColumnVictory = checkColumnpotential(board, playerTurn);
        }
        public static string checkRowpotential(string[,] board, string playerTurn)
        {
            string valueToReturn = "3,3"; ;
            for (int i = 0; i < 3; i++)
            {
                if (String.IsNullOrWhiteSpace(board[i, 0]))
                {
                    if (board[i, 1] == board[i, 2] && board[i, 1] == playerTurn)
                    {
                        valueToReturn = i + ",0";
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[i, 1]))
                {
                    if (board[i, 0] == board[i, 2] && board[i, 0] == playerTurn)
                    {

                        valueToReturn = i + ",1";
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[i, 2]))
                {
                    if (board[i, 1] == board[i, 0] && board[i, 1] == playerTurn)
                    {

                        valueToReturn = i + ",2";
                    }
                }
                else
                {
                    valueToReturn = "3,3";
                }
            }
            return valueToReturn;
        }
        public static string checkColumnpotential(string[,] board, string playerTurn)
        {
            string valueToReturn = "3,3"; ;
            for (int i = 0; i < 3; i++)
            {
                if (String.IsNullOrWhiteSpace(board[0, i]))
                {
                    if (board[1, i] == board[2, i] && board[1, i] == playerTurn)
                    {
                        valueToReturn = "0," + i;
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[1, i]))
                {
                    if (board[0, i] == board[2, i] && board[0, i] == playerTurn)
                    {

                        valueToReturn = "1," + i;
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[i, 2]))
                {
                    if (board[i, 1] == board[i, 0] && board[i, 1] == playerTurn)
                    {

                        valueToReturn = i + ",2";
                    }
                }
                else
                {
                    valueToReturn = "3,3";
                }
            }
            return valueToReturn;
        }
    }
}


