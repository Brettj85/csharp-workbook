using System;
using System.Collections.Generic;


namespace gameboy
{
    class GamesController
    {
        private List<string> games = new List<string>() { "Towers Of Hanoi", "Mastermind" };
        private string menuType = "GAMES";
        private Display display;
        public ProfileController SelectGame(ProfileController profile, CheatController cheat)
        {
            ProfileController user = profile;
            List<string> activeCheats = cheat.ActiveCheats;
            foreach (var item in activeCheats)
            {
                if (item == "Unlocked R.P.C" || item == "Unlocked T.T.T")
                {
                    games.Add(item == "Unlocked R.P.C" ? "Rock Paper Scissor" : "Tic Tac Toe");
                }
            }
            games.Add("Exit");
            string userRequest = "";
            while (userRequest != "Exit")
            {
                display = new Display();
                userRequest = display.getInput(games, menuType);
                StartGames start = new StartGames();
                user = start.Game(userRequest, profile, cheat);
            }
            foreach (var item in activeCheats)
            {
                if (item == "Unlocked R.P.C" || item == "Unlocked T.T.T")
                {
                    games.Remove(item == "Unlocked R.P.C" ? "Rock Paper Scissor" : "Tic Tac Toe");
                }
            }
            games.Remove("Exit");

            return user;
        }
    }
}