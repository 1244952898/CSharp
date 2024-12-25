using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_文件系统
{
    internal class MyEnumMethod
    {
        public void Test(MyEnum myEnum)
        {
            try
            {
                Console.WriteLine(myEnum.ToString());
                Console.WriteLine("---------------------");
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }
    }
}
