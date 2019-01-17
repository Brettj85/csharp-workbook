using System;

namespace PigLatin
{
    class Program
    {
        public static void Main()
        {
            // your code goes here
            Console.WriteLine("enter a word to translate ");
            string userInput = Console.ReadLine();
            string newWord = makeLowerCase(userInput);
            Console.WriteLine(newWord);

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }
        
        public static string TranslateWord(string word)
        {
            string firstLetter = word.Substring(0,1);
            string restWord = word.Substring(1);
            string translatedWord = (restWord + firstLetter + "ay");
            return translatedWord;
        }

        public static string TranslateWordVowel(string word)
        {
            // your code goes here
            int firstVowelIndex = word.IndexOfAny(new char[] {'a', 'e', 'i', 'o', 'u', 'y'});
            string firstPart = word.Substring(0, firstVowelIndex);
            string secondPart = word.Substring(firstVowelIndex);
            string translatedWord = (secondPart + firstPart + "ay");

            return translatedWord;
        }

        public static string startsWithVowel(string word)
        {
            // your code goes here
            int firstVowelIndex = word.IndexOfAny(new char[] {'a', 'e', 'i', 'o', 'u', 'y'});
            string last = word.Substring(0,1);
            string first = word.Substring(1);
            if (firstVowelIndex == 0)
            {

                string translatedWord = (last + first +"ay");

                return translatedWord;   
            }
            else
            {
                string notAVowel = (first + last + "ay");
                return notAVowel;
            }
            
        }
        public static string makeLowerCase(string word)
        {
            string convertLower = word.ToLower();
            string firstLetter = convertLower.Substring(0,1);
            string restWord = convertLower.Substring(1);
            string translatedWord = (restWord + firstLetter + "ay");
            return translatedWord;            
        }

        public static void filePath(string file)
        {
        string my_path = file;
        
		var path_parts = my_path.Split(new char[]{'\\'});
		List<string> output_parts = new List<string>();
		for (int i = 0; i < path_parts.Length; i++)
		{
			string indent = new String(' ', i);
			if (i > 0)
			{
				indent = indent + "|__";
			}

			output_parts.Add(String.Format("{0} {1}", indent, path_parts[i]));
		}

		string tree = String.Join("\n", output_parts);
		Console.Write(tree);
        }
    }
}
