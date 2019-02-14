using System;
using System.Text;

namespace whiteboard
{
    class StringTransform
    {
        public virtual string reverseWord(string input)
        {
            if (input == null)
            {
                return null;
            }

            StringBuilder newString = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                newString.Append(input[i]);
            }
            return newString.ToString();
        }
    }
}