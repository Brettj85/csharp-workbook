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
        public int White = 0;
        public int Black = 0;
        public void Run()
        {
            int turn = 1;
            bool GameOver = false;
            int Winner;
            while (!GameOver)
            {
                Select Choose = new Select(turn, CurrentBoard.pieces);
                Coordinates moveFrom = Choose.From();
                Coordinates moveTo = Choose.To(moveFrom);
                bool valid = Choose.CheckValidity(moveFrom, moveTo);

                if (valid)
                {
                    CurrentBoard.pieces[moveTo] = CurrentBoard.pieces[moveFrom];
                    CurrentBoard.pieces[moveFrom] = null;
                    if (moveTo.X == 0 && turn == 1)
                    {
                        this.CurrentBoard.pieces[moveTo].MakeKing();
                    }
                    if (moveTo.X == 7 && turn == 2)
                    {
                        this.CurrentBoard.pieces[moveTo].MakeKing();
                    }
                    if (Choose.Jumped == true)
                    {
                        bool addPoint = CurrentBoard.pieces[Choose.Remove].ColorAbs == "white" ? true : false;
                        this.CurrentBoard.pieces[Choose.Remove] = null;
                        if (addPoint)
                        {
                            this.White++;
                        }
                        else
                        {
                            this.Black++;
                        }
                    }

                    turn = turn == 1 ? 2 : 1;
                }

                GameOver = White == 12 || Black == 12 ? true : false;
                if (GameOver)
                {
                    Winner = White == 12 ? 1 : 2;
                }
            }
        }
    }
}
/*Display display = new Display(CurrentBoard.pieces);
                int one = display.ChooseX(1);
                int two = display.ChooseY(1, one); */
