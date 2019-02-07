using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu
{
    class Program
    {
        private static int index = 0;

        private static void Main(string[] args)
        {
            Console.Clear();
            List<string> menuItems = new List<string>() {
                "Mastermind",
                "Towers of Hanoi",
                "Cheat",
                "Stats",
                "Exit"
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = drawMenu(menuItems);
                if (selectedMenuItem == "Mastermind")
                {
                    Console.Clear();
                }
                else if (selectedMenuItem == "Towers of Hanoi")
                {
                    Console.Clear();
                }
                else if (selectedMenuItem == "Cheat")
                {
                    Console.Clear();
                }
                else if (selectedMenuItem == "Stats")
                {
                    Console.Clear();
                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
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

                    StringBuilder buildLine = new StringBuilder();
                    int spaces = (((25 - items[i].Length) / 2) - 1);
                    char[] chars = new char[4];
                    chars[0] = '*';
                    chars[1] = ' ';
                    buildLine.Append(chars[0]).Append(chars[1], spaces).Append(items[i]).Append(chars[0], spaces).Append(chars[0]);
                    Console.WriteLine(buildLine);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }
            Console.WriteLine("*************************");

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
    }
}