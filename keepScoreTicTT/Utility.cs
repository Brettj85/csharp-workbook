using System;
using System.Text;

namespace TicTacToe
{
    public class Utility
    {
        public static string boardToString(string[,] board)
        {
            string[,] winningBoard = board;
            var sb = new StringBuilder(string.Empty);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (!string.IsNullOrWhiteSpace(winningBoard[i, j]))
                    {
                        if (j != 2)
                        {
                            sb.Append(winningBoard[i, j] + ",");
                        }
                        else
                        {
                            sb.Append(winningBoard[i, j]);
                        }
                    }
                    else
                    {
                        sb.Append("n" + ",");
                    }
                }
                if (i != 2)
                {
                    sb.Append("*");
                }
            }
            var result = sb.ToString();
            return result;
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

    }
}