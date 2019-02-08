using System;
using System.Collections.Generic;


namespace gameboy
{
    class GamesController
    {
        private List<string> games = new List<string>() { "Towers Of Hanoi", "Mastermind", "Rock Paper Scissor", "Tic Tac Toe", "Exit" };
        private string menuType = "GAMES";
        private Display display;
        public ProfileController SelectGame(ProfileController profile, CheatController cheat)
        {
            ProfileController user = profile;
            CheatController activeCheats = cheat;
            string userRequest = "";
            while (userRequest != "Exit")
            {
                display = new Display();
                userRequest = display.getInput(games, menuType);
            }
            return user;
        }
    }
}