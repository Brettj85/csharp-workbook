using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Person person = new Person("Bill");
        Car blueCar = new Car("blue", person, 1);

        blueCar.AddPerson(person, 2);
        Garage smallGarage = new Garage(2);

        smallGarage.ParkCar(blueCar, 0);
        Console.WriteLine(smallGarage.Cars);
    }
    class Person
    {
        public Person(string initial_name)
        {
            first_name = initial_name;
        }

        public string first_name { get; private set; }
    }
    class Car
    {
        public Person[] person;
        int spot;

        public Car(string initialColor, Person initialName, int initialSpot)
        {
            this.person = new Person[4];
            this.Color = initialColor;
            this.person[0] = initialName;
            this.spot = initialSpot;
        }
        public string Color { get; private set; }
        public void AddPerson(Person initialName, int where)
        {
            person[where] = initialName;
        }
    }


    class Garage
    {
        private Car[] cars;

        public Garage(int initialSize)
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
                for (int i = 0; i < cars.Length; i++)
                {
                    if (cars[i] != null)
                    {
                        Console.WriteLine(String.Format("The {0} car is in spot {1}.", cars[i].Color, cars[i].person));
                    }
                }
                return "That's all!";
            }
        }
    }
}
