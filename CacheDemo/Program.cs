using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.net高级班vip课程，今天是Eleven老师为大家带来的缓存的学习");
                for (int i = 0; i < 5; i++)
                {
                    //List<Program> programs = DBHelper.Query<Program>();
                }
                for (int i = 0; i < 5; i++)
                {
                    if (CacheManager.Contains("RemoteHelper"))
                    {
                        List<Program> programs = CacheManager.GetData<List<Program>>("RemoteHelper");
                    }
                    else
                    {
                        List<Program> programs = RemoteHelper.Query<Program>();
                        CacheManager.Add("RemoteHelper", programs);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            Console.ReadKey();
        }
    }
}
