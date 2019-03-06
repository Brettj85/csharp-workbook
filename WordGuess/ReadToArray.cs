using System;
using System.IO;

namespace WordGuess
{
    class ReadToArray
    {
        public string[] lines { get; set; } = null;
        public ReadToArray()
        {
            lines = File.ReadAllLines("AlphList.txt");
        }
    }
}