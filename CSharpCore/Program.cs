namespace CSharpCore
{
    public class Program
    {
        public delegate int GetNumber(int x);

        static void Main()
        {
            Mutex mutex = new();
            mutex.WaitOne();

            var dg = new GetNumber(GN);
            AsyncCallback asyncCallback = new(callBack);
            IAsyncResult asyncResult = dg.BeginInvoke(4, asyncCallback, GN);
            asyncResult.AsyncWaitHandle.WaitOne();
            var i = dg.EndInvoke(asyncResult);
        }

        static int GN(int x)
        {
            return x * 2;
        }

        static void callBack(IAsyncResult ar)
        {
            var dg = (GetNumber)ar.AsyncState;
            var i = dg.EndInvoke(ar);
        }
    }
}