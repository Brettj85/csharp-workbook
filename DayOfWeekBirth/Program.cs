using System;

namespace DayOfWeekBirth
{
    class Program
    {
        enum DaysWeek
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
        }
    }
    class DayOfBirth
    {

        public int DayOfWeek(int d, int m, int y)
        {
            int[] t = { 0, 3, 2, 5, 0, 3, 5,
                            1, 4, 6, 2, 4 };
            y -= (m < 3) ? 1 : 0;

            return (y + y / 4 - y / 100 + y / 400
                             + t[m - 1] + d) % 7;
        }
    }
}