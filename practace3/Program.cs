﻿using System;

namespace practace3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool people = true;
            bool f = false;
            decimal num = 30.2m;
            Console.WriteLine("the number {0} multiplied by itself is {1}", num, num*num);

            string firstName = "Brett";
            string lastName = "Jackson";
            int age = 33;
            string job = "Network Engineer";
            string favoriteBand = "Rise Against";
            string favoriteSportsTeam = "Buffalo Bills";

            int decToInt = Convert.ToInt32(num);
            Console.WriteLine("{0} {1} {2} {3}", 100+10, 100*10, 100/10, 100-10);

        }
    }
}
