using System;
using System.Collections.Generic;

namespace NewCheckers
{
    public class CheckLanding
    {
        public Coordinates remove { get; set; }
        public bool Jumped { get; set; } = false;
        public CheckLanding()
        {
            Jumped = false;
        }
        public bool Run(Coordinates from, Coordinates to, Dictionary<Coordinates, Checker> curBoard)
        {
            int x = from.X;
            int y = from.Y;
            int toX = to.X;
            int toY = to.Y;

            List<Coordinates> possibles = new List<Coordinates>();
            possibles.Add(new Coordinates(x - 1, y - 1));
            possibles.Add(new Coordinates(x - 2, y - 2));
            possibles.Add(new Coordinates(x + 1, y + 1));
            possibles.Add(new Coordinates(x + 2, y + 2));
            possibles.Add(new Coordinates(x - 1, y + 1));
            possibles.Add(new Coordinates(x - 2, y + 2));
            possibles.Add(new Coordinates(x + 1, y - 1));
            possibles.Add(new Coordinates(x + 2, y - 2));

            bool isValidLanding = false;

            foreach (var item in possibles)
            {
                if (item.X == to.X && item.Y == to.Y)
                {
                    isValidLanding = true;
                }
            }
            if (isValidLanding)
            {

                if ()

            }

        }
    }
}