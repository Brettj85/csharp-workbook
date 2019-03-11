using System;

namespace ENUM
{
    class Program
    {
        private enum Day
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        };
        private enum Months : byte
        {
            Jan,
            Feb,
            Mar,
            Apr,
            May,
            Jun,
            Jul,
            Aug,
            Sep,
            Oct,
            Nov,
            Dec
        };
        static void Main(string[] args)
        {
            Day today = Day.Monday;
            int dayNumber = (int)today;
            Console.WriteLine("{0} is day #{1}.", today, dayNumber);
            Months thisMonth = Months.Dec;
            byte monthNumber = (byte)thisMonth;
            Console.WriteLine("{0} is month #{1}.", thisMonth, monthNumber);

            foreach (var item in new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 })
            {
                if (Enum.IsDefined(typeof(Months), item))
                {
                    var monthEnum = (Months)item;
                    Console.WriteLine(monthEnum.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }
            }
        }
    }
}
