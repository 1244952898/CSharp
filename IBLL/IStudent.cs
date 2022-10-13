using IDAL;
using System;

namespace IBLL
{
    public interface IStudent
    {
        void Study();
        void PlayPhone<T>(T t) where T:Phone;
    }
}
