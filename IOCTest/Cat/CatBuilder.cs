using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IOCTest.Cat
{
    public class CatBuilder
    {
        private readonly Cat _cat;
        public CatBuilder(Cat cat)
        {
            _cat = cat;
            _cat.Register<IServiceScopeFactory>(c => new ServiceScopeFactory(c.CreateChildren()), CatLifetime.Transient);
        }
        public IServiceProvider BuildServiceProvider() => _cat;

        public CatBuilder Register(Assembly assembly)
        {
            _cat.Register(assembly);
            return this;
        }

        #region Classes

        private class ServiceScope : IServiceScope
        {
            public IServiceProvider ServiceProvider { get; }
            public ServiceScope(IServiceProvider serviceProvider) => ServiceProvider = serviceProvider;

            public void Dispose()
            {
                (ServiceProvider as IDisposable)?.Dispose();
            }
        }

        private class ServiceScopeFactory : IServiceScopeFactory
        {
            private readonly Cat _cat;
            public ServiceScopeFactory(Cat cat)
            {
                _cat = cat;
            }
            public IServiceScope CreateScope()
            {
                return new ServiceScope(_cat);
            }
        }

        #endregion
    }
}
