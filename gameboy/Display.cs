using System;
using System.Collections.Generic;

namespace gameboy
{
    class Display
    {
        private static int index;
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
            string buildTitle = DisplayUtility.ReturnLine(title);
            string buildBorder = DisplayUtility.ReturnLine("~");
            string buildBottom = DisplayUtility.ReturnLine("*");

            Console.WriteLine(buildBorder);
            Console.WriteLine(buildTitle);
            Console.WriteLine(buildBottom);

            for (int i = 0; i < items.Count; i++)
            {
                Console.CursorVisible = false;
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string buildLine = DisplayUtility.ReturnLine(items[i]);
                    Console.WriteLine(buildLine);
                }
                else
                {
                    string buildLine = DisplayUtility.ReturnLine("|" + items[i]);
                    Console.WriteLine(buildLine);
                }
                Console.ResetColor();
            }
            Console.WriteLine(buildBottom);
            string userInput = MenuController(items);
            return userInput;
        }
        private string drawExit(List<string> items)
        {
            string buildBottem = DisplayUtility.ReturnLine("~");
            for (int i = 0; i < items.Count; i++)
            {
                Console.CursorVisible = false;
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string buildLine = DisplayUtility.ReturnLine(items[i]);
                    Console.WriteLine(buildLine);
                }
                else
                {
                    string buildLine = DisplayUtility.ReturnLine(items[i]);
                    Console.WriteLine(buildLine);
                }
                Console.ResetColor();
            }
            Console.WriteLine(buildBottem);
            string userInput = quitController(items);
            return userInput;
        }
        private string drawData(List<string> items)
        {
            string buildTitle = DisplayUtility.ReturnLine(title);
            string buildBorder = DisplayUtility.ReturnLine("~");
            string buildBottom = DisplayUtility.ReturnLine("*");
            string buildBlank = DisplayUtility.ReturnLine("| ");
            Console.WriteLine(buildBorder);
            Console.WriteLine(buildTitle);
            Console.WriteLine(buildBottom);
            Console.WriteLine(buildBlank);


            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(DisplayUtility.ReturnLine("|" + items[i]));
            }

            Console.WriteLine(buildBlank);
            Console.WriteLine(buildBottom);


            List<string> exit = new List<string>() { "Exit" };
            string userInput = drawExit(exit);
            return userInput;

        }

        private string MenuController(List<string> items)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.DownArrow)
            {
                index = index == items.Count - 1 ? 0 : index + 1;
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                index = index <= 0 ? items.Count - 1 : index - 1;
            }
            else if (userInput.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            Console.Clear();
            return "";
        }
        private string quitController(List<string> items)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            while (userInput.Key != ConsoleKey.Enter)
            {
                userInput = Console.ReadKey();
                if (userInput.Key == ConsoleKey.Enter)
                {
                    return items[index];
                }
            }
            Console.Clear();
            return "";
        }

    }
}