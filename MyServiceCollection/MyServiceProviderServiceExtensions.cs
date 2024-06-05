using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceCollection
{
    public static class MyServiceProviderServiceExtensions
    {
        /// <summary>
        /// Get service of type <typeparamref name="T"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="T">The type of service object to get.</typeparam>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <returns>A service object of type <typeparamref name="T"/> or null if there is no such service.</returns>
        public static T? GetService<T>(this IMyServiceProvider provider)
        {
            ThrowHelper.ThrowIfNull(provider);

            return (T?)provider.GetService(typeof(T));
        }

        /// <summary>
        /// Get service of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="serviceType"/>.</returns>
        /// <exception cref="System.InvalidOperationException">There is no service of type <paramref name="serviceType"/>.</exception>
        public static object GetRequiredService(this IMyServiceProvider provider, Type serviceType)
        {
            ThrowHelper.ThrowIfNull(provider);
            ThrowHelper.ThrowIfNull(serviceType);

            if (provider is IMySupportRequiredService requiredServiceSupportingProvider)
            {
                return requiredServiceSupportingProvider.GetRequiredService(serviceType);
            }

            object? service = provider.GetService(serviceType);
            if (service == null)
            {
                throw new InvalidOperationException();
            }

            return service;
        }

        /// <summary>
        /// Get service of type <typeparamref name="T"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="T">The type of service object to get.</typeparam>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the service object from.</param>
        /// <returns>A service object of type <typeparamref name="T"/>.</returns>
        /// <exception cref="System.InvalidOperationException">There is no service of type <typeparamref name="T"/>.</exception>
        public static T GetRequiredService<T>(this IMyServiceProvider provider) where T : notnull
        {
            ThrowHelper.ThrowIfNull(provider);

            return (T)provider.GetRequiredService(typeof(T));
        }

        /// <summary>
        /// Get an enumeration of services of type <typeparamref name="T"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="T">The type of service object to get.</typeparam>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the services from.</param>
        /// <returns>An enumeration of services of type <typeparamref name="T"/>.</returns>
        public static IEnumerable<T> GetServices<T>(this IMyServiceProvider provider)
        {
            ThrowHelper.ThrowIfNull(provider);

            return provider.GetRequiredService<IEnumerable<T>>();
        }

        /// <summary>
        /// Get an enumeration of services of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to retrieve the services from.</param>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>An enumeration of services of type <paramref name="serviceType"/>.</returns>
        [RequiresDynamicCode("The native code for an IEnumerable<serviceType> might not be available at runtime.")]
        public static IEnumerable<object?> GetServices(this IMyServiceProvider provider, Type serviceType)
        {
            ThrowHelper.ThrowIfNull(provider);
            ThrowHelper.ThrowIfNull(serviceType);

            Type? genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }

        /// <summary>
        /// Creates a new <see cref="IServiceScope"/> that can be used to resolve scoped services.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to create the scope from.</param>
        /// <returns>A <see cref="IServiceScope"/> that can be used to resolve scoped services.</returns>
        public static IMyServiceScope CreateScope(this IMyServiceProvider provider)
        {
            return provider.GetRequiredService<IMyServiceScopeFactory>().CreateScope();
        }

        /// <summary>
        /// Creates a new <see cref="AsyncServiceScope"/> that can be used to resolve scoped services.
        /// </summary>
        /// <param name="provider">The <see cref="IServiceProvider"/> to create the scope from.</param>
        /// <returns>An <see cref="AsyncServiceScope"/> that can be used to resolve scoped services.</returns>
        public static MyAsyncServiceScope CreateAsyncScope(this IMyServiceProvider provider)
        {
            return new MyAsyncServiceScope(provider.CreateScope());
        }

        /// <summary>
        /// Creates a new <see cref="AsyncServiceScope"/> that can be used to resolve scoped services.
        /// </summary>
        /// <param name="serviceScopeFactory">The <see cref="IServiceScopeFactory"/> to create the scope from.</param>
        /// <returns>An <see cref="AsyncServiceScope"/> that can be used to resolve scoped services.</returns>
        public static MyAsyncServiceScope CreateAsyncScope(this IMyServiceScopeFactory serviceScopeFactory)
        {
            return new MyAsyncServiceScope(serviceScopeFactory.CreateScope());
        }
    }
}
