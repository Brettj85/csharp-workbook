using System;

using System.Text;

namespace gameboy
{
    class DisplayUtility
    {
        public static string ReturnLine(string formatMe)
        {
            char[] chars = new char[4] { '*', ' ', '~', '|' };
            if (formatMe == "~")
            {
                StringBuilder buildBorder = new StringBuilder();
                buildBorder.Append(chars[2], 25);
                return buildBorder.ToString();
            }
            else if (formatMe == "*")
            {
                StringBuilder buildBorder = new StringBuilder();
                buildBorder.Append(chars[0], 25);
                return buildBorder.ToString();
            }
            else if (formatMe.Substring(0, 1) == "|")
            {
                formatMe = formatMe.Substring(1);
                StringBuilder buildLine = new StringBuilder();
                int spaces = (((25 - formatMe.Length) / 2) - 1);
                buildLine.Append(chars[3]).Append(chars[1], spaces).Append(formatMe).Append(chars[1], spaces);
                while (buildLine.Length < 25)
                {
                    if (buildLine.Length == 24)
                    {
                        buildLine.Append(chars[3]);

                    }
                    else if (buildLine.Length < 24)
                    {
                        buildLine.Append(chars[1]);
                    }
                }
                return buildLine.ToString();
            }
            else
            {
                StringBuilder buildLine = new StringBuilder();
                int spaces = (((25 - formatMe.Length) / 2) - 1);
                buildLine.Append(chars[0]).Append(chars[1], spaces).Append(formatMe).Append(chars[1], spaces);
                while (buildLine.Length < 25)
                {
                    if (buildLine.Length == 24)
                    {
                        buildLine.Append(chars[0]);

                    }
                    else if (buildLine.Length < 24)
                    {
                        buildLine.Append(chars[1]);
                    }
                }
                return buildLine.ToString();
            }
        }
    }
}