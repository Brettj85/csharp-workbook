using System;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Person jan = new Person("Jan", "Spitzer");
            Person george = new Person("George", "Lopez");
            Person frank = new Person("Frank", "Smith");
            Car ferarri = new Car("red", 4);
            ferarri.addPerson(jan, 1);
            ferarri.addPerson(george, 0);
            ferarri.addPerson(frank, 3);
            Car blueCar = new Car("blue", 4);
            ParkingGarage smallGarage = new ParkingGarage(2);

            smallGarage.ParkCar(blueCar, 0);
            smallGarage.ParkCar(ferarri, 1);
            Console.WriteLine(smallGarage.GetCars());
            Console.ReadLine();
        }
    }
}
