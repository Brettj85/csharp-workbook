using System;
using System.Collections.Generic;
using System.Threading;
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
            StartingBlocks = c.ActiveCheats.Contains("Extra Blocks") ? 10 : 4;
            if (StartingBlocks > 4)
            {
                Blocks.RemoveRange(0, Blocks.Count);
                for (int i = 0; i < StartingBlocks; i++)
                {
                    Blocks.Add(4 * i);
                }
            }
            PegHight = Blocks.Count + 2;
            Blocks.Reverse();
            Stack<int> p1 = new Stack<int>();
            Stack<int> p2 = new Stack<int>();
            Stack<int> p3 = new Stack<int>();
            Pegs.Add(p1);
            Pegs.Add(p2);
            Pegs.Add(p3);
            foreach (var item in Blocks)
            {
                Pegs[0].Push(item);
            }
            ConstructPegs();
        }
        public int Play()
        {
            int result = 0;
            while (true)
            {
                int requestedBlock = 0;
                int from = 0;
                while (true)
                {
                    string unformatedChoice = Choice();
                    from = Convert.ToInt32(unformatedChoice.Replace(" ", String.Empty).Substring(0, 1));
                    ClearPegs();
                    if (Pegs[from].Count != 0)
                    {
                        requestedBlock = Pegs[from].Pop();
                        break;
                    }
                }
                while (true)
                {
                    string unformattedPeg = Choice();
                    int formatPeg = Convert.ToInt32(unformattedPeg.Replace(" ", String.Empty).Substring(0, 1));
                    ClearPegs();
                    if (Pegs[formatPeg].Count == 0 || Pegs[formatPeg].Peek() > requestedBlock)
                    {
                        Pegs[formatPeg].Push(requestedBlock);
                        break;
                    }
                    else
                    {
                        Pegs[from].Push(requestedBlock);
                        break;
                    }
                }
                ConstructPegs();
                if (CheckWin())
                {
                    Console.Clear();
                    Console.WriteLine("You have Won!");
                    Thread.Sleep(1500);
                    result = 1;
                    Console.Clear();
                    break;
                }
            }
            return result;
        }
        public void ClearPegs()
        {
            Stack<int> peg = Pegs[0];
            for (var i = 0; i < PegHight; i++)
            {
                if (peg.Peek() == 0)
                {
                    peg.Pop();
                }
            }
            peg = Pegs[1];
            for (var i = 0; i < PegHight; i++)
            {
                if (peg.Peek() == 0)
                {
                    peg.Pop();
                }
            }
            peg = Pegs[2];
            for (var i = 0; i < PegHight; i++)
            {
                if (peg.Peek() == 0)
                {
                    peg.Pop();
                }
            }
        }
        private void ConstructPegs()
        {
            while (Pegs[0].Count < PegHight)
            {
                Pegs[0].Push(0);
            }
            while (Pegs[1].Count < PegHight)
            {
                Pegs[1].Push(0);
            }
            while (Pegs[2].Count < PegHight)
            {
                Pegs[2].Push(0);
            }
        }
        private void ConstructBoard()
        {
            ConstructPegs();

            List<string> stackOne = buildLines(Pegs[0]);
            List<string> stackTwo = buildLines(Pegs[1]);
            List<string> stackThree = buildLines(Pegs[2]);

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
        private string Choice()
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
                ConstructBoard();
                response = DrawOptions(options);
                Console.Clear();
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
        public bool CheckWin()
        {
            ClearPegs();
            bool win = false;
            if (Pegs[1].Count == PegHight - 2 || Pegs[2].Count == PegHight - 2)
            {
                win = true;
            }
            return win;
        }
    }
}

