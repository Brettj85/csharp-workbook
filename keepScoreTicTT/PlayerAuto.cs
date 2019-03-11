using System;
using System.Text;

namespace TicTacToe
{
    public class PlayerAuto
    {
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
                        if (runGame.isTaken(board, row, column))
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
                        if (runGame.isTaken(board, row, column))
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
                        if (runGame.isTaken(board, row, column))
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
                        if (runGame.isTaken(board, row, column))
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
                        if (runGame.isTaken(board, row, column))
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
                        if (runGame.isTaken(board, row, column))
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
                if (runGame.checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = i.ToString() + "," + i.ToString();
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (runGame.isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
                testBoard[i, i] = board[i, i];
            }
            if (valueToReturn != "n")
            {
                testBoard[0, 2] = playerTurn;
                if (runGame.checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = "0,2";
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (runGame.isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
                testBoard[0, 2] = board[0, 2];
                testBoard[1, 1] = playerTurn;
                if (runGame.checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = "1,1";
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (runGame.isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
                testBoard[1, 1] = board[1, 1];
                testBoard[2, 0] = playerTurn;
                if (runGame.checkDiagonal(testBoard) != "n")
                {
                    valueToReturn = "2,0";
                    int row = (Convert.ToInt32(valueToReturn.Substring(0, 1)));
                    int column = (Convert.ToInt32(valueToReturn.Substring(2, 1))); ;
                    if (runGame.isTaken(board, row, column))
                    {
                        valueToReturn = "n";
                    }
                }
            }
            return valueToReturn;
        }
    }
}