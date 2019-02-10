using System;
using System.Collections.Generic;
using System.Text;

namespace gameboy
{
    class GetLines
    {
        //private int item = 0;
        public char[] chars = new char[5] { '*', '~', '_', ' ', '|' };
        public string BorderH(string borderStyle)
        {
            int request;
            if (borderStyle == "*")
            {
                request = 0;
            }
            else if (borderStyle == "~")
            {
                request = 1;
            }
            else
            {
                request = 2;
            }
            StringBuilder border = new StringBuilder();
            border.Append(chars[request], 40);
            return border.ToString();
        }
        public void Title(string title)
        {
            Console.WriteLine(BorderH("*"));
            Console.WriteLine(Line(title));
            Console.WriteLine(BorderH("*"));
        }
        public string Line(string item)
        {
            StringBuilder builtString = new StringBuilder();
            int space = (38 - item.Length) / 2;
            builtString.Append(chars[0]).Append(chars[3], space).Append(item).Append(chars[3], space);
            while (builtString.ToString().Length != 39)
            {
                builtString.Append(chars[3]);
            }
            builtString.Append(chars[0]);
            return builtString.ToString();
        }
        public string MenuLine(string item)
        {
            StringBuilder builtString = new StringBuilder();
            int space = (13 - item.Length) / 2;
            builtString.Append(chars[3], space).Append(item).Append(chars[3], space);
            return builtString.ToString();
        }
        public void BuildData(List<string> label, List<int> scores)
        {
            List<string> cList = new List<string>();
            for (int i = 0; i < label.Count; i++)
            {
                cList.Add(label[i] + ": " + scores[i].ToString());
            }
            List<string> returnMe = new List<string>();
            List<string> lessThan11 = new List<string>();
            List<string> lessThan17 = new List<string>();
            List<string> large = new List<string>();
            foreach (var item in cList)
            {
                if (item.Length <= 11)
                {
                    lessThan11.Add(item);
                }
                else if (item.Length <= 17)
                {
                    lessThan17.Add(item);
                }
                else
                {
                    large.Add(item);
                }
            }
            foreach (var item in large)
            {
                Console.WriteLine(Line(item));
            }
            do
            {
                if (lessThan17.Count > 2)
                {
                    StringBuilder nextLine = new StringBuilder();
                    string first = lessThan17[0];
                    string second = lessThan17[1];
                    lessThan17.RemoveRange(0, 2);
                    int space = 36 - (first.Length + second.Length);
                    nextLine.Append(chars[0]).Append(chars[3]).Append(first).Append(chars[3], space).Append(second).Append(chars[3]).Append(chars[0]);
                    Console.WriteLine(nextLine.ToString());
                }
                else if (lessThan17.Count > 0)
                {
                    if (lessThan11.Count > 0)
                    {
                        lessThan17.Add(lessThan11[0]);
                        lessThan11.RemoveRange(0, 1);
                        StringBuilder nextLine = new StringBuilder();
                        string first = lessThan17[0];
                        string second = lessThan17[1];
                        lessThan17.RemoveRange(0, 2);
                        int space = 36 - (first.Length + second.Length);
                        nextLine.Append(chars[0]).Append(chars[3]).Append(first).Append(chars[3], space).Append(second).Append(chars[3]).Append(chars[0]);
                        Console.WriteLine(nextLine.ToString());
                    }
                    else
                    {
                        StringBuilder nextLine = new StringBuilder();
                        int space = ((36 - lessThan17[0].Length) / 2);
                        nextLine.Append(chars[0]).Append(chars[3]).Append(lessThan17[0]).Append(chars[3], space).Append(chars[3]).Append(chars[0]);
                        lessThan17.RemoveRange(0, 1);
                    }
                }
                else
                {
                    break;
                }

            } while (true);
            do
            {
                if (lessThan11.Count >= 3)
                {
                    StringBuilder nextLine = new StringBuilder();
                    string first = lessThan11[0];
                    string second = lessThan11[1];
                    string third = lessThan11[2];
                    lessThan11.RemoveRange(0, 3);
                    int space = ((36 - (first.Length + second.Length + third.Length)) / 2);
                    nextLine.Append(chars[0]).Append(chars[3]).Append(first).Append(chars[3], space).Append(second).Append(chars[3]).Append(chars[3], space).Append(third).Append(chars[3]).Append(chars[0]);
                    Console.WriteLine(nextLine.ToString());
                }
                else if (lessThan11.Count > 0)
                {
                    if (lessThan11.Count > 1 && lessThan11.Count > 3)
                    {
                        StringBuilder nextLine = new StringBuilder();
                        string first = lessThan11[0];
                        string second = lessThan11[1];
                        lessThan11.RemoveRange(0, 2);
                        int space = ((36 - (first.Length + second.Length)));
                        nextLine.Append(chars[0]).Append(chars[3]).Append(first).Append(chars[3], space).Append(second).Append(chars[3]).Append(chars[0]);
                        Console.WriteLine(nextLine.ToString());
                    }
                    else if (lessThan11.Count > 0)
                    {

                        StringBuilder nextLine = new StringBuilder();
                        int space = ((36 - lessThan11[0].Length));
                        nextLine.Append(chars[0]).Append(chars[3]).Append(lessThan11[0]).Append(chars[3], space).Append(chars[3]).Append(chars[0]);
                        lessThan11.RemoveRange(0, 1);
                        Console.WriteLine(nextLine.ToString());
                    }
                }
                else
                {
                    break;
                }

            } while (true);

        }
    }
}