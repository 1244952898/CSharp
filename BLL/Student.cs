using IBLL;
using IDAL;
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

    }
}
