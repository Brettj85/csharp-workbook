using System;

namespace NewCheckers
{
    public class Checker
    {
        public string Color { get; private set; }
        public string ColorAbs { get; private set; }
        public bool King { get; private set; }
        public Checker(string color)
        {
            int circleId;

            if (color == "white")
            {
                circleId = int.Parse("25CE", System.Globalization.NumberStyles.HexNumber);
                ColorAbs = "white";
            }
            else
            {
                circleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                ColorAbs = "black";
            }
            this.Color = char.ConvertFromUtf32(circleId);
        }
        public void MakeKing()
        {
            this.King = true;
        }
    }
}
