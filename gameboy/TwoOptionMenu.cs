using System;
using System.Collections.Generic;


namespace gameboy
{
    class TwoOptionMenu
    {
        private int item = 0;
        private int index = 0;
        private List<string> options = new List<string>() { "<- Back", "Exit", "Next ->" };
        private List<string> game;
        private List<List<string>> labels;
        private List<List<int>> scores;

        public TwoOptionMenu(List<string> g, List<List<string>> l, List<List<int>> s)
        {
            this.game = g;
            this.labels = l;
            this.scores = s;
        }
        public string BuildDisplay(int indexOfGame)
        {
            this.item = indexOfGame;
            Console.Clear();
            List<string> userSelect = options;
            List<string> currentLabels = labels[item];
            List<int> currentscores = scores[item];
            string menuTitle = game[item];
            string getUserRequest = DrawDisplay(currentLabels, currentscores, menuTitle);
            return getUserRequest;
        }

        private string DrawDisplay(List<string> currentLabels, List<int> currentscores, string menuTitle)
        {
            GetLines get = new GetLines();

            get.Title(menuTitle);
            get.BuildData(currentLabels, currentscores);
            Console.WriteLine(get.BorderH("*"));

            string options = DrawOptions();
            return options;
        }
        private string DrawOptions()
        {
            GetLines choice = new GetLines();
            List<string> items = options;
            string buildBottem = choice.BorderH("*");

            Console.Write("*");
            for (int i = 0; i < items.Count; i++)
            {
                Console.CursorVisible = false;
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string buildLine = choice.MenuLine(items[i]);
                    Console.Write(buildLine);
                }
                else
                {
                    string buildLine = choice.MenuLine(items[i]);
                    Console.Write(buildLine);
                }
                Console.ResetColor();
            }
            Console.Write("*");
            Console.WriteLine();
            Console.WriteLine(buildBottem);
            string userInput = MenuController(items);
            return userInput;
        }
        private string MenuController(List<string> items)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (index == items.Count - 1)
                {
                    index = 0;
                }
                else { index++; }
            }
            else if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (index <= 0)
                {
                    index = items.Count - 1;
                }
                else { index--; }
            }
            else if (userInput.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }

    }
}