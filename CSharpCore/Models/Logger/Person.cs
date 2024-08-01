namespace CSharpCore.Models.Logger
{
    public class Person
    {
        public string Name { get; set; }
        public double Id { get; set; }
        public Person(string name, double id)
        {
            this.Name = name;
            this.Id = id;
        }

        public static implicit operator double(Person p)
        {
            return p.Id;
        }

        public static implicit operator Person(string p)
        {
            return new Person(p, 1);
        }

        public static explicit operator Person(double p)
        {
            return new Person("p", p);
        }

        public static explicit operator string(Person p)
        {
            return p.Name;
        }
    }
}
