using System;
using System.Collections.Generic;

namespace guessingGame
{
    class CheatController
    {
        private bool not_random = false;
        private bool inf_lives = false;
        public bool added_cheat { get; private set; } = false;
        public void AddCheat(string password)
        {
            if (password == "ch0053#" && !not_random)
            {
                this.not_random = true;
                this.added_cheat = true;
            }
            if (password == "und131ng" && !inf_lives)
            {
                this.inf_lives = true;
                this.added_cheat = true;
            }
            if (!this.added_cheat)
            {
                Console.WriteLine("Invalid Cheat Code or that cheat is already enabled!");
            }
        }
        public bool[] RetriveCheats()
        {
            bool[] cheats = new bool[] { this.not_random, this.inf_lives };
            return cheats;
        }

    }
}