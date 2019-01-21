using System;

namespace TicTacToe
{
    class Program
    {
        public static void Main()
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

            playGame(0, 0, 0, "x", playerOneAI, playerTwoAI, levelOne, levelTwo);
        }

        public static void playGame(int x, int o, int t, string previousWinner, bool playerOneAI, bool playerTwoAI, int levelOne, int levelTwo)
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
                    string selectedSpot = autoSelect(board, playerTwolevel, playerTurn);

                    row = (Convert.ToInt32(selectedSpot.Substring(0, 1)));
                    column = (Convert.ToInt32(selectedSpot.Substring(2, 1))); ;
                    string computerGuess = (playerTurn + " guess is: " + row.ToString() + " , " + column.ToString());
                    Console.WriteLine();
                    Console.WriteLine(computerGuess);
                    Console.WriteLine();
                }
                else if (isOneAI && playerTurn == "X")
                {
                    string selectedSpot = autoSelect(board, playerOnelevel, playerTurn);

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
            if (playAgain)
            {
                playGame(xWins, oWins, timesTied, winner, isOneAI, isTwoAI, playerOnelevel, playerTwolevel);
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
        //The "AI" 3 levels
        private static readonly Random getrandom = new Random();

        public static string autoSelect(string[,] board, int level, string playerTurn)
        {

            string computerGuess = "n";
            if (level == 0)
            {
                computerGuess = easyAI() + "," + easyAI();
            }
            else if (level == 1)
            {
                computerGuess = mediumAI(board, playerTurn);
            }
            //return appropriate level AI's choice
            return computerGuess;
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

        public static string mediumAI(string[,] board, string playerTurn)
        {
            string opponentTurn = (playerTurn == "X") ? "O" : "X";
            string checkForWin = lookForWin(board, playerTurn);
            string checkForBlock = lookForWin(board, opponentTurn);

            if (checkForWin != "n")
            {
                return checkForWin;
            }
            else if (checkForBlock != "n")
            {
                return checkForBlock;
            }
            else
            {
                return easyAI() + "," + easyAI();
            }
        }

        public static string lookForWin(string[,] board, string playerTurn)
        {
            string potentialRowVictory = checkRowpotential(board, playerTurn);
            string potentialColumnVictory = checkColumnpotential(board, playerTurn);
            string potentialDiagVictory = checkDiagPotential(board, playerTurn);

            string returnValue = "n";

            //check each
            if (potentialRowVictory != "n")
            {
                returnValue = potentialRowVictory;
            }
            else if (potentialColumnVictory != "n")
            {
                returnValue = potentialColumnVictory;
            }
            else if (potentialDiagVictory != "n")
            {
                returnValue = potentialDiagVictory;
            }
            return returnValue;
        }
        public static string checkRowpotential(string[,] board, string playerTurn)
        {
            string valueToReturn = "n";
            for (int i = 0; i < 3; i++)
            {
                if (String.IsNullOrWhiteSpace(board[i, 0]))
                {
                    if (board[i, 1] == board[i, 2] && board[i, 1] == playerTurn)
                    {
                        valueToReturn = i + ",0";
                        int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                        int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                        if (isTaken(board, row, column))
                        {
                            valueToReturn = "n";
                        }
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[i, 1]))
                {
                    if (board[i, 0] == board[i, 2] && board[i, 0] == playerTurn)
                    {

                        valueToReturn = i + ",1";
                        int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                        int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                        if (isTaken(board, row, column))
                        {
                            valueToReturn = "n";
                        }
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[i, 2]))
                {
                    if (board[i, 1] == board[i, 0] && board[i, 1] == playerTurn)
                    {

                        valueToReturn = i + ",2";
                        int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                        int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                        if (isTaken(board, row, column))
                        {
                            valueToReturn = "n";
                        }
                    }
                }
                else
                {
                    valueToReturn = "n";

                }
            }
            return valueToReturn;
        }
        public static string checkColumnpotential(string[,] board, string playerTurn)
        {
            string valueToReturn = "n"; ;
            for (int i = 0; i < 3; i++)
            {
                if (String.IsNullOrWhiteSpace(board[0, i]))
                {
                    if (board[1, i] == board[2, i] && board[1, i] == playerTurn)
                    {
                        valueToReturn = "0," + i;
                        int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                        int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                        if (isTaken(board, row, column))
                        {
                            valueToReturn = "n";
                        }
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[1, i]))
                {
                    if (board[0, i] == board[2, i] && board[0, i] == playerTurn)
                    {

                        valueToReturn = "1," + i;
                        int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                        int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                        if (isTaken(board, row, column))
                        {
                            valueToReturn = "n";
                        }
                    }
                }
                else if (String.IsNullOrWhiteSpace(board[i, 2]))
                {
                    if (board[i, 1] == board[i, 0] && board[i, 1] == playerTurn)
                    {

                        valueToReturn = "2," + i;
                        int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                        int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                        if (isTaken(board, row, column))
                        {
                            valueToReturn = "n";
                        }
                    }
                }
                else
                {
                    valueToReturn = "n";
                }
            }
            return valueToReturn;
        }
        public static string checkDiagPotential(string[,] board, string playerTurn)
        {
            string valueToReturn = "n"; ;
            string[,] testBoard = board;
            for (int i = 0; i > 2; i++)
            {
                testBoard[i, i] = playerTurn;
                if (checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = i.ToString() + "," + i.ToString();
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
                testBoard[i, i] = board[i, i];
            }
            if (valueToReturn != "n")
            {
                testBoard[0, 2] = playerTurn;
                if (checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = "0,2";
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
                testBoard[0, 2] = board[0, 2];
                testBoard[1, 1] = playerTurn;
                if (checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = "1,1";
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
                testBoard[1, 1] = board[1, 1];
                testBoard[2, 0] = playerTurn;
                if (checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = "2,0";
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
            }
            return valueToReturn;
        }
    }
}



