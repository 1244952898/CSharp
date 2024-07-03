using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceCollection
{
    internal interface IMyServiceProviderFactory<TContainerBuilder> where TContainerBuilder : notnull
    {
        /// <summary>
        /// Creates a container builder from an <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The collection of services</param>
        /// <returns>A container builder that can be used to create an <see cref="IServiceProvider"/>.</returns>
        TContainerBuilder CreateBuilder(IMyServiceCollection services);

        /// <summary>
        /// Creates an <see cref="IServiceProvider"/> from the container builder.
        /// </summary>
        /// <param name="containerBuilder">The container builder</param>
        /// <returns>An <see cref="IServiceProvider"/></returns>
        IServiceProvider CreateServiceProvider(TContainerBuilder containerBuilder);

    }
}
