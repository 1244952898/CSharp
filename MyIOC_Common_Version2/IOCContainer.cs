using MyIOC_Common_Version2.Attriutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyIOC_Common_Version2
{
    /// <summary>
    /// IOC容器
    /// </summary>
    public class IOCContainer : IIOCContainer
    {

        #region 字段或者属性

        /// <summary>
        /// 保存注册信息
        /// </summary>
        private readonly Dictionary<string, IOCContainerRegistModel> _containerDictionary = new Dictionary<string, IOCContainerRegistModel>();

        /// <summary>
        /// 保存常量的值
        /// </summary>
        private readonly Dictionary<string, object[]> _containerValueDictionary = new Dictionary<string, object[]>();

        /// <summary>
        /// 作用域单例的对象
        /// </summary>
        private readonly Dictionary<string, object> _containerScopeDictionary = new Dictionary<string, object>();

        #endregion

        #region 构造函数

        /// <summary>
        /// 无参构造行数
        /// </summary>
        public IOCContainer()
        {

        }

        /// <summary>
        /// 主要在创建子容器的时候使用
        /// </summary>
        public IOCContainer(Dictionary<string, IOCContainerRegistModel> containerDictionary,
            Dictionary<string, object[]> containerValueDictionary, Dictionary<string, object> containerScopeDictionary)
        {
            this._containerDictionary = containerDictionary;
            this._containerValueDictionary = containerValueDictionary;
            this._containerScopeDictionary = containerScopeDictionary;
        }

        #endregion

        /// <summary>
        /// 创建子容器
        /// </summary>
        /// <returns></returns>
        public IIOCContainer CreateChildContainer()
        {
            return new IOCContainer(this._containerDictionary, this._containerValueDictionary, new Dictionary<string, object>());
        }

        /// <summary>
        /// 获取键
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="shortName"></param>
        /// <returns></returns>
        private string GetKey(string fullName, string shortName)
        {
            return $"{fullName}___{shortName}"; 
        }

        /// <summary>
        /// 加个参数区分生命周期--而且注册关系得保存生命周期
        /// </summary>
        /// <typeparam name="TFrom">要添加的服务的类型</typeparam>
        /// <typeparam name="TTo">要使用的实现的类型</typeparam>
        /// <param name="shortName">简称（别名）（主要用于解决单接口多实现）</param>
        /// <param name="paraList">常量参数</param>
        /// <param name="lifetimeType">生命周期</param>
        public void Register<IFrom, ITo>(string shortName = null, object[] paraList = null, LifetimeTypeEnum lifetimeType = LifetimeTypeEnum.Transient) where ITo : IFrom
        {
            var key = this.GetKey(typeof(IFrom).FullName, shortName);
            if (!this._containerDictionary.ContainsKey(key))
            {
                this._containerDictionary.Add(key, new IOCContainerRegistModel
                {
                    Lifetime = lifetimeType,
                    TargetType = typeof(ITo)
                });
            }
            else
            {
                this._containerDictionary[key].Lifetime = lifetimeType;
                this._containerDictionary[key].TargetType = typeof(ITo);
            }
            

            if (paraList!=null&&paraList.Length>0)
            {
                this._containerValueDictionary.Add(this.GetKey(typeof(IFrom).FullName, shortName), paraList);
            }
           
        }

        /// <summary>
        /// 递归--可以完成不限层级的对象创建
        /// </summary>
        /// <param name="abstractType"></param>
        /// <param name="shortName"></param>
        /// <returns></returns>
        private object ResolveObject(Type abstractType, string shortName = null)
        {
            string key = this.GetKey(abstractType.FullName, shortName);
            var containerRegistModel = this._containerDictionary[key];

            #region 生命周期
            switch (containerRegistModel.Lifetime)
            {
                case LifetimeTypeEnum.Transient:
                    Console.WriteLine("Transient Do Nothing Before");
                    break;
                case LifetimeTypeEnum.Singleton:
                    if (containerRegistModel.SingletonInstance!=null)
                    {
                        return containerRegistModel.SingletonInstance;
                    }
                    break;
                case LifetimeTypeEnum.Scope:
                    if (this._containerScopeDictionary.ContainsKey(key))
                    {
                        return this._containerScopeDictionary[key];
                    }
                    break;
                default:
                    break;
            }
            #endregion

            Type type = containerRegistModel.TargetType;

            #region 选择合适的构造函数

            var ctor = type.GetConstructors().FirstOrDefault(x => x.IsDefined(typeof(ConstructorInjectionAttribute), true));
            if (ctor == null)
            {
                ctor = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length).First();
            }

            #endregion

            #region 准备构造函数的参数

            List<object> paraList = new List<object>();
            //常量找出来
            object[] paraConstant = this._containerValueDictionary.ContainsKey(key) ? this._containerValueDictionary[key] : null;
            int iIndex = 0;
            foreach (var para in ctor.GetParameters())
            {
                if (para.IsDefined(typeof(ParameterConstantAttribute),true))
                {
                    paraList.Add(paraConstant[iIndex++]);
                }
                else
                {
                    Type paraType = para.ParameterType;
                    var paraShortName = GetShortName(para);
                    object paraInstance = this.ResolveObject(paraType, paraShortName);
                    paraList.Add(paraInstance);
                }
            }

            #endregion

            //创建对象，完成构造函数的注入
            object oInstance = Activator.CreateInstance(type, paraList.ToArray());

            #region 属性注入

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance).Where(p => p.IsDefined(typeof(PropertyInjectionAttribute)));
            foreach (var prop in properties)
            {
                Type propType = prop.PropertyType;
                string paraShortName = this.GetShortName(prop);
                object propInstance = this.ResolveObject(propType, paraShortName);
                prop.SetValue(oInstance, propInstance);
            }

            #endregion

            #region 方法注入

            foreach (var method in type.GetMethods().Where(m => m.IsDefined(typeof(MethodInjectionAttribute), true)))
            {
                List<object> paraInjectionList = new List<object>();
                foreach (var para in method.GetParameters())
                {
                    Type paraType = para.ParameterType;//获取参数的类型 IUserDAL
                    string paraShortName = this.GetShortName(para);
                    object paraInstance = this.ResolveObject(paraType, paraShortName);
                    paraInjectionList.Add(paraInstance);
                }
                method.Invoke(oInstance, paraInjectionList.ToArray());
            }

            #endregion

            #region 生命周期
            switch (containerRegistModel.Lifetime)
            {
                case LifetimeTypeEnum.Transient:
                    Console.WriteLine("Transient Do Nothing After");
                    break;
                case LifetimeTypeEnum.Singleton:
                    containerRegistModel.SingletonInstance = oInstance;
                    break;
                case LifetimeTypeEnum.Scope:
                    this._containerScopeDictionary[key] = oInstance;
                    break;
                default:
                    break;
            }
            #endregion

            //return oInstance.AOP(abstractType); //AOP扩展
            return oInstance;
        }

        /// <summary>
        /// 获取简称（别名）
        /// </summary>
        private string GetShortName(ICustomAttributeProvider provider)//ParameterInfo
        {
            if (provider.IsDefined(typeof(ParameterShortNameAttribute),true))
            {
                var attribute = (ParameterShortNameAttribute)provider.GetCustomAttributes(typeof(ParameterShortNameAttribute), true)[0];
                return attribute.ShortName;
            }
            return null;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        public TFrom Resolve<TFrom>(string shortName = null)
        {
            return (TFrom)this.ResolveObject(typeof(TFrom), shortName);
        }

    }
}
