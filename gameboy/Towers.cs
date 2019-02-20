using System;
using System.Collections.Generic;
using System.Text;

namespace gameboy
{

    class Towers
    {
        public bool Block { get; private set; } = true;
        public static int StartingBlocks { get; private set; }
        public static int PegHight { get; private set; }
        public CheatController cheats { get; private set; }
        public List<int> Blocks { get; private set; } = new List<int>() { 4, 8, 12, 16 };
        public List<Stack<int>> Pegs { get; private set; } = new List<Stack<int>>();
        List<string> Board = new List<string>();
        public int index { get; private set; }
        public Towers(CheatController c)
        {
            //StartingBlocks = c.ActiveCheats.Contains("Extra Blocks") ? 10 : 4;
            //for (int i = 4; i == StartingBlocks; i++)
            //{
            //    Blocks.Add(12 + 4 * i);
            //}
            PegHight = StartingBlocks + 2;
            Blocks.Reverse();
            Stack<int> p1 = new Stack<int>();
            Stack<int> p2 = new Stack<int>();
            Stack<int> p3 = new Stack<int>();
            Pegs.Add(p1);
            Pegs.Add(p2);
            Pegs.Add(p3);
            ConstructPegs();
        }
        public int Play()
        {
            int result = 0;
            while (true)
            {
                ConstructBoard();
                int pullBlock = 0;
                string chosen = "";
                while (true)
                {
                    chosen = ChooseBlock();
                    int block = Convert.ToInt32(chosen.Replace(" ", String.Empty).Substring(0, 1));
                    int amount = 0;
                    while (Pegs[block].Peek() == 0 && Pegs[block].Count > 1)
                    {
                        Pegs[block].Pop();
                        amount++;
                    }
                    int currentBlock = Pegs[block].Peek();
                    if (currentBlock != 0)
                    {
                        pullBlock = Pegs[block].Pop();
                        Pegs[block].Push(0);
                        Pegs[block].Push(0);
                        break;
                    }
                    for (var j = amount; j == 0; j--)
                    {
                        Pegs[block].Push(0);
                    }
                }
                while (true)
                {
                    int tally = 0;
                    string toPeg = ChoosePeg();
                    int peg = Convert.ToInt32(toPeg.Replace(" ", String.Empty).Substring(0, 1));
                    while (Pegs[peg].Peek() == 0 && Pegs[peg].Count > 1)
                    {
                        Pegs[peg].Pop();
                        tally++;
                    }
                    int current = Pegs[peg].Peek();
                    if (chosen.Length < current)
                    {
                        Pegs[peg].Pop();
                        Pegs[peg].Push(pullBlock);
                        Pegs[peg].Push(0);
                        Pegs[peg].Push(0);
                        break;
                    }
                    for (var j = tally; j == 0; j--)
                    {
                        Pegs[peg].Push(0);
                    }
                }

                // if (CheckWin())
                // {
                //     result = 1;
                //     break;
                // }
                Console.Write("Quit? y/n: ");
                string input = Console.ReadLine();
                if (input != "y" || input != "Y")
                {
                    break;
                }
            }
            return result;
        }
        private void ConstructPegs()
        {
            int height = Blocks.Count + 2;
            foreach (var item in Blocks)
            {
                Pegs[0].Push(item);
                Pegs[1].Push(0);
                Pegs[2].Push(0);
            }
            for (int i = 0; i < 2; i++)
            {
                Pegs[0].Push(0);
                Pegs[1].Push(0);
                Pegs[2].Push(0);
            }
        }
        private void ConstructBoard()
        {
            int space = (StartingBlocks) * 2;
            Stack<int> pegOne = Pegs[0];
            Stack<int> pegTwo = Pegs[1];
            Stack<int> pegThree = Pegs[2];

            List<string> stackOne = buildLines(pegOne);
            List<string> stackTwo = buildLines(pegTwo);
            List<string> stackThree = buildLines(pegThree);

            for (int i = 0; i < stackOne.Count; i++)
            {
                Console.WriteLine(stackOne[i] + stackTwo[i] + stackThree[i]);
            }
        }
        private List<string> buildLines(Stack<int> peg)
        {

            List<string> stack = new List<string>();
            Char[] buildElements = new Char[] { ' ', '[', ']', '|' };
            int spaces = (Blocks.Count * 4);
            foreach (var block in peg)
            {
                StringBuilder buildString = new StringBuilder();
                buildString.Append(buildElements[0]);
                if (block == 0)
                {
                    buildString.Append(buildElements[0], spaces / 2).Append(buildElements[1]).Append(buildElements[2]).Append(buildElements[0], spaces / 2);
                }
                else
                {
                    int item = block;
                    int front = (spaces - item) / 2;
                    buildString.Append(buildElements[0], front).Append(buildElements[1]).Append(buildElements[3], item).Append(buildElements[2]).Append(buildElements[0], front);
                }
                buildString.Append(buildElements[0], 2);
                stack.Add(buildString.ToString());
            }

            return stack;
        }
        private string ChooseBlock()
        {
            index = 0;
            int spaces = (Blocks.Count * 4);
            Char[] MenuElements = new Char[] { ' ', '/', '\\' };
            List<string> options = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                StringBuilder menuOption = new StringBuilder();
                menuOption.Append(MenuElements[0], spaces / 2 - 1).Append(i).Append(MenuElements[1]).Append(MenuElements[2]).Append(MenuElements[0], 1).Append(MenuElements[0], spaces / 2 - 1);
                options.Add(menuOption.ToString());
            }
            string response = "";

            while (response == "")
            {
                Console.Clear();
                ConstructBoard();
                response = DrawOptions(options);
            }
            return response;
        }
        private string ChoosePeg()
        {
            index = 0;
            int spaces = (Blocks.Count * 4);
            Char[] MenuElements = new Char[] { ' ', '/', '\\' };
            List<string> options = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                StringBuilder menuOption = new StringBuilder();
                menuOption.Append(MenuElements[0], spaces / 2 - 1).Append(i).Append(MenuElements[1]).Append(MenuElements[2]).Append(MenuElements[0], 1).Append(MenuElements[0], spaces / 2 - 1);
                options.Add(menuOption.ToString());
            }
            string response = "";

            while (response == "")
            {
                Console.Clear();
                ConstructBoard();
                response = DrawOptions(options);
            }
            return response;
        }
        private string DrawOptions(List<string> options)
        {
            StringBuilder line = new StringBuilder();
            List<string> items = options;

            int spaces = (Blocks.Count * 4);
            Console.Write(" ");
            for (int i = 0; i < items.Count; i++)
            {
                Console.CursorVisible = false;
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    string buildLine = items[i];
                    Console.Write(buildLine);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    string buildLine = items[i];
                    Console.Write(buildLine);
                }
                Console.ResetColor();
                Console.Write("   ");
            }
            Console.Write("   ");
            Console.WriteLine();
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
            return "";
        }
    }
}

