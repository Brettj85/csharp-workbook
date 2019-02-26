using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckersCheckpoint
{
    public class Checker
    {
        public string symbol;
        public int[] position;
        public string color;


        public Checker(string color, int[] position)
        {
            int circleId;

            if (color == "white")
            {
                circleId = int.Parse(" 25CE", System.Globalization.NumberStyles.HexNumber);
                Color = "white";
            }
            else
            {
                circleId = int.Parse(" 25C9", System.Globalization.NumberStyles.HexNumber);
                Color = "black";
            }
            this.Symbol = char.ConvertFromUtf32(circleId);
            this.Position = position;
        }

        public string Symbol
        {
            get;
            set;
        }

        public int[] Position
        {
            get;
            set;
        }

        public string Color
        {
            get;
            set;
        }
    }
}