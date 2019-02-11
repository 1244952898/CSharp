namespace CacheMVCDemo
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return ID+" "+Name +" "+Age;
        }
    }
}