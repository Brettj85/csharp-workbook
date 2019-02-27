using System;
using System.Text;

namespace starwars
{
    class Person
    {
        private string firstName;
        private string lastName;
        public string fullName { get; set; }
        private string alliance;
        public Person(string firstName, string lastName, string alliance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.alliance = alliance;
            StringBuilder full = new StringBuilder();
            if (firstName != null && lastName != null)
            {
                full.Append(firstName + " " + lastName);
            }
            else if (firstName != null || lastName != null)
            {
                full.Append(firstName != null ? firstName : lastName);
            }
        }

        public string FullName
        {
            get => this.firstName + " " + this.lastName;
            set
            {
                string[] names = value.Split(' ');
                this.firstName = names[0];
                this.lastName = names[1];
            }
        }
    }
}