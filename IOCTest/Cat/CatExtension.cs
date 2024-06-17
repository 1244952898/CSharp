using System.Reflection;

namespace IOCTest.Cat
{
    public static class CatExtension
    {
        public static Cat Register(this Cat cat, Type from, Type to, CatLifetime catLifeTime)
        {
            Func<Cat, Type[], object> factory = (_, arguments) =>
            {
                return Create(_, to, arguments);
            };
            cat.Register(new ServiceRegistry(from, catLifeTime, factory));
            return cat;
        }

        public static Cat Register<From, To>(this Cat cat, CatLifetime catLifeTime) where To : From
        {
            return cat.Register(typeof(From), typeof(To), catLifeTime);
        }
        public static Cat Register(this Cat cat, Type serviceType, object instance)
        {
            object factory(Cat _, Type[] arguments) => instance;
            cat.Register(new ServiceRegistry(serviceType, CatLifetime.Root, factory));
            return cat;
        }

        public static Cat Register<TServiceType>(this Cat cat, TServiceType instance)
        {
            object factory(Cat _, Type[] arguments) => instance;
            cat.Register(new ServiceRegistry(typeof(TServiceType), CatLifetime.Root, factory));
            return cat;
        }

        public static Cat Register(this Cat cat, Type serviceType, Func<Cat, object> factory, CatLifetime catLifeTime)
        {
            cat.Register(new ServiceRegistry(serviceType, catLifeTime, (_, arguments) => factory(_)));
            return cat;
        }

        public static Cat Register<TServiceType>(this Cat cat, Func<Cat, object> factory, CatLifetime catLifeTime)
        {
            cat.Register(new ServiceRegistry(typeof(TServiceType), catLifeTime, (_, arguments) => factory(_)));
            return cat;
        }

        public static Cat Register(this Cat cat, Assembly assembly)
        {
            var typeAttributes = from type in assembly.GetExportedTypes()
                                 let attribute = type.GetCustomAttribute<MapToAttribute>()
                                 where attribute != null
                                 select new { ServiceType = type, Attribute = attribute };
            foreach (var typeAttribute in typeAttributes)
            {
                cat.Register(typeAttribute.Attribute.ServiceType, typeAttribute.ServiceType, typeAttribute.Attribute.Lifetime);
            }
            return cat;
        }

        public static T GetService<T>(this Cat cat) => (T)cat.GetService(typeof(T));
        public static IEnumerable<T> GetServices<T>(this Cat cat)
        {
            return cat.GetService<IEnumerable<T>>();
        }

        public static Cat CreateChildren(this Cat cat) => new(cat);

        private static object Create(Cat cat, Type type, Type[] genericArguments)
        {
            if (genericArguments.Length > 0)
            {
                type = type.MakeGenericType(genericArguments);
            }
            var constructors = type.GetConstructors();
            if (constructors.Length <= 0)
            {
                throw new InvalidOperationException("GetConstructors is not exsit");
            }
            var constructor = constructors.FirstOrDefault(c => c.GetCustomAttributes(false).OfType<InjectionAttribute>().Any());
            constructor ??= constructors.First();
            var parameters = constructor.GetParameters();
            if (parameters.Length == 0)
            {
                return Activator.CreateInstance(type);
            }
            var arguments = new object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                arguments[i] = cat.GetService(parameters[i].ParameterType);
            }
            return constructor.Invoke(arguments);
        }
    }
}
