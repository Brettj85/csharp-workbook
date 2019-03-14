using System;
using System.Collections.Generic;

namespace ToDoApp
{
    internal class DisplayController
    {
        private int index = 0
        private string MenuControllerX(List<string> items)
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
    }
}