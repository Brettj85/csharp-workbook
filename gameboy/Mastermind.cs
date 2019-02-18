using System;
using System.Collections.Generic;
using System.Threading;

namespace gameboy
{
    class Mastermind
    {
        public static int Play(CheatController cheats)
        {
            int totalTurns = 10;
            foreach (var item in cheats.ActiveCheats)
            {
                totalTurns = item == "Immortality" ? -1 : totalTurns;
            }
            Console.Clear();
            Game game = new Game(GenerateSolution(cheats));
            int TurnsRemaining = 0;

            for (int turns = totalTurns; turns != 0; turns--)
            {
                string turnsLeft = turns.ToString();
                turnsLeft = turns < 0 ? "Unlimited" : turnsLeft;
                Console.WriteLine($"You have {turnsLeft} tries left");
                string letters = "";
                while (letters.Length != 4)
                {
                    Console.WriteLine("Choose four letters: ");
                    letters = Console.ReadLine();
                }

                Ball[] balls = new Ball[4];
                for (int i = 0; i < 4; i++)
                {
                    balls[i] = new Ball(letters[i].ToString());
                }
                Row row = new Row(balls);
                string winningString = "";
                foreach (var item in game.answer)
                {
                    winningString = winningString + item;
                }
                if (letters == winningString)
                {
                    Console.Clear();
                    Console.WriteLine("You Win");
                    Thread.Sleep(1000);
                    TurnsRemaining = turns;
                    break;
                }
                game.AddRow(row);
                Console.WriteLine(game.Rows);

            }
            Console.WriteLine(TurnsRemaining != 0 ? "Great Job" : "Out Of Turns");
            return TurnsRemaining != 0 ? 1 : 0;
        }
        public static string[] GenerateSolution(CheatController cheats)
        {
            Random rnd = new Random();
            List<string> available = new List<string> { "a", "b", "c", "d", "e", "f" };
            string[] solution = new string[4];
            int one = rnd.Next(1, 6);
            solution[0] = available[one];
            available.RemoveRange(one, 1);
            int two = rnd.Next(1, 5);
            solution[1] = available[two];
            available.RemoveRange(two, 1);
            int three = rnd.Next(1, 4);
            solution[2] = available[three];
            available.RemoveRange(three, 1);
            int four = rnd.Next(1, 3);
            solution[3] = available[four];
            available.RemoveRange(four, 1);
            bool preview = false;
            foreach (var item in cheats.ActiveCheats)
            {
                preview = item == "Not So Mastermind" ? true : preview;
            }
            if (preview)
            {
                Console.WriteLine(solution[0] + solution[1] + solution[2] + solution[3]);
            }
            return solution;
        }
    }

    class Game
    {
        private List<Row> rows = new List<Row>();
        public string[] answer { get; private set; } = new string[4];

        public Game(string[] answer)
        {
            this.answer = answer;
        }

        private string Score(Row row)
        {
            string[] answerClone = (string[])this.answer.Clone();
            int red = 0;
            for (int i = 0; i < 4; i++)
            {
                if (answerClone[i] == row.balls[i].Letter)
                {
                    red++;
                }
            }

            int white = 0;
            for (int i = 0; i < 4; i++)
            {
                int foundIndex = Array.IndexOf(answerClone, row.balls[i].Letter);
                if (foundIndex > -1)
                {
                    white++;
                    answerClone[foundIndex] = null;
                }
            }
            return $" {red} - {white - red}";
        }

        public void AddRow(Row row)
        {
            this.rows.Add(row);
        }

        public string Rows
        {
            get
            {

                foreach (var row in this.rows)
                {
                    Console.Write(row.Balls);
                    Console.WriteLine(Score(row));
                }
                return "";
            }
        }
    }

    class Ball
    {
        public string Letter { get; private set; }

        public Ball(string letter)
        {
            this.Letter = letter;
        }
    }

    class Row
    {
        public Ball[] balls = new Ball[4];

        public Row(Ball[] balls)
        {
            this.balls = balls;
        }

        public string Balls
        {
            get
            {
                foreach (var ball in this.balls)
                {
                    Console.Write(ball.Letter);
                }
                return "";
            }
        }
    }
}