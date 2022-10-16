using Castle.DynamicProxy;
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
            //0. 根据接口类型，获取对应的对象类型
            Type type = CacheDictionary[typeof(T).FullName];
            return (T)GetService(type);
            #endregion

        }

        public object GetService(Type type)
        {
            //1.获取定义的构造函数或者参数最多的构造函数，做为调用的构造函数
            var ctor = type.GetConstructors().FirstOrDefault(c => c.IsDefined(typeof(SelectCtorAttribute), true));
            if (ctor == null)
            {
                ctor = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();
            }

            //2.根据构造函数获取，获取构造函数所需要的参数
            var paraList = new List<Object>();
            foreach (ParameterInfo param in ctor.GetParameters())
            {
                var paraType = CacheDictionary[param.ParameterType.FullName];
                //3. 递归构造所需要的参数对象
                var obj = GetService(paraType);
                paraList.Add(obj);
            }

            //4.创建所需要返回的对象
            var retObj = Activator.CreateInstance(type, paraList.ToArray());

            //5. 递归构造需要容器自动注入的字段的对象
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

            //生成需要动态代理的对象
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            InterceptorExtend interceptorExtend = new InterceptorExtend();
            var o= proxyGenerator.CreateClassProxyWithTarget(type, retObj, interceptorExtend);

            return o;
        }
    }
}
