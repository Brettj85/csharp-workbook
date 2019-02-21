using System;
using System.Collections.Generic;


namespace whiteboard20th
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (input == "")
            {
                input = Console.ReadLine();
            }
            Console.WriteLine(UniqueChar.IsUnique(input) ? "All letters are unique" : "there are duplicate letters in that string");
        }
    }
    public class UniqueChar
    {
        public static bool IsUnique(string word)
        {
            bool returnMe;
            foreach (var letter in word)
            {
                char temp = letter;
                bool result = false;
                foreach (var item in word)
                {
                    result = temp == item ? true : false;
                }
                if (result) { returnMe = true; }
            }
            return returnMe;
        }
    }
}
