using System;

namespace whiteboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Transform Reverse = new Transform();
            Uppercase makeUpper = new Uppercase();
            LowerCase makeLower = new LowerCase();
            Console.WriteLine("Enter a word.");
            string request = Console.ReadLine();
            string newWord = Reverse.StringTransform(request);
            Console.WriteLine("your word backwards is: {0}", newWord);
            newWord = makeUpper.StringTransform(request);
            Console.WriteLine("your word uppercase is: {0}", newWord);

            Transform[] arrTransform = new Transform[]
            {
                makeUpper,
                makeLower
            };
            foreach (var item in arrTransform)
            {
                string value = item.StringTransform("ThisString");
                Console.WriteLine(value);
            }
        }
    }
}
