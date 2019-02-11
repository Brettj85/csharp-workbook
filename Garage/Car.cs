using System;
using System.Text;
using System.Collections.Generic;

namespace Garage
{
    using System;

    class Car
    {
        public Person[] people { get; private set; }
        public Car(string initialColor, int capacity)
        {
            this.Color = initialColor;
            this.people = new Person[capacity];
        }
        public void addPerson(Person addMe, int spot)
        {

            try
            {
                try
                {
                    Console.WriteLine("sorry that spot is already filled by {0}", people[spot].full);
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("that spot does not exist");
                }
            }
            catch (System.NullReferenceException)
            {
                this.people[spot] = addMe;
            }
        }

        public string GetPeople()
        {
            List<string> inCar = new List<string>();
            StringBuilder persons = new StringBuilder();
            foreach (var item in people)
            {
                if (item != null)
                {
                    inCar.Add(item.full.ToString());
                }
            }
            if (inCar.Count > 0)
            {
                int findLast = 0;
                foreach (var person in inCar)
                {
                    if (inCar.Count - 1 == findLast)
                    {
                        persons.Append("and " + person + " ");
                    }
                    else
                    {
                        persons.Append(person.ToString() + ", ");
                        findLast++;
                    }

                }
                if (inCar.Count > 1)
                {
                    persons.Append("are in the car.");
                }
                else
                {
                    persons.Append("is in the car.");

                }
            }
            else
            {
                persons.Append("There are no people in the car.");
            }
            return persons.ToString();
        }

        public string Color { get; private set; }
    }

}