using System;
using System.Collections.Generic;
using System.Threading;

namespace NewCheckers
{
    public class Board
    {
        public Dictionary<Coordinates, Checker> pieces { get; set; }

        public void board()
        {
            this.pieces = new Dictionary<Coordinates, Checker>();
            CreateCheckers buildNew = new CreateCheckers();
            this.pieces = buildNew.InitialCheckers();
        }

        public void ChooseMove(int PlayerTurn)
        {
            int row = PickRow();
            int column = PickColumn();
            Coordinates from = new Coordinates(row, column);
            Checker result;
            if (pieces.TryGetValue(from, out result))
            {
                if (PlayerTurn == 0 && result.Color == "25ce")
                {
                    int toRow = PickRow();
                    int toColumn = PickColumn();
                    Coordinates to = new Coordinates(toRow, toColumn);
                    CheckMoveValidity check = new CheckMoveValidity(pieces);
                    bool valid = check.Validity(to, from);
                    if (valid)
                    {
                        pieces[check.RemoveMe.X, check.RemoveMe.Y]
                        this.pieces[to] = pieces[from];
                        this.pieces[from] = null;
                    }
                }
                else if (PlayerTurn == 1 && result.Color == "25c9")
                {
                    int toRow = PickRow();
                    int toColumn = PickColumn();
                    Coordinates to = new Coordinates(toRow, toColumn);
                    CheckMoveValidity check = new CheckMoveValidity(pieces);
                    bool valid = check.Validity(to, from);
                    if (valid)
                    {
                        this.pieces[to] = pieces[from];
                        this.pieces[from] = null;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Selection.");
                    Thread.Sleep(500);
                }
            }

            //if this "cords" (row/column) contains a checker of the Player whos turn this is initiate move checker
        }
    }
}
