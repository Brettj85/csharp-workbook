using System;
using System.Text;

namespace starwars
{
    class Station
    {
        public Ship[] bays { get; private set; }
        public string name { get; private set; }
        public string allegiance { get; private set; }
        public Station(int bays, string ally, string serial)
        {
            this.bays = new Ship[bays];
            this.allegiance = ally;
            this.name = serial;
        }
        public void EnterStation(Ship ship, int bay)
        {
            string response;
            CheckBay(ship, bay);
            response = bays[bay] == ship ? "Successfully docked in this bay" : "A ship is already docked in this bay";
            Console.WriteLine(response);
        }
        public void CheckBay(Ship ship, int bay) => this.bays[bay] = bays[bay] == null ? this.bays[bay] = ship : this.bays[bay] = this.bays[bay];

        public void ExitStations(int bay) => this.bays[bay] = null;
        public void RebrandStation(string newName)
        {
            allegiance = allegiance == "rebel" ? "empire" : "rebel";
            ChangeName(newName);
        }
        public void ChangeName(string newName) => this.name = newName;

        public void Roster()
        {
            foreach (var item in bays)
            {
                Console.WriteLine("Ship: " + item);
                StringBuilder aboard = new StringBuilder();
                Console.Write("Passangers: " + item);
                foreach (var person in item.passengers)
                {
                    if (person == item.passengers[item.passengers.Length - 1])
                    {
                        Console.Write(person);
                    }
                    else
                    {
                        Console.Write(person + ", ");
                    }
                }

            }
        }
    }
}