using System;

namespace whiteboardt
{
    class Program
    {
        static void Main(string[] args)
        {
            Person jeff = new Person("Jeff", DateTime.Parse("1/14/1985"));
            Console.WriteLine(jeff.GetDescription());
            Person Stark = new SuperHuman("Tony Stark", DateTime.Parse("6/20/1975"), "IronSuited");
            Console.WriteLine(Stark.GetDescription());
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        public Person(string name, DateTime dob)
        {
            this.Name = name;
            this.DOB = dob;
        }
        public string GetAge()
        {
            return (DateTime.Now - DOB).ToString();
        }
        public virtual string GetDescription()
        {
            return Name + "'s birthday is " + DOB.ToString();
        }
    }
    public class SuperHuman : Person
    {
        public string SuperPower { get; set; }
        public SuperHuman(string name, DateTime dob, string super) : base(name, dob)
        {
            SuperPower = super;
        }
        public override string GetDescription()
        {
            return this.Name + "'s birthday is " + this.DOB.ToString() + " and the SuperPower they have is " + this.SuperPower;
        }
    }
}
