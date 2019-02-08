using System;
using System.Collections.Generic;
using System.Threading;

namespace gameboy
{
    class MainMenuController
    {
        private List<string> menuItems = new List<string>() { "Play Games", "Cheats", "Profile", "Exit" };
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
            StartSelection(userRequest);
        }
        private void StartSelection(string request)
        {
            if (request == "Play Games")
            {
                this.profile = games.SelectGame(profile, cheats);
            }
            if (request == "Cheats")
            {
                this.cheats = cheats.CheatMenu(cheats);
            }
            if (request == "Profile")
            {
                this.profile.ProfileMenu();
            }
        }
    }
}
