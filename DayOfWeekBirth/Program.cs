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
            int year = getValidYear();
            int day = birth.DayOfWeek(20, 6, year);
            DaysWeek theDay = (DaysWeek)day;
            Console.Clear();
            bool isBeforeBirthday = DateTime.Now.Month == 6 && DateTime.Now.Day <= 20 ? true : false;
            isBeforeBirthday = !isBeforeBirthday && DateTime.Now.Month < 6 ? false : true;
            isBeforeBirthday = isBeforeBirthday && year == DateTime.Now.Year ? true : false;
            Console.WriteLine("My birthday {2} on {0} in {1}", theDay, year, (year < DateTime.Now.Year || isBeforeBirthday ? "fell" : "falls"));
            Console.WriteLine();
            Events odd = new Events();
            string happend = odd.GetEvent(year);
            if (happend != "")
            {
                printHappend(happend, year);
            }
        }
        private static int getValidYear()
        {
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
            return year;
        }
        private static void printHappend(string happend, int year)
        {
            int amount = happend.Length;
            string[] story = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                story[i] = happend.Substring(i, 1);
            }

            Console.WriteLine("   ON THIS DAY IN {0}   ", year);
            for (int i = 0; i < story.Length; i++)
            {
                if (i % 24 == 0 && i != 0)
                {
                    if (story[i + 1] != " " && story[i - 1] != " " && story[i] != " ")
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                    if (story[i] != " ")
                    {
                        Console.Write(story[i]);
                    }
                }
                else
                {
                    Console.Write(story[i]);
                }
            }
        }
    }
}