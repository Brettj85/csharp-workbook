using System;

namespace starwars
{
    class Ship
    {
        public Person[] passengers { get; private set; }
        public Ship(string alliance, string type, int size)
        {
            this.Type = type;
            this.Alliance = alliance;
            this.passengers = new Person[size];
        }
        public string Type { get; set; }
        public string Alliance { get; set; }
        public void EnterShip(Person person, int seat) => this.passengers[seat] = person;
        public void ExitShip(int seat) => this.passengers[seat] = null;
    }
}