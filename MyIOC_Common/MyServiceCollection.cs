using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyIOC_Common
{
    public class MyServiceCollection : IMyServiceCollection
    {
        private static Dictionary<string, Type> CacheDictionary = new Dictionary<string, Type>();
        public void AddTransient<TService, TImplementation>() where TImplementation : TService
        {
            CacheDictionary.Add(typeof(TService).FullName, typeof(TImplementation));
        }

        public T GetService<T>() where T : class
        {
            #region 版本1

            //Type type = CacheDictionary[typeof(T).FullName];
            //object obj = Activator.CreateInstance(type);
            //return (T)obj;

            #endregion

            #region 版本2
            //Type type = CacheDictionary[typeof(T).FullName];
            //var ctor = type.GetConstructors().FirstOrDefault(c => c.IsDefined(typeof(SelectCtorAttribute), true));
            //if (ctor==null)
            //{
            //    ctor = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();
            //}

            //var paraList = new List<Object>();
            //foreach (ParameterInfo param in ctor.GetParameters())
            //{
            //    var paraType = CacheDictionary[param.ParameterType.FullName];
            //    var obj = Activator.CreateInstance(paraType);
            //    paraList.Add(obj);
            //}

            //var retObj= Activator.CreateInstance(type, paraList.ToArray());
            //return (T)retObj;
            #endregion

            #region 版本3
            Type type = CacheDictionary[typeof(T).FullName];
            return (T)GetService(type);
            #endregion

        }

        public object GetService(Type type)
        {
            var ctor = type.GetConstructors().FirstOrDefault(c => c.IsDefined(typeof(SelectCtorAttribute), true));
            if (ctor == null)
            {
                ctor = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();
            }

            var paraList = new List<Object>();
            foreach (ParameterInfo param in ctor.GetParameters())
            {
                var paraType = CacheDictionary[param.ParameterType.FullName];
                var obj = GetService(paraType);
                paraList.Add(obj);
            }

            var retObj = Activator.CreateInstance(type, paraList.ToArray());

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance).Where(p => p.IsDefined(typeof(PropertyInjectionAttribute)));
            if (properties != null&&properties.Any())
            {
                foreach (var proper in properties)
                {
                    var properType = CacheDictionary[proper.PropertyType.FullName];
                    var properObj = GetService(properType);
                    proper.SetValue(retObj, properObj);
                }
            }

            return retObj;
        }
    }
}
