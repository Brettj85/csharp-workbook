using System;
using System.Collections.Generic;
using System.Threading;

namespace gameboy
{
    class MainMenuController
    {
        private List<string> menuItems = new List<string>() { "Profile", "Play Games", "Cheats", "Exit" };
        private string menuType = "MAIN MENU";
        private ProfileController profile = new ProfileController();
        private CheatController cheats = new CheatController();
        private GamesController games = new GamesController();
        private Display display;
        public void StartMainMenu()
        {

            string userRequest = "";
            do
            {
                profile.Create();

            } while (!profile.active);
            do
            {
                display = new Display();
                userRequest = display.getInput(menuItems, menuType);
                StartSelection(userRequest);
            } while (userRequest != "Exit");
        }
        private bool StartSelection(string request)
        {
            if (request == "Play Games")
            {
                this.profile = games.SelectGame(profile, cheats);
            }
            if (request == "Cheats")
            {
                cheats.CheatMenu();
            }
            if (request == "Profile")
            {
                this.profile.ProfileMenu();
            }
            if (request == "Exit")
            {
                Console.Clear();
                Console.WriteLine("Thanks For Playing!");
                Thread.Sleep(1000);
                return false;
            }
            return true;
        }
    }
}
