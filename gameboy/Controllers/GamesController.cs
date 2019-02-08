using System;
using System.Collections.Generic;
using System.Threading;

namespace gameboy
{
    class GamesController
    {
        private List<string> games = new List<string>() { "Towers Of Hanoi", "Mastermind", "Rock Paper Scissor", "Tic Tac Toe", "Exit" };
        Display display = new Display();
        public ProfileController SelectGame(ProfileController profile, CheatController cheat)
        {
            ProfileController user = profile;
            string userRequest = display.getInput(games);
            return user;
        }
    }
}