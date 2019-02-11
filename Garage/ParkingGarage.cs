using System;
using System.Text;

namespace Garage
{
    class ParkingGarage
    {
        private Car[] cars;

        public ParkingGarage(int initialSize)
        {
            Size = initialSize;
            this.cars = new Car[initialSize];
        }

        public int Size { get; private set; }

        public void ParkCar(Car car, int spot)
        {
            cars[spot] = car;
        }

        public string Cars
        {
            get
            {
                StringBuilder returnValue = new StringBuilder(); ;
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i] != null)
                    {
                        string carSpot = String.Format("The {0} car is in spot {1}. ", cars[i].Color, i);
                        returnValue.Append(carSpot);
                        returnValue.Append(cars[i].getPeople());
                        returnValue.Append(Environment.NewLine);
                    }
                }
                return returnValue.ToString();
            }
        }
    }
}