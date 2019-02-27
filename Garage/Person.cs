using System;

namespace Garage
{
    class Person
    {
        private string first;
        private string last;
        public string full { get; private set; }
        public Person(string f, string l)
        {
            first = f;
            last = l;
            full = first + " " + last;
        }
    }
}