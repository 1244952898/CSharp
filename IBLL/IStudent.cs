using IDAL;
using MyIOC_Common.Attributes;
using System;

namespace IBLL
{
    public interface IStudent
    {
        void Study();
        void PlayPhone<T>(T t) where T:Phone;

        [LoginAttribute]
        [CacheAttribute]
        void VirtualMethod();

        void Method();
    }
}
