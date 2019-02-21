using System;
using System.Threading;

namespace gameboy
{
    class StartGames
    {
        public ProfileController Game(string gameRequest, ProfileController profile, CheatController cheat)
        {
            switch (gameRequest)
            {
                case "Tic Tac Toe":
                    Console.Clear();
                    Console.WriteLine("feature coming soon. Check back shortly!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                case "Rock Paper Scissor":
                    Console.Clear();
                    Console.WriteLine("feature coming soon! Check back shortly!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
                case "Mastermind":
                    Mastermind masterMind = new Mastermind();
                    if (cheat.ActiveCheats.Contains("Immortality") || cheat.ActiveCheats.Contains("Not So Mastermind"))
                    {
                        profile.scores[1][3]++;
                    }
                    int Mresult = Mastermind.Play(cheat);
                    profile.scores[1][1] = Mresult == 1 ? profile.scores[1][1] + 1 : profile.scores[1][1];
                    profile.scores[1][2] = Mresult == 0 ? profile.scores[1][2] + 1 : profile.scores[1][2];
                    profile.scores[1][0] = profile.scores[1][0] + 1;
                    break;
                case "Towers Of Hanoi":
                    Towers towers = new Towers(cheat);
                    if (cheat.ActiveCheats.Contains("Immortality") || cheat.ActiveCheats.Contains("Not So Mastermind"))
                    {
                        profile.scores[1][3]++;
                    }
                    int TResult = towers.Play();
                    profile.scores[0][1] = TResult == 1 ? profile.scores[0][1] + 1 : profile.scores[0][1];
                    profile.scores[0][2] = TResult == 0 ? profile.scores[0][2] + 1 : profile.scores[0][2];
                    profile.scores[0][0] = profile.scores[0][0] + 1;
                    break;
            }
            return profile;
        }
    }
}