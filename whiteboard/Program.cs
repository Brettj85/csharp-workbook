using System;

namespace whiteboard
{
    class Program
    {
        static void Main(string[] args)
        {
            StringTransform Reverse = new StringTransform();
            Uppercase makeUpper = new Uppercase();
            Console.WriteLine("Enter a word.");
            string request = Console.ReadLine();
            string newWord = Reverse.reverseWord(request);
            Console.WriteLine("your word backwards is: {0}", newWord);
            newWord = makeUpper.reverseWord(request);
            Console.WriteLine("your word backwards is: {0}", newWord);
        }
    }
}
