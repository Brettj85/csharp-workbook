using System;

namespace starwars
{
    class Program
    {
        public static void Main()
        {
            Person luke = new Person("Luke", "Skywalker", "Rebel");
            Person leia = new Person("Leia", "Organa", "Rebel");
            Person chewy = new Person("Chewbacca", null, "Rebel");
            Person han = new Person("Han", "Solo", "Han");
            Person darth = new Person("Darth", "Vader", "Imperial");
            Person palpatine = new Person("Emperor", "Palpatine", "Imperial");
            Person boba = new Person("Boba", "Fett", "Boba");
            Ship yt1300 = new Ship("Rebel", "Smuggling", 5, "millennium falcon");
            Ship tieA1 = new Ship("Imperial", "Fighting", 2, "Tie Advanced 1");
            Ship slave = new Ship("Imperial", "Stalking", 4, "Slave 1");
            Ship xwing = new Ship("Rebel", "Fighting", 1, "AA-589");
            Station deathStar = new Station(10, "Imperial", "Death Star");
            Station cloudCity = new Station(4, "rebel", "Cloud City");
            yt1300.EnterShip(leia, 3);
            yt1300.EnterShip(han, 0);
            yt1300.EnterShip(chewy, 1);
            xwing.EnterShip(luke, 0);
            tieA1.EnterShip(darth, 0);
            tieA1.EnterShip(palpatine, 1);
            slave.EnterShip(boba, 0);
            deathStar.EnterStation(slave, 0);
            deathStar.EnterStation(tieA1, 1);
            cloudCity.EnterStation(xwing, 0);
            cloudCity.EnterStation(yt1300, 1);
            deathStar.Roster();
            Console.WriteLine();
            cloudCity.Roster();
        }
    }
}

