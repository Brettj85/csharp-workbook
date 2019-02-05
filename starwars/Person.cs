using System;

namespace starwars
{
    public class Person
    {
        public string firstName;
        public string lastName;
        public string alliance;

        public Person(string firstName, string lastName, string alliance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.alliance = alliance;
        }
        public string FullName
        {
            get
            {
                return this.firstName + " " + this.lastName;
            }

            set
            {
                string[] names = value.Split(' ');
                this.firstName = names[0];
                this.lastName = names[1];
            }
        }
    }

}