using System;

namespace DayOfWeekBirth
{
    class Program
    {
        private enum DaysWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wedensday,
            Thursday,
            Friday,
            Saturday
        }
        static void Main(string[] args)
        {
            DayOfBirth birth = new DayOfBirth();
            Console.Write("enter four digits of a year");
            string yearstring = "";
            int year = 0;
            while (year == 0)
            {
                while (yearstring.Length != 4)
                {
                    yearstring = Console.ReadLine();
                }
                if (int.TryParse(yearstring, out year))
                {

                }
            }
            int day = birth.DayOfWeek(20, 6, year);
            DaysWeek theDay = (DaysWeek)day;
            Console.WriteLine("My birthday falls on {0} in {1}", theDay, year);
            Events odd = new Events();
            string happend = odd.GetEvent(year);
            if (happend != "")
            {
                int amount = happend.Length;
                string[] story = new string[amount];
                for (int i = 0; i < amount; i++)
                {
                    story[i] = happend.Substring(i, 1);
                }

                Console.WriteLine("ON THIS DAY IN HISTORY");
                for (int i = 0; i < story.Length; i++)
                {
                    if (i % 21 == 0 && i != 0)
                    {
                        if (story[i + 1] != " ")
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
                        Console.Write(story[i]);
                    }
                    else
                    {
                        Console.Write(story[i]);
                    }
                }
            }
        }
    }
}