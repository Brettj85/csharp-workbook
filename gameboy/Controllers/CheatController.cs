using System;
using System.Collections.Generic;
using System.Threading;

namespace gameboy
{
    class CheatController
    {
        public bool active { get; private set; } = false;
        private List<string> cheats = new List<string>() { "Enter Cheat", "View Active", "Disable Cheats", "Disable All Cheats", "Exit" };
        Display display = new Display();
        public CheatController CheatMenu(CheatController cheat)
        {
            CheatController current = cheat;
            string userRequest = display.getInput(cheats);
            return current;
        }

    }
}