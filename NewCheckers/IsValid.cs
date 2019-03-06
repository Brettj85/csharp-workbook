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
        public Coordinates Remove;
        public bool Jumped = false;
        public IsValid(int turn, Dictionary<Coordinates, Checker> curBoard, Coordinates from, Coordinates to)
        {
            this.CurBoard = curBoard;
            this.Turn = turn;
            this.From = from;
            this.To = to;
        }
        public bool Run()
        {
            bool isFromValid = false;
            bool isToValid = false;
            isFromValid = CheckFrom();
            isToValid = CheckTo();
            this.Valid = isFromValid && isToValid ? true : false;
            return Valid;
        }
        private bool CheckFrom()
        {
            bool from;
            if (Turn == 1 && CurBoard[From] != null && CurBoard[From].ColorAbs == "white")
            {
                from = true;
            }
            else if (Turn == 2 && CurBoard[From] != null && CurBoard[From].ColorAbs == "black")
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
            to = land.Run(From, To, CurBoard);
            if (land.Jumped)
            {
                this.Remove = land.Remove;
                this.Jumped = true;
            }
            if (Turn == 1 && (From.X - To.X) < 0)
            {
                Checker tryMe;
                if (!CurBoard.TryGetValue(From, out tryMe))
                {
                    if (tryMe != null)
                    {
                        if (!tryMe.King)
                        {
                            to = false;
                        }
                    }
                }
                else
                {
                    if (tryMe != null)
                    {
                        if (!tryMe.King)
                        {
                            to = false;
                        }
                    }
                }
            }
            if (Turn == 2 && (To.X - From.X) < 0)
            {
                Checker tryMe;
                if (!CurBoard.TryGetValue(From, out tryMe))
                {
                    if (tryMe != null && !tryMe.King)
                        if (tryMe != null)
                        {
                            if (!tryMe.King)
                            {
                                to = false;
                            }
                        }
                }
                else
                {
                    to = false;
                }
            }
            return to;
        }

    }
}
