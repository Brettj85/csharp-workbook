using System;

namespace TicTacToe
{
    class Program
    {
        public static void Main()
        {
            playGame();
        }
        public static void playGame()
        {
            string playerTurn = "X";
            string winner = "n";
            string[,] board = new string[3, 3];
            bool win = false;
            while (!win)
            {
                board = selectSpot(board, playerTurn);
                playerTurn = (playerTurn == "X") ? "O" : "X";
                winner = checkWin(board);
                winner = checkTie(board);
                if (winner == "X" || winner == "O")
                {
                    Console.WriteLine("The winner is {0}", winner);
                    win = true;
                }
                else if (winner == "T")
                {
                    Console.WriteLine("Its a Tie!");
                    win = true;
                }
            }
        }

        public static string[,] selectSpot(string[,] board, string playerTurn)
        {
            int row = 10;
            int column = 10;
            bool controller = true;
            while (controller)
            {
                printBoard(board);
                Console.WriteLine("Player " + playerTurn);
                Console.WriteLine("Enter Row:");
                row = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Column:");
                column = Int32.Parse(Console.ReadLine());

                if (isTaken(board, row, column))
                {
                    Console.WriteLine("sorry that spot is taken");
                }
                else
                {
                    controller = false;
                }

            }

            board[row, column] = playerTurn;
            return board;

        }

        public static bool isTaken(string[,] board, int row, int column)
        {
            if (row != 10)
            {
                if (String.IsNullOrEmpty(board[row, column]))
                {
                    return false;
                }
                else
                {
                    return true;
                }
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
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && !String.IsNullOrEmpty(board[i, 0]))
                {
                    isWinner = board[i, 0];
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
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i] && !String.IsNullOrEmpty(board[0, i]))
                {
                    isWinner = board[0, i];
                }
            }
            return isWinner;

        }

        public static string checkDiagonal(string[,] board)
        {
            string isWinner = "n";
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && !String.IsNullOrEmpty(board[0, 0]))
            {
                isWinner = board[0, 0];
            }
            else if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && !String.IsNullOrEmpty(board[0, 2]))
            {
                isWinner = board[0, 2];
            }
            return isWinner;
        }

        public static string checkTie(string[,] board)
        {
            string winner = checkWin(board);
            if (winner == "n")
            {
                for (int i = 0; i < 8; i++)
                {
                    if (String.IsNullOrEmpty(board[i, 0]))
                    {
                        return "n";
                    }
                    else if (String.IsNullOrEmpty(board[i, 1]))
                    {
                        return "n";
                    }
                    else if (String.IsNullOrEmpty(board[i, 2]))
                    {
                        return "n";
                    }
                }
                return "t";
            }
            return winner;
        }
        public static void printBoard(string[,] board)
        {
            Console.WriteLine("  " + "0" + " 1 " + "2");
            Console.WriteLine("0 " + board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
            Console.WriteLine(" " + "-----");
            Console.WriteLine("1 " + board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
            Console.WriteLine(" " + "-----");
            Console.WriteLine("2 " + board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
        }
    }
}
