using System;
using System.Collections.Generic;

namespace NewCheckers
{
    public class IsValid
    {
        private int Turn;
        private Dictionary<Coordinates, Checker> CurBoard;
        private Coordinates From;
        private Coordinates To;
        public bool Valid = false;
        public Coordinates remove;
        public IsValid(int turn, Dictionary<Coordinates, Checker> curBoard, Coordinates from, Coordinates to)
        {
            this.CurBoard = curBoard;
            this.Turn = turn;
            this.From = from;
            this.To = to;
        }
        public bool Run()
        {
            bool isFromValid = CheckFrom();
            bool isToValid = CheckTo();
            this.Valid = isFromValid && isToValid ? true : false;
            return Valid;
        }
        private bool CheckFrom()
        {
            bool from;
            if (Turn == 1 && CurBoard[From].ColorAbs == "white")
            {
                from = true;
            }
            else if (Turn == 2 && CurBoard[From].ColorAbs == "black")
            {
                from = true;
            }
            else
            {
                from = false;
            }
            return from;
        }
        private bool CheckTo()
        {
            bool to = false;
            CheckLanding land = new CheckLanding();
            land.Run(From, To, CurBoard);
            return to;
        }

    }
}
