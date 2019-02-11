using System;

namespace starwars
{
    class Ship
    {
        public Person[] passengers { get; private set; }


        public Ship(string allegiance, string type, int size, string name)
        {
            this.Type = type;
            this.Allegiance = allegiance;
            this.Name = name;
            this.passengers = new Person[size];
        }
        public string Type { get; set; }
        public string Allegiance { get; set; }
        public string Name { get; set; }
        public void EnterShip(Person person, int seat) => this.passengers[seat] = person;
        public void ExitShip(int seat) => this.passengers[seat] = null;
    }
}