using System;
using System.Collections.Generic;


namespace gameboy
{
    class ProfileController
    {
        public bool active { get; private set; } = false;//bypass profile with true
        private string firstName = "";
        private string lastName = "";
        private List<string> profileOptions = new List<string>() { "Game Stats", "Change Name", "Exit" };
        private string menuType = "PROFILE";
        private List<string> game = new List<string> { "Towers Of Hanoi", "Mastermind", "Tic Tac Toe", "Rock Paper Scissor" };
        private List<List<string>> labels = new List<List<string>>();
        private List<List<int>> scores = new List<List<int>>();

        public ProfileController()
        {
            for (int i = 0; i < game.Count; i++)
            {
                List<string> label = new List<string> { "Games Played", "wins", "Losses", "Times Cheated", "Best Score" };
                List<int> startScores = new List<int> { 0, 0, 0, 0, 0 };
                labels.Add(label);
                scores.Add(startScores);
            }
        }
        public void Create()
        {
            if (active)
            {
                firstName = "";
                lastName = "";
                do // until 1st and last have at least 1 char
                {
                    if (firstName == "")
                    {
                        Console.Write("Enter first name: ");
                        this.firstName = Console.ReadLine();
                    }
                    if (lastName == "")
                    {
                        Console.Write("Enter last name: ");
                        this.lastName = Console.ReadLine();
                    }
                    Console.Clear();
                } while (firstName == "" || lastName == "");

            }
            do // until 1st and last have at least 1 char
            {
                if (firstName == "")
                {
                    Console.Write("Enter first name: ");
                    this.firstName = Console.ReadLine();
                }
                if (lastName == "")
                {
                    Console.Write("Enter last name: ");
                    this.lastName = Console.ReadLine();
                }
                Console.Clear();
            } while (firstName == "" || lastName == "" && !active);
            this.active = true;//activate profile
        }
        private Display display;
        public void ProfileMenu()
        {
            string userRequest = "";
            while (userRequest != "Exit")
            {
                display = new Display();
                userRequest = display.getInput(profileOptions, menuType);
                if (userRequest == "Change Name")
                {
                    this.Create();
                }
                else if (userRequest == "Game Stats")
                {
                    TwoOptionMenu listStats = new TwoOptionMenu(game, labels, scores);
                    int index = 0;
                    while (true)
                    {
                        if (index > game.Count - 1)
                        {
                            index = 0;
                        }
                        else if (index == -1)
                        {
                            index = game.Count - 1;
                        }
                        string view = listStats.BuildDisplay(index);
                        if (view == "<- Back")
                        {
                            index--;
                        }
                        else if (view == "Next ->" && index <= game.Count)
                        {
                            index++;
                        }
                        else if (view == "Exit")
                        {
                            Console.Clear();
                            break;
                        }


                    }
                }
            }

        }
    }
}