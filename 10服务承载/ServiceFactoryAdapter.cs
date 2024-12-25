using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10服务承载
{
    public class ServiceFactoryAdapter<TContainerBuilder> //: IServiceFactoryAdapter
    {
        private IServiceProviderFactory<TContainerBuilder> _serviceProviderFactory;
        private Func<HostBuilderContext> _contentResolver;
        private Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> _factoryResolver;

        public ServiceFactoryAdapter(IServiceProviderFactory<TContainerBuilder> serviceProviderFactory)
        {
            _serviceProviderFactory= serviceProviderFactory;
        }
        public ServiceFactoryAdapter(Func<HostBuilderContext> contentResolver, Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factoryResolver)
        {
            _contentResolver= contentResolver;
            _factoryResolver= factoryResolver;
        }

        public TContainerBuilder CreateBuilder(IServiceCollection services)
        {
            return (_serviceProviderFactory ?? _factoryResolver(_contentResolver())).CreateBuilder(services);
        }

        public IServiceProvider CreateServiceProvider(TContainerBuilder containerBuilder)
        {
           return _serviceProviderFactory.CreateServiceProvider(containerBuilder);
        }
    }
}
