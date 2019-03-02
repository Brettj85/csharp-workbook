using System;

namespace NewCheckers
{
    public class Checker
    {
        public string Color { get; private set; }
        public bool King { get; private set; } = false;
        public Checker(string color)
        {
            Color = color == "white" ? "25ce" : "25c9";
        }
        public void MakeKing()
        {
            King = true;
        }
    }
}
