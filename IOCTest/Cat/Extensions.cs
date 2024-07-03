using Microsoft.Extensions.DependencyInjection;

namespace IOCTest.Cat
{
    public static class Extensions
    {
        public static CatLifetime AsLifetime(this ServiceLifetime lifetime)
        {
            return lifetime switch
            {
                ServiceLifetime.Singleton => CatLifetime.Root,
                ServiceLifetime.Scoped => CatLifetime.Self,
                _ => CatLifetime.Transient,
            };
        }
    }
}
