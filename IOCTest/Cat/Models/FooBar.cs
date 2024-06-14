namespace IOCTest.Cat.Models
{
    public class FooBar<T1, T2> : IFooBar<T1, T2>
    {
        public IFoo Foo { get; }
        public IBar Bar { get; }
        public FooBar(IFoo foo, IBar bar)
        {
            Foo = foo;
            Bar = bar;
        }
    }
}
