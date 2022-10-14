using IBLL;
using IDAL;
using MyIOC_Common.Attributes;
using System;

namespace BLL
{
    public class Student: IStudent
    {
        public void Study()
        {
            Console.WriteLine("Study");
        }

        public void PlayPhone<T>(T t) where T:Phone
        {
            Console.WriteLine($"PlayPhone {t.Name}");
        }

        [LoginAttribute]
        [CacheAttribute]
        [ExceptionAttribute]
        public virtual void VirtualMethod()
        {
            Console.WriteLine($"走过滤器，VirtualMethod");
        }

        public void Method()
        {
            Console.WriteLine($"不走过滤器，Method");
        }

    }
}
