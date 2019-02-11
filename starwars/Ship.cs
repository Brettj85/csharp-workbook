using System;

namespace starwars
{
    class Ship
    {
        private Person[] passengers;
        public Ship(string alliance, string type, int size)
        {
            this.Type = type;
            this.Alliance = alliance;
            this.passengers = new Person[size];
        }

        public string Type { get; set; }

        public string Alliance { get; set; }


        public string Passengers
        {
            get
            {
                foreach (var person in passengers)
                {
                    Console.WriteLine(String.Format("{0}", person.FullName));
                }

                return "That's Everybody!";
            }
        }

        public void EnterShip(Person person, int seat)
        {
            this.passengers[seat] = person;
        }

        public void ExitShip(int seat)
        {
            this.passengers[seat] = null;
        }
    }
}