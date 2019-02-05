using System;

namespace starwars
{
    public class Station
    {
        private Bay[] docked;

        public Station(string alliance, string name, int bays)
        {
            this.Name = name;
            this.Alliance = alliance;
            this.docked = new Bay[bays];
        }

        public string Name { get; set; }

        public string Alliance { get; set; }

        public string Passengers
        {
            get
            {
                foreach (var ship in docked)
                {
                    Console.WriteLine(String.Format("{0}", ship.Type));
                }

                return "That's Everybody!";
            }
        }

        public void EnterStation(Ship ship, int bay)
        {
            this.docked[bay] = ship;
        }

        public void ExitStation(int bay)
        {
            this.docked[bay] = null;
        }
    }

}