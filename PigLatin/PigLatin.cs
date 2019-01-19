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
            string newWord = TranslateWord(userInput);
            string VowelNewWord = TranslateWordVowel(userInput);
            string startsWithVowelNewWord = startsWithVowel(userInput);
            string lowercaseNewWord = makeLowerCase(userInput);
            Console.Write("heres your word translated to piglatin:     ");
            Console.WriteLine(newWord);

            Console.Write("heres your word translated at the first vowel to piglatin:     ");
            Console.WriteLine(VowelNewWord);

            Console.Write("heres your word translated to piglatin unless it starts with a vowel:     ");
            Console.WriteLine(startsWithVowelNewWord);

            Console.Write("heres your word translated to piglatin and made lowercase:     ");
            Console.WriteLine(lowercaseNewWord);
            Console.WriteLine("");

            Console.WriteLine("Let's try a whole sentence!");
            string userInputSentence = Console.ReadLine();
            string translatedSentence = moreWords(userInputSentence);
            Console.WriteLine(translatedSentence);
            Console.Write("oops let me fix that punctuation");
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine("");
            string fixTranslation = fixPunctuation(translatedSentence);
            Console.WriteLine(fixTranslation);
            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
        }

        public static string TranslateWord(string word)
        {
            string firstLetter = word.Substring(0, 1);
            string restWord = word.Substring(1);
            string translatedWord = (restWord + firstLetter + "ay");
            return translatedWord;
        }

        public static string TranslateWordVowel(string word)
        {
            // your code goes here
            int firstVowelIndex = word.IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u', 'y' });
            string firstPart = word.Substring(0, firstVowelIndex);
            string secondPart = word.Substring(firstVowelIndex);
            string translatedWord = (secondPart + firstPart + "ay");

            return translatedWord;
        }

        public static string startsWithVowel(string word)
        {
            // your code goes here
            int firstVowelIndex = word.IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u', 'y' });
            string last = word.Substring(0, 1);
            string first = word.Substring(1);
            if (firstVowelIndex == 0)
            {

                string translatedWord = (last + first + "yay");

                return translatedWord;
            }
            else
            {
                string notAVowel = (first + last + "ay (try a word that starts with a vowel!)");
                return notAVowel;
            }

        }
        public static string makeLowerCase(string word)
        {
            string convertLower = word.ToLower();
            string firstLetter = convertLower.Substring(0, 1);
            string restWord = convertLower.Substring(1);
            string translatedWord = (restWord + firstLetter + "ay (try a word that has differant cased letters!)");
            return translatedWord;
        }
        public static string moreWords(string words)
        {
            string[] allWords = words.Split(' ');
            string[] translatedWords = new string[allWords.Length];
            for (int i = 0; i < allWords.Length; i++)
            {
                string firstLetter = allWords[i].Substring(0, 1);
                string restWord = allWords[i].Substring(1);
                translatedWords[i] = (restWord + firstLetter + "ay");
            }
            string translatedString = String.Join(" ", translatedWords);
            return translatedString;
        }
        public static string fixPunctuation(string words)
        {
            string[] allWords = words.Split(' ');
            string[] correctedWords = new string[allWords.Length];
            for (int i = 0; i < allWords.Length; i++)
            {
                int findPunctuation = allWords[i].IndexOfAny(new char[] { '?', '.', '!', ',' });
                if (findPunctuation > 0)
                {
                    string firstPart = allWords[i].Substring(0, findPunctuation);
                    string secondPartIncorrect = allWords[i].Substring(findPunctuation);
                    string secondPartFirst = secondPartIncorrect.Substring(0, 1);
                    string secondPartlast = secondPartIncorrect.Substring(1);
                    string secondPart = secondPartlast + secondPartFirst;
                    correctedWords[i] = (firstPart + secondPart);
                }
                else
                {
                    correctedWords[i] = allWords[i];
                }
            }
            string translatedString = String.Join(" ", correctedWords);
            return translatedString;
        }
    }
}
