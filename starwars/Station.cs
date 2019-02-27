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
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Ships Docked in {0}", name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var item in bays)
            {
                try
                {
                    if (item != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Ship: " + item.Name);
                    Console.WriteLine("Type: " + item.Type);
                    Console.WriteLine("Allegiance: " + item.Allegiance);
                    Console.Write("Passangers: ");
                    int j = 0;
                    foreach (var person in item.passengers)
                    {
                        if (j != 0 && person != null)
                        {
                            Console.Write(", ");
                            Console.Write(person.FullName);
                        }
                        else if (person != null)
                        {
                            Console.Write(person.FullName);
                            j++;
                        }

                    }
                }
                catch (System.NullReferenceException)
                {


                }
            }
            Console.WriteLine();
        }
    }
}