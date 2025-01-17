namespace MyMVCCoreRun
{
    public abstract class MyHttpContent
    {
        public abstract MyHttpRequest Request { get; }
        public abstract MyHttpResponse Response { get; }
    }
}
