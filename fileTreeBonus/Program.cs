using System;
using System.Collections.Generic;

namespace fileTreeBonus
{
    class Program
    {
        static void Main(string[] args)

        {
            string my_path = @"C:\Users\MyPIDHere\SomeFolder\SomeSubFolder\some_document.txt";
            var path_parts = my_path.Split(new char[] { '\\' });
            List<string> output_parts = new List<string>();
            for (int i = 0; i < path_parts.Length; i++)
            {
                string indent = new String(' ', i);
                string indentChar = "";
                if (i > 0)
                {
                    indentChar = indent + "└──";
                    indent = indent + indent;
                }
                output_parts.Add(String.Format("{0} {1} {2}", indent, indentChar, path_parts[i]));
            }
            string tree = String.Join("\n", output_parts);
            Console.Write(tree);
        }

    }
}
