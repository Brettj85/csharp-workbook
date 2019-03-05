using System;

namespace NewCheckers
{
    public class Game
    {
        //request both moves controle board
        Board CurrentBoard;
        public Game()
        {
            CurrentBoard = new Board();
        }
        public void Run()
        {
            int turn = 1;
            bool GameOver = false;
            int Winner;
            while (!GameOver)
            {
                Select Choose = new Select(turn, CurrentBoard.pieces);
                Coordinates moveFrom = Choose.From();
                Coordinates moveTo = Choose.To();
                bool valid = Choose.CheckValidity(moveFrom, moveTo);
                Display disp = new Display(CurrentBoard.pieces);
                //disp.printBoard();
                int one = disp.ChooseX(1);
                int two = disp.ChooseY(1, one);
                Console.WriteLine(one + "," + two);
            }
        }
    }
}