using System;

namespace NewCheckers
{
    public class Checker
    {
        public string Color { get; private set; }
        public bool King { get; private set; }
        public Checker(string color)
        {
            this.King = false;
            this.Color = color == "white" ? "25ce" : "25c9";
        }
        public void MakeKing()
        {
            this.King = true;
        }
    }
}
