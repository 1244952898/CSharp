namespace IOCTest.Cat.Models
{
    public class Foo : Base, IFoo
    {
        public IBar _bar;
        public Foo(IBar bar)
        {
            bar = _bar;
        }
    }
}
