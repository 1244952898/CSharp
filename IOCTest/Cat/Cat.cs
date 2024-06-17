using System.Collections.Concurrent;

namespace IOCTest.Cat
{
    public class Cat : IServiceProvider, IDisposable
    {
        internal readonly Cat _root;
        internal readonly ConcurrentDictionary<Type, ServiceRegistry> _registries;
        private readonly ConcurrentDictionary<Key, object> _services;
        private readonly ConcurrentBag<IDisposable> _disposables;
        private volatile bool _disposed;

        public Cat()
        {
            _root = this;
            _registries = new ConcurrentDictionary<Type, ServiceRegistry>();
            _services = new ConcurrentDictionary<Key, object>();
            _disposables = new ConcurrentBag<IDisposable>();
        }

        internal Cat(Cat root)
        {
            _root = root._root;
            _registries = root._registries;
            _services = new ConcurrentDictionary<Key, object>();
            _disposables = new ConcurrentBag<IDisposable>();
        }

        public Cat Register(ServiceRegistry registry)
        {
            //EnsureNotDisposed();
            if (_registries.TryGetValue(registry.ServiceType, out var existing))
            {
                _registries[registry.ServiceType] = registry;
                registry.next = existing;
            }
            else
            {
                _registries[registry.ServiceType] = registry;
            }
            return this;
        }
        public void Dispose()
        {
            _disposed = true;
            foreach(var disposed in _disposables)
            {
                disposed.Dispose();
            }
            _disposables.Clear();
            _services.Clear();
        }

        public object GetService(Type serviceType)
        {
            //EnsureNotDisposed();
            if (serviceType == typeof(Cat) || serviceType == typeof(IServiceProvider))
            {
                return this;
            }
            ServiceRegistry registry;
            if (serviceType.IsGenericType && serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                var elementType = serviceType.GetGenericArguments()[0];
                if (!_registries.TryGetValue(elementType, out registry))
                {
                    return Array.CreateInstance(elementType, 0);
                }
                var registries = registry.AsEnumerable();
                var services = registries.Select(x => GetServiceCore(x, Type.EmptyTypes)).ToArray();
                Array array = Array.CreateInstance(elementType, services.Length);
                services.CopyTo(array, 0);
                return array;
            }

            if (serviceType.IsGenericType && !_registries.ContainsKey(serviceType))
            {
                var definition = serviceType.GetGenericTypeDefinition();
                return _registries.TryGetValue(definition, out registry) ?
                    GetServiceCore(registry, serviceType.GetGenericArguments()) : null;
            }

            return _registries.TryGetValue(serviceType, out registry) ? GetServiceCore(registry, serviceType.GetGenericArguments()) : null;
        }

        private object GetServiceCore(ServiceRegistry registry, Type[] genericArguments)
        {
            var key = new Key(registry, genericArguments);
            var serviceType = registry.ServiceType;
            switch (registry.Lifetime)
            {
                case CatLifetime.Root:
                    return GetOrCreate(_root._services, _root._disposables);
                case CatLifetime.Self:
                    return GetOrCreate(_services, _disposables);
                default:
                    var service = registry.Factory(this, genericArguments);
                    if (service is IDisposable disposable && disposable != this)
                    {
                        _disposables.Add(disposable);
                    }
                    return service;
            }

            object GetOrCreate(ConcurrentDictionary<Key, object> services, ConcurrentBag<IDisposable> disposables)
            {
                if (services.TryGetValue(key, out var service))
                {
                    return service;
                }
                service = registry.Factory(this, genericArguments);
                services[key] = service;
                if (service is IDisposable disposable)
                {
                    _disposables.Add(disposable);
                }
                return service;
            }
        }
    }
}
