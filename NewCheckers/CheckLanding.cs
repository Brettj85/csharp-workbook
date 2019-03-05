using System;
using System.Collections.Generic;

namespace NewCheckers
{
    public class CheckLanding
    {
        public Coordinates Remove { get; set; }
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
            bool twoSpaces = false;

            foreach (var item in possibles)
            {
                if (item.X == to.X && item.Y == to.Y)
                {
                    isValidLanding = true;
                    if (item.X - 2 == x || item.X + 2 == x)
                    {
                        twoSpaces = true;
                    }
                }
            }
            Checker occupied;
            if (curBoard.TryGetValue(to, out occupied))
            {
                if (occupied != null)
                {
                    isValidLanding = false;
                }
            }

            if (isValidLanding)
            {
                if (twoSpaces)
                {
                    if (toX - 2 == x)
                    {
                        if (toY - 2 == y)
                        {
                            Jumped = true;
                            Remove = new Coordinates(toX - 1, toY - 1);
                        }
                        else
                        {
                            Jumped = true;
                            Remove = new Coordinates(toX - 1, toY + 1);
                        }
                    }
                    else if (toX + 2 == x)
                    {
                        if (toY - 2 == y)
                        {
                            Jumped = true;
                            Remove = new Coordinates(toX + 1, toY - 1);
                        }
                        else
                        {
                            Jumped = true;
                            Remove = new Coordinates(toX + 1, toY + 1);
                        }
                    }
                    else
                    {
                        twoSpaces = true;
                        Jumped = false;
                    }
                }

            }
            bool returnMe = isValidLanding ? true : false;

            return returnMe;
        }
    }
}