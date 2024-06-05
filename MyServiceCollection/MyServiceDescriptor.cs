using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MyServiceCollection
{
    [DebuggerDisplay("Lifetime = {Lifetime}, ServiceType = {ServiceType}, ImplementationType = {ImplementationType}")]
    public class MyServiceDescriptor
    {
        #region Fields

        /// <summary>
        /// Gets the <see cref="ServiceLifetime"/> of the service.
        /// </summary>
        public ServiceLifetime Lifetime { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> of the service.
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> that implements the service.
        /// </summary>
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)]
        public Type? ImplementationType { get; }

        public object? ImplementationInstance { get; }

        /// <summary>
        /// Gets the factory used for creating service instances.
        /// </summary>
        public Func<IMyServiceProvider, object>? ImplementationFactory { get; }
        #endregion

        #region Constructors

        public MyServiceDescriptor(Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
             ServiceLifetime lifetime) : this(serviceType, lifetime)
        {

            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(implementationType);

            ImplementationType = implementationType;
        }

        private MyServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
        }

        public MyServiceDescriptor(Type serviceType, object instance) : this(serviceType, ServiceLifetime.Singleton)
        {
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(instance);

            ImplementationInstance = instance;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ServiceDescriptor"/> with the specified <paramref name="factory"/>.
        /// </summary>
        /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
        /// <param name="factory">A factory used for creating service instances.</param>
        /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
        public MyServiceDescriptor(
            Type serviceType,
            Func<IMyServiceProvider, object> factory,
            ServiceLifetime lifetime)
            : this(serviceType, lifetime)
        {
            ThrowHelper.ThrowIfNull(serviceType);
            ThrowHelper.ThrowIfNull(factory);

            ImplementationFactory = factory;
        }

        #endregion

    }
}
