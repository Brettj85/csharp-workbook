using System;
using System.Collections.Generic;


namespace gameboy
{
    class CheatController
    {
        public bool active { get; private set; } = false;
        private List<string> cheats = new List<string>() { "Enter Cheat", "View Active", "Disable Cheats", "Disable All Cheats", "Exit" };
        private string menuType = "CHEATS";
        private Display display;
        public CheatController CheatMenu(CheatController cheat)
        {
            CheatController current = cheat;
            string userRequest = "";
            while (userRequest != "Exit")
            {
                display = new Display();
                userRequest = display.getInput(cheats, menuType);
            }
            return current;
        }
    }
}