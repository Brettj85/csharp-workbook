using System;
using System.Text;

namespace whiteboard
{
    class Transform
    {
        public virtual string StringTransform(string input)
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