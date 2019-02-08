using System;
using System.Collections.Generic;
using System.Threading;

namespace gameboy
{
    class MainMenuController
    {
        private List<string> menuItems = new List<string>() { "Play Games", "Cheat", "Stats", "Exit" };
        private ProfileController profile = new ProfileController();
        private CheatController cheats = new CheatController();
        private GamesController games = new GamesController();
        private Display display = new Display();
        public void StartMainMenu()
        {
            do
            {
                profile.Create();

            } while (!profile.active);

            string userRequest = display.getInput(menuItems);
            //

        }
    }
}
