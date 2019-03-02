using System;
using System.Collections.Generic;

namespace NewCheckers
{
    public class Board
    {
        public Dictionary<Coordinates, Checker> pieces { get; set; } = new Dictionary<Coordinates, Checker>();

        public void board()
        {
            pieces = new Dictionary<Coordinates, Checker>();
        }
        public static void MoveChecker(Checker piece, Coordinates cords)
        {
            CheckValidity(piece, cords);
        }
        private static bool CheckValidity(Checker piece, Coordinates cords)
        {
            bool valid = false;
            bool direction = CheckDirection(piece, cords);
            bool space = CheckSpace(piece, cords);
            valid = direction && space ? true : false;
            return valid;
        }
        private static bool CheckDirection(Checker piece, Coordinates cords)
        {
            bool valid = false;
            return valid;
        }
        private static bool CheckSpace(Checker piece, Coordinates cords)
        {
            bool valid = false;
            return valid;
        }
    }
}
