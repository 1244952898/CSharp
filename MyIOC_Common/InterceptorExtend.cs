using Castle.DynamicProxy;
using MyIOC_Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyIOC_Common
{
    public class InterceptorExtend: StandardInterceptor
    {
        protected override void PerformProceed(IInvocation invocation)
        {

            Console.WriteLine($"走过滤器，PerformProceed");

            #region 版本1
            //if (invocation.Method.IsDefined(typeof(LoginAttribute), true))
            //{
            //    var attribute = invocation.Method.GetCustomAttribute<LoginAttribute>();
            //    attribute.Do();
            //}
            //if (invocation.Method.IsDefined(typeof(CacheAttribute), true))
            //{
            //    var attribute = invocation.Method.GetCustomAttribute<CacheAttribute>();
            //    attribute.Do();
            //}
            //if (invocation.Method.IsDefined(typeof(ExceptionAttribute), true))
            //{
            //    var attribute = invocation.Method.GetCustomAttribute<ExceptionAttribute>();
            //    attribute.Do();
            //}
            #endregion

            #region 版本2
            Action action = () => base.PerformProceed(invocation);

            if (invocation.Method.IsDefined(typeof(AbstractAttribute), true))
            {
                var attributes = invocation.Method.GetCustomAttributes<AbstractAttribute>();
                for (int i = attributes.Count()-1; i >=0; i--)
                {
                    action = attributes.ElementAt(i).Do(action);
                }
                //foreach (var atr in attributes.Reverse())
                //{
                //    action = atr.Do(action);
                //}
            }

            action.Invoke();
            #endregion


        }
        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine($"走过滤器，PostProceed");
            base.PostProceed(invocation);
        }
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine($"走过滤器，PreProceed");
            base.PreProceed(invocation);
        }
    }
}
