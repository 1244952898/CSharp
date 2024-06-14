namespace IOCTest.Models
{
    public interface IFoo
    {
    }

    public interface IBar
    {
    }

    public class Foo : IFoo
    {
        public IBar _bar;
        public Foo(IBar bar)
        {
            bar = _bar;
        }
    }

    public class Bar : IBar
    {
    }

    public interface IFooBar
    {

    }

    public class FooBar : IFooBar
    {
        private FooBar()
        {
            
        }
        public static readonly  FooBar Instance = new FooBar();
    }
}
