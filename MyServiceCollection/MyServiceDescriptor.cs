using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region Constructors

        public MyServiceDescriptor(Type serviceType,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type implementationType,
             ServiceLifetime lifetime) : this(serviceType, lifetime)
        {
            
            //ThrowHelper.ThrowIfNull(serviceType);
            //ThrowHelper.ThrowIfNull(implementationType);

            ImplementationType = implementationType;
        }

        private MyServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
        }

        #endregion

    }
}
