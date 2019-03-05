using System;
using System.Collections.Generic;
using System.Text;

namespace NewCheckers
{
    public class Display
    {
        public Dictionary<Coordinates, string> pieces { get; set; }
        private int index = 0;
        public Display(Dictionary<Coordinates, Checker> board)
        {
            pieces = new Dictionary<Coordinates, string>();
            Coordinates cord;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cord = new Coordinates(i, j);
                    Checker c;
                    if (board.TryGetValue(cord, out c))
                    {
                        if (c != null)
                        {
                            this.pieces.Add(cord, c.Color);
                        }
                    }
                    else
                    {
                        this.pieces.Add(cord, " ");
                    }
                }
            }
        }
        public int ChooseX(int player)//ChooseX
        {
            Console.Clear();
            Coordinates cord;
            string returnMe = "";
            Console.CursorVisible = false;
            while (returnMe == "")
            {
                Console.WriteLine("Player " + player + " Choose A Row.");
                Console.WriteLine();
                for (int i = 0; i < 8; i++)
                {
                    if (index == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i);
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(i);
                        Console.Write(" ");
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        cord = new Coordinates(i, j);
                        if (i == 0 || i % 2 == 0)
                        {
                            if (j == 0 || j % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        else
                        {
                            if (j == 0 || j % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                        }
                        string value = "";
                        if (pieces.TryGetValue(cord, out value))
                        {
                            Console.OutputEncoding = System.Text.Encoding.UTF8;
                            Console.Write(" ");
                            if (value == char.ConvertFromUtf32(int.Parse("25CE", System.Globalization.NumberStyles.HexNumber)))
                            {
                                value = char.ConvertFromUtf32(int.Parse("25CF", System.Globalization.NumberStyles.HexNumber));
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(value);
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(value);
                                Console.Write(" ");
                            }
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                List<string> items = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7" };
                returnMe = MenuControllerX(items);
            }
            index = 0;
            return Convert.ToInt32(returnMe);
        }
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
        public int ChooseY(int player, int x)//PickY
        {
            Console.Clear();
            Coordinates cord;
            string returnMe = "";
            Console.CursorVisible = false;
            while (returnMe == "")
            {
                Console.WriteLine("Player " + player + " Choose A Row.");
                Console.WriteLine();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        cord = new Coordinates(i, j);

                        if (i == 0 || i % 2 == 0)
                        {
                            if (j == 0 || j % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            if (i == x && j == index)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                        }
                        else
                        {
                            if (j == 0 || j % 2 == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }
                            if (i == x && j == index)
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                            }
                        }
                        string value = "";
                        if (pieces.TryGetValue(cord, out value))
                        {
                            Console.OutputEncoding = System.Text.Encoding.UTF8;
                            Console.Write(" ");
                            if (value == char.ConvertFromUtf32(int.Parse("25CE", System.Globalization.NumberStyles.HexNumber)))
                            {
                                value = char.ConvertFromUtf32(int.Parse("25CF", System.Globalization.NumberStyles.HexNumber));
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(value);
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(value);
                                Console.Write(" ");
                            }
                        }
                        else
                        {
                            Console.Write("   ");
                        }
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                List<string> items = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7" };
                for (int i = 0; i < items.Count; i++)
                {
                    if (index == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                        Console.Write(items[i]);
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.Write(items[i]);
                        Console.Write(" ");
                    }
                }
                returnMe = MenuControllerY(items);
            }
            return Convert.ToInt32(returnMe);
        }
        private string MenuControllerY(List<string> items)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.RightArrow)
            {
                index = index == items.Count - 1 ? 0 : index + 1;
            }
            else if (userInput.Key == ConsoleKey.LeftArrow)
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
