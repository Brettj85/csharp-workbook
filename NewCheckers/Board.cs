using System;
using System.Collections.Generic;
using System.Threading;

namespace NewCheckers
{
    public class Board
    {
        public Dictionary<Coordinates, Checker> pieces { get; set; }
        public static Dictionary<Coordinates, Checker> StaticBoard { get; set; }

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
                    StaticBoard = pieces;
                    bool valid = CheckValidity(to, from);
                    if (valid)
                    {
                        this.pieces[to] = pieces[from];
                        this.pieces[from] = null;
                    }
                }
                else if (PlayerTurn == 1 && result.Color == "25c9")
                {
                    int toRow = PickRow();
                    int toColumn = PickColumn();
                    Coordinates to = new Coordinates(toRow, toColumn);
                    StaticBoard = pieces;
                    bool valid = CheckValidity(to, from);
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
        private static bool CheckValidity(Coordinates to, Coordinates from)
        {
            bool valid = false;
            bool validDirection = CheckDirection(to, from);
            bool space = CheckLanding(to, from);
            valid = validDirection && space ? true : false;
            return valid;
        }
        private static bool CheckDirection(Coordinates to, Coordinates from)
        {
            bool valid = false;
            bool isKing = StaticBoard[to].King;
            //check direction validity. king? if yes can go backwards, player 1 goes one way 2 the other
            return valid;
        }
        private static bool CheckLanding(Coordinates to, Coordinates from)
        {
            bool valid = false;
            // check landing space validity is another checker already here, is it a valid space
            return valid;
        }
    }
}
