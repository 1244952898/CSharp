using Microsoft.Extensions.DependencyInjection;

namespace IOCTest.Cat
{
    public class CatServiceProviderFactory : IServiceProviderFactory<CatBuilder>
    {
        public CatBuilder CreateBuilder(IServiceCollection services)
        {
            var cat = new Cat();
            foreach (var service in services)
            {
                if (service.ImplementationFactory != null)
                {
                    cat.Register(service.ServiceType, provider =>
                        {
                            return service.ImplementationFactory(provider);
                        }
                        , service.Lifetime.AsLifetime());
                }
                else if (service.ImplementationInstance != null)
                {
                    cat.Register(service.ServiceType, service.ImplementationInstance);
                }
                else
                {
                    cat.Register(service.ServiceType, service.ImplementationType, service.Lifetime.AsLifetime());
                }
            }
            return new CatBuilder(cat);
        }

        public IServiceProvider CreateServiceProvider(CatBuilder containerBuilder)
        {
            return containerBuilder.BuildServiceProvider();
        }
    }
}
