using System;

namespace gameboy
{
    class ConstructConsoleLine
    {
        public string ReturnLine(string formatMe, bool isBorder, int length, char borderType)
        {
            char space = new char { " " };
            int whiteSpace = length - formatMe.Length;
            StringBuilder buildLine = new StringBuilder();
            buildLine.Append(borderType);
            buildLine.Append
            (
                isBorder ? buildLine.Append(borderType, length) : buildLine.Append(space, whiteSpace).Append(formatMe).Append(space, whiteSpace)
            );
            buildLine.Append(borderType);
            return buildLine.ToString();
        }
    }
}
