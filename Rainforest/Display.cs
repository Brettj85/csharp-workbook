using System;
using System.Collections.Generic;
using System.Text;

namespace Rainforest
{
    class Display
    {
        private static int index = 0;
        public string Run(List<string> menu)
        {
            Console.Clear();
            Console.CursorVisible = false;
            while (true)
            {
                List<string> menuItems = menu;
                string selectedMenuItem = drawMenu(menuItems);
                return selectedMenuItem;
            }
        }
        private static string drawMenu(List<string> items)
        {
            Console.WriteLine("*************************");
            for (int i = 0; i < items.Count; i++)
            {
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
            Console.WriteLine("*************************");
            string userInput = MenuController(items);
            return userInput;


        }
        private static string MenuController(List<string> items)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.DownArrow:
                    if (index == items.Count - 1)
                    {
                        index = 0;
                    }
                    else { index++; }

                    break;
                case ConsoleKey.UpArrow:
                    if (index <= 0)
                    {
                        index = items.Count - 1;
                    }
                    else { index--; }

                    break;
                case ConsoleKey.Enter:
                    return items[index];
                default:
                    return "";
            }

            Console.Clear();
            return "";
        }
        private static string ReturnLine(string formatMe)
        {
            StringBuilder buildLine = new StringBuilder();
            int spaces = (((25 - formatMe.Length) / 2) - 1);
            char[] chars = new char[2] { '*', ' ' };
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