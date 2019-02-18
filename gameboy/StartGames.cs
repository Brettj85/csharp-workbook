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
                    Mastermind game = new Mastermind();
                    if (cheat.ActiveCheats.Contains("Immortality") || cheat.ActiveCheats.Contains("Not So Mastermind"))
                    {
                        profile.scores[1][3]++;
                    }
                    int result = Mastermind.Play(cheat);
                    profile.scores[1][1] = result == 1 ? profile.scores[1][1] + 1 : profile.scores[1][1];
                    profile.scores[1][2] = result == 0 ? profile.scores[1][2] + 1 : profile.scores[1][2];
                    profile.scores[1][0] = profile.scores[1][0] + 1;
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