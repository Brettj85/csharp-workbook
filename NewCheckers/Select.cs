using System;
using System.Collections.Generic;
using System.Threading;

namespace NewCheckers
{
    public class Select
    {
        private Dictionary<Coordinates, Checker> CurBoard;
        private int Turn;
        public Select(int currentTurn, Dictionary<Coordinates, Checker> CurrentBoard)
        {
            CurBoard = CurrentBoard;
            Turn = currentTurn;
        }
        public Coordinates From()
        {
            Display display = new Display(CurBoard);
            int row = display.ChooseX(Turn);
            int column = display.ChooseY(Turn, row);
            return new Coordinates(row, column);
        }
        public Coordinates To()
        {
            Display display = new Display(CurBoard);
            int row = display.ChooseX(Turn);
            int column = display.ChooseY(Turn, row);
            return new Coordinates(row, column);
        }
        public bool CheckValidity(Coordinates from, Coordinates to)
        {
            IsValid isValid = new IsValid(Turn, CurBoard, from, to);
            bool valid = isValid.Check();
            return valid;
        }
    }
}