using System;
using System.Text;

namespace whiteboard
{
    class Uppercase : StringTransform
    {
        public override string reverseWord(string input)
        {
            if (input == null)
            {
                return null;
            }

            StringBuilder newString = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                newString.Append(input[i].ToString().ToUpper());
            }
            return newString.ToString();
        }
    }
}