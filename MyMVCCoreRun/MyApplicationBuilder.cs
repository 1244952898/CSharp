namespace MyMVCCoreRun
{
    public class MyApplicationBuilder : IMyApplicationBuilder
    {
        private readonly IList<Func<MyRequestDelegate, MyRequestDelegate>> _middlewares = [];

        public MyRequestDelegate Build()
        {
            MyRequestDelegate next = content =>
            {
                content.Response.StatusCode = 404;
                return Task.CompletedTask;
            };

            foreach (var middleware in _middlewares)
            {
                next = middleware.Invoke(next);
            }
            return next;
        }

        public IMyApplicationBuilder Use(Func<MyRequestDelegate, MyRequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }
}
