using System;
using System.Collections.Generic;

namespace ToDoApp
{
    internal class DisplayController
    {
        private int index = 0;

        public DisplayController(int indexStart)
        {
            index = indexStart;
        }

        public string MenuController(List<string> items)
        {
            //return menu item or current index
            ConsoleKeyInfo userInput = Console.ReadKey();
            string returnMe = "";
            if (userInput.Key == ConsoleKey.DownArrow)
            {
                index = index == items.Count - 1 ? 0 : index + 1;
                returnMe = index.ToString();
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                index = index <= 0 ? items.Count - 1 : index - 1;
                returnMe = index.ToString();
            }
            else if (userInput.Key == ConsoleKey.Enter)
            {
                returnMe = items[index];
            }
            Console.Clear();
            return returnMe;
        }

    }
}