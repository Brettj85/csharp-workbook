using System;
using System.Collections.Generic;
using System.Threading;

namespace NewCheckers
{
    public class Board
    {
        public Dictionary<Coordinates, Checker> pieces { get; set; }

        public Board()
        {
            pieces = new Dictionary<Coordinates, Checker>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Coordinates cord = new Coordinates(i, j);
                    Checker check = null;
                    switch (i)
                    {
                        case 0:
                            if (j % 2 == 0 || j == 0)
                            {
                                check = new Checker("black");
                                pieces.Add(cord, check);
                            }
                            else
                            {
                                pieces.Add(cord, null);
                            }
                            break;
                        case 1:
                            if (j % 2 == 0 || j == 0)
                            {
                                pieces.Add(cord, null);
                            }
                            else
                            {
                                check = new Checker("black");
                                pieces.Add(cord, check);
                            }
                            break;
                        case 2:
                            if (j % 2 == 0 || j == 0)
                            {
                                check = new Checker("black");
                                pieces.Add(cord, check);
                            }
                            else
                            {
                                pieces.Add(cord, null);
                            }
                            break;
                        case 5:
                            if (j % 2 == 0 || j == 0)
                            {
                                pieces.Add(cord, null);
                            }
                            else
                            {
                                check = new Checker("white");
                                pieces.Add(cord, check);
                            }
                            break;
                        case 6:
                            if (j % 2 == 0 || j == 0)
                            {
                                check = new Checker("white");
                                pieces.Add(cord, check);
                            }
                            else
                            {
                                pieces.Add(cord, null);
                            }
                            break;
                        case 7:
                            if (j % 2 == 0 || j == 0)
                            {
                                pieces.Add(cord, null);
                            }
                            else
                            {
                                check = new Checker("white");
                                pieces.Add(cord, check);
                            }
                            break;
                        default:
                            pieces.Add(cord, null);
                            break;
                    }
                }
            }
        }
    }
}

