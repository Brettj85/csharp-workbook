using System;

namespace gameboy
{
    class StartGames
    {
        public ProfileController Game(string gameRequest, ProfileController profile, CheatController cheat)
        {
            switch (gameRequest)
            {
                case "Tic Tac Toe":
                    //TicTacToe TTT = new TicTacToe(profile, cheat);
                    //profile = TTT.Run();
                    break;
                case "Rock Paper Scissor":
                    //RockPaperScissor RPC = new RockPaperScissor(profile, cheat);
                    //profile = RockPaperScissor.Run();
                    break;
                case "Mastermind":
                    Mastermind mastermind = new Mastermind(profile, cheat);
                    profile = mastermind.Run();
                    break;
                case "Towers Of Hanoi":
                    //TowersOfHanoi towersOfHanoi = new TowersOfHanoi(profile, cheat);
                    //profile = towersOfHanoi.Run();
                    break;
            }
            return profile;
        }
    }
}