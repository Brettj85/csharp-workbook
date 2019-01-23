using System;
using System.Text;

namespace TicTacToe
{
    class Program
    {
        public static void Main()
        {
            string[,][] returnedResults = new string[3, 3][];
            Menu.mainMenu(returnedResults);
        }
    }
}








