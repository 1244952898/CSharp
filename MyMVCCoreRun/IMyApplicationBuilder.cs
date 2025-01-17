namespace MyMVCCoreRun
{
    public interface IMyApplicationBuilder
    {
        MyRequestDelegate Build();
        IMyApplicationBuilder Use(Func<MyRequestDelegate, MyRequestDelegate> middleware);
    }
}
