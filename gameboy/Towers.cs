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
        public List<int> Blocks { get; private set; } = new List<int> { 3, 6, 9, 12 };
        public List<Stack<int>> Pegs { get; private set; } = new List<Stack<int>>();
        List<string> Board = new List<string>();
        public Towers(CheatController c)
        {
            StartingBlocks = c.ActiveCheats.Contains("Extra Blocks") ? 10 : 4;
            PegHight = StartingBlocks + 2;
            Stack<int> p1 = new Stack<int>();
            Pegs.Add(p1);
            Pegs.Add(p1);
            Pegs.Add(p1);
        }
        public int Play(CheatController c)
        {
            int result = 0;
            cheats = c;
            ConstructBlocks();
            while (true)
            {
                ConstructPegs();
                ConstructLines();
                //ChooseBlock();
                // ChoosePeg();
                // if (CheckWin())
                // {
                //     result = 1;
                //     break;
                // }
                Console.Write("Continue y/n: ");
                string input = Console.ReadLine();
                if (input != "y" || input != "Y")
                {
                    break;
                }
            }
            return result;
        }
        private void ConstructBlocks()
        {
            if (StartingBlocks > 4)
            {
                for (int i = 1; i == StartingBlocks - 4; i++)
                {
                    Blocks.Add(12 + (3 * i));
                }
            }
        }
        private void ConstructPegs()
        {
            int height = Blocks.Count + 2;
            foreach (var item in Blocks)
            {
                Pegs[0].Push(item);
            }
            Pegs[0].Push(0);
            Pegs[0].Push(0);
            for (int i = 0; i < height; i++)
            {
                Pegs[1].Push(0);
                Pegs[2].Push(0);
            }
        }
        private void ConstructLines()
        {
            int space = (StartingBlocks) * 2;
            Char[] buildElements = new Char[] { ' ', '[', ']', '|' };
            Stack<int> pegOne = Pegs[0];
            Stack<int> pegTwo = Pegs[1];
            Stack<int> pegThree = Pegs[2];
            for (int i = 0; i < PegHight; i++)
            {
                ;
            }


        }
    }
}
