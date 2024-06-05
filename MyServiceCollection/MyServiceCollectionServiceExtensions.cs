using System.Diagnostics.CodeAnalysis;

namespace MyServiceCollection
{
    public static class MyServiceCollectionServiceExtensions
    {
        #region Public Methods

        /// <summary>
        /// Adds a transient service of the type specified in <paramref name="serviceType"/> with an
        /// implementation of the type specified in <paramref name="implementationType"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationType">The implementation type of the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IMyServiceCollection AddTransient(
            this IMyServiceCollection services,
            Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(implementationType);

            return Add(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

        /// <summary>
        /// Adds a transient service of the type specified in <paramref name="serviceType"/> with a
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IMyServiceCollection AddTransient(
            this IMyServiceCollection services,
            Type serviceType,
            Func<IMyServiceProvider, object> implementationFactory)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(implementationFactory);

            return Add(services, serviceType, implementationFactory, ServiceLifetime.Transient);
        }

        /// <summary>
        /// Adds a transient service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IMyServiceCollection AddTransient<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IMyServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            ThrowHelper.ThrowIfNull(services);

            return services.AddTransient(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Adds a transient service of the type specified in <paramref name="serviceType"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IMyServiceCollection AddTransient(
            this IMyServiceCollection services,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);

            return services.AddTransient(serviceType, serviceType);
        }

        /// <summary>
        /// Adds a transient service of the type specified in <typeparamref name="TService"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IMyServiceCollection AddTransient<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IMyServiceCollection services)
            where TService : class
        {
            ThrowHelper.ThrowIfNull(services);

            return services.AddTransient(typeof(TService));
        }

        /// <summary>
        /// Adds a transient service of the type specified in <typeparamref name="TService"/> with a
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IMyServiceCollection AddTransient<TService>(
            this IMyServiceCollection services,
            Func<IMyServiceProvider, TService> implementationFactory)
            where TService : class
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(implementationFactory);

            return services.AddTransient(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// Adds a transient service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation" /> using the
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Transient"/>
        public static IMyServiceCollection AddTransient<TService, TImplementation>(
            this IMyServiceCollection services,
            Func<IMyServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(implementationFactory);

            return services.AddTransient(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// Adds a scoped service of the type specified in <paramref name="serviceType"/> with an
        /// implementation of the type specified in <paramref name="implementationType"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationType">The implementation type of the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IMyServiceCollection AddScoped(
            this IMyServiceCollection services,
            Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(implementationType);

            return Add(services, serviceType, implementationType, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds a scoped service of the type specified in <paramref name="serviceType"/> with a
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IMyServiceCollection AddScoped(
            this IMyServiceCollection services,
            Type serviceType,
            Func<IMyServiceProvider, object> implementationFactory)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(implementationFactory);

            return Add(services, serviceType, implementationFactory, ServiceLifetime.Scoped);
        }

        /// <summary>
        /// Adds a scoped service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IMyServiceCollection AddScoped<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IMyServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            ThrowHelper.ThrowIfNull(services);

            return services.AddScoped(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Adds a scoped service of the type specified in <paramref name="serviceType"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="serviceType">The type of the service to register and the implementation to use.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IMyServiceCollection AddScoped(
            this IMyServiceCollection services,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);

            return services.AddScoped(serviceType, serviceType);
        }

        /// <summary>
        /// Adds a scoped service of the type specified in <typeparamref name="TService"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IMyServiceCollection AddScoped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IMyServiceCollection services)
            where TService : class
        {
            ThrowHelper.ThrowIfNull(services);

            return services.AddScoped(typeof(TService));
        }

        /// <summary>
        /// Adds a scoped service of the type specified in <typeparamref name="TService"/> with a
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IMyServiceCollection AddScoped<TService>(
            this IMyServiceCollection services,
            Func<IMyServiceProvider, TService> implementationFactory)
            where TService : class
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(implementationFactory);

            return services.AddScoped(typeof(TService), implementationFactory);
        }

        /// <summary>
        /// Adds a scoped service of the type specified in <typeparamref name="TService"/> with an
        /// implementation type specified in <typeparamref name="TImplementation" /> using the
        /// factory specified in <paramref name="implementationFactory"/> to the
        /// specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TService">The type of the service to add.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation to use.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
        /// <param name="implementationFactory">The factory that creates the service.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="ServiceLifetime.Scoped"/>
        public static IMyServiceCollection AddScoped<TService, TImplementation>(
            this IMyServiceCollection services,
            Func<IMyServiceProvider, TImplementation> implementationFactory)
            where TService : class
            where TImplementation : class, TService
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(implementationFactory);

            return services.AddScoped(typeof(TService), implementationFactory);
        }

        public static IMyServiceCollection AddSingleton(
            this IMyServiceCollection services,
            Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(implementationType);

            return Add(services, serviceType, implementationType, ServiceLifetime.Singleton);
        }

        public static IMyServiceCollection AddSingleton<TService, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IMyServiceCollection services)
            where TService : class
            where TImplementation : class, TService
        {
            ThrowHelper.ThrowIfNull(services);

            return services.AddSingleton(typeof(TService), typeof(TImplementation));
        }

        public static IMyServiceCollection AddSingleton(this IMyServiceCollection services,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type serviceType)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);

            return services.AddSingleton(serviceType, serviceType);
        }

        public static IMyServiceCollection AddSingleton<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TService>(this IMyServiceCollection services)
         where TService : class
        {
            ThrowHelper.ThrowIfNull(services);

            return services.AddSingleton(typeof(TService));
        }

        public static IMyServiceCollection AddSingleton<TService>(this IMyServiceCollection services,
            Func<IMyServiceProvider, TService> implementationFactory) where TService : class
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(implementationFactory);

            return services.AddSingleton(typeof(TService), implementationFactory);
        }

        public static IMyServiceCollection AddSingleton(this IMyServiceCollection services, Type serviceType, object implementationInstance)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(implementationInstance);

            var serviceDescriptor = new MyServiceDescriptor(serviceType, implementationInstance);
            services.Add(serviceDescriptor);
            return services;
        }

        public static IMyServiceCollection AddSingleton<TService>(this IMyServiceCollection services, TService implementationInstance) where TService : class
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(implementationInstance);

            return services.AddSingleton(typeof(TService), implementationInstance);
        }

        #endregion

        #region Private Methods

        private static IMyServiceCollection Add(IMyServiceCollection collection, Type serviceType,
          [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
          ServiceLifetime lifetime)
        {
            var descriptor = new MyServiceDescriptor(serviceType, implementationType, lifetime);
            collection.Add(descriptor);
            return collection;
        }

        private static IMyServiceCollection Add(IMyServiceCollection collection, Type serviceType, Func<IMyServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
        {
            var descriptor = new MyServiceDescriptor(serviceType, implementationFactory, lifetime);
            collection.Add(descriptor);
            return collection;
        }

        #endregion



    }
}
