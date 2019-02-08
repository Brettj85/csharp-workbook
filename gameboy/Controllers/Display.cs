using System;
using System.Collections.Generic;
using System.Text;

namespace gameboy
{
    class Display
    {
        private static int index = 0;
        private string title;

        public Display()
        {
            index = 0;
        }
        public string getInput(List<string> items, string menuTitle)
        {
            title = menuTitle;

            while (true)
            {
                string selectedMenuItem = drawMenu(items);
                foreach (var item in items)
                {
                    if (selectedMenuItem == item)
                    {
                        Console.Clear();
                        return item;
                    }
                }
            }
        }
        public void ShowData(List<string> items, string menuTitle)
        {
            title = menuTitle;
            string done = drawData(items);
            if (done == "Exit")
            {
                Console.Clear();
            }
        }
        private string drawMenu(List<string> items)
        {
            string buildTitle = ReturnLine(title);
            string buildBorder = ReturnLine("*");
            Console.WriteLine(buildBorder);
            Console.WriteLine(buildTitle);
            Console.WriteLine(buildBorder);

            for (int i = 0; i < items.Count; i++)
            {
                Console.CursorVisible = false;
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string buildLine = ReturnLine(items[i]);
                    Console.WriteLine(buildLine);
                }
                else
                {
                    string buildLine = ReturnLine(items[i]);
                    Console.WriteLine(buildLine);
                }
                Console.ResetColor();
            }
            Console.WriteLine(buildBorder);
            string userInput = MenuController(items);
            return userInput;
        }
        private string drawExit(List<string> items)
        {
            string buildBorder = ReturnLine("*");
            for (int i = 0; i < items.Count; i++)
            {
                Console.CursorVisible = false;
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string buildLine = ReturnLine(items[i]);
                    Console.WriteLine(buildLine);
                }
                else
                {
                    string buildLine = ReturnLine(items[i]);
                    Console.WriteLine(buildLine);
                }
                Console.ResetColor();
            }
            Console.WriteLine(buildBorder);
            string userInput = MenuController(items);
            return userInput;
        }
        private string drawData(List<string> items)
        {
            string buildTitle = ReturnLine(title);
            string buildBorder = ReturnLine("*");
            Console.WriteLine(buildBorder);
            Console.WriteLine(buildTitle);
            Console.WriteLine(buildBorder);

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(ReturnLine(items[i]));
            }
            Console.WriteLine(buildBorder);

            List<string> exit = new List<string>() { "Exit" };
            string userInput = drawExit(exit);
            return userInput;

        }
        private string MenuController(List<string> items)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                    index = 0;
                }
                else { index++; }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
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
        private string ReturnLine(string formatMe)
        {
            char[] chars = new char[3] { '|', ' ', '~' };
            if (formatMe == "*")
            {
                StringBuilder buildBorder = new StringBuilder();
                buildBorder.Append(chars[2], 25);
                return buildBorder.ToString();
            }
            else
            {
                StringBuilder buildLine = new StringBuilder();
                int spaces = (((25 - formatMe.Length) / 2) - 1);
                buildLine.Append(chars[0]).Append(chars[1], spaces).Append(formatMe).Append(chars[1], spaces);
                while (buildLine.Length < 25)
                {
                    if (buildLine.Length == 24)
                    {
                        buildLine.Append(chars[0]);

                    }
                    else if (buildLine.Length < 24)
                    {
                        buildLine.Append(chars[1]);
                    }
                }
                return buildLine.ToString();
            }
        }
    }
}