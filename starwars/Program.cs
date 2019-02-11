using System;

namespace starwars
{
    class Program
    {
        public static void Main()
        {
            Person leia = new Person("Leia", "Organa", "Rebel");
            Person darth = new Person("Darth", "Vader", "Imperial");
            Ship falcon = new Ship("Rebel", "Smuggling", 2);
            Ship tie = new Ship("Tie", "Fighter", 1);
            falcon.EnterShip(leia, 1);
            tie.EnterShip(darth, 1);
            Station deathStar = new Station(3, "empire", "Death Star");

        }
    }
}

