using System;
using System.Collections.Generic;
using System.Threading;

namespace NewCheckers
{
    public class Select
    {
        private Dictionary<Coordinates, Checker> CurBoard;
        private int Turn;
        public bool Jumped = false;
        public Coordinates Remove;
        public Select(int currentTurn, Dictionary<Coordinates, Checker> CurrentBoard)
        {
            CurBoard = CurrentBoard;
            Turn = currentTurn;
        }
        public Coordinates From()
        {
            Display display = new Display(CurBoard);
            int row = display.ChooseX(Turn, null, null);
            int column = display.ChooseY(Turn, row, null, null);
            return new Coordinates(row, column);
        }
        public Coordinates To(Coordinates old)
        {
            string x = old.X.ToString();
            string y = old.Y.ToString();
            Display display = new Display(CurBoard);
            int row = display.ChooseX(Turn, x, y);
            int column = display.ChooseY(Turn, row, x, y);
            return new Coordinates(row, column);
        }
        public bool CheckValidity(Coordinates from, Coordinates to)
        {
            IsValid isValid = new IsValid(Turn, CurBoard, from, to);
            bool valid = isValid.Run();
            if (isValid.Jumped)
            {
                this.Jumped = true;
                this.Remove = isValid.Remove;
            }
            return valid;
        }
    }
}