using System;

namespace NewCheckers
{
    public struct Coordinates
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
