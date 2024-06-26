﻿using System;
using System.Linq;

namespace MyServiceCollection
{
    public interface IMySupportRequiredService
    {
        /// <summary>
        /// Gets service of type <paramref name="serviceType"/> from the <see cref="IServiceProvider"/> implementing
        /// this interface.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>A service object of type <paramref name="serviceType"/>.
        /// Throws an exception if the <see cref="IServiceProvider"/> cannot create the object.</returns>
        object GetRequiredService(Type serviceType);
    }
}
