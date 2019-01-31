using System;
using System.Collections.Generic;

namespace CarGarage2
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Person
    {
        private List<string> names;

        private Person(string next_person)
        {
            string first_name = next_person;
            this.names.Add(first_name);
        }
        public string next_person { get; private set; }
    }
    class Car
    {
        //variables
        private List<int> capacity;
        public Car(/*properties */)
        {
            //Do Work....
        }
        //get and set properties
        public string next_person { get; private set; }
    }
    class Garage
    {

    }
}
