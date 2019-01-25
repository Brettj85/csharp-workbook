using System;
using System.Text;

namespace TicTacToe
{
    class runGame
    {


        // if not static need to create a new  ie var = new playGame()
        //if static ie program.playgame
        public static string[,] playGame(int x, int o, int t, string previousWinner, bool playerOneAI, bool playerTwoAI, int levelOne, int levelTwo)
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

            bool isOneAI = playerOneAI;
            bool isTwoAI = playerTwoAI;
            int playerOnelevel = levelOne;
            int playerTwolevel = levelTwo;
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
                if (isTwoAI && playerTurn == "O")
                {
                    string selectedSpot = PlayerAuto.autoSelect(board, playerTwolevel, playerTurn);

                    row = (Convert.ToInt32(selectedSpot.Substring(0, 1)));
                    column = (Convert.ToInt32(selectedSpot.Substring(2, 1))); ;
                    string computerGuess = (playerTurn + " guess is: " + row.ToString() + " , " + column.ToString());
                    Console.WriteLine();
                    Console.WriteLine(computerGuess);
                    Console.WriteLine();
                }
                else if (isOneAI && playerTurn == "X")
                {
                    string selectedSpot = PlayerAuto.autoSelect(board, playerOnelevel, playerTurn);

                    row = (Convert.ToInt32(selectedSpot.Substring(0, 1)));
                    column = (Convert.ToInt32(selectedSpot.Substring(2, 1))); ;
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

            return board;

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

                    Console.WriteLine(i + " " + Utility.unlessNull(board[i, 0]) + "|" + Utility.unlessNull(board[i, 1]) + "|" + Utility.unlessNull(board[i, 2]));
                    Console.WriteLine("  " + "-----");
                }
                else
                {
                    Console.WriteLine(i + " " + Utility.unlessNull(board[i, 0]) + "|" + Utility.unlessNull(board[i, 1]) + "|" + Utility.unlessNull(board[i, 2]));
                }
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
    }
}