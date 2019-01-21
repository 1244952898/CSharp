using MyAttribute.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Classes
{
    public class BaseDAL
    {
        /// <summary>
        /// 校验而且保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void Save<T>(T t)where T:new()
        {
            bool isSafe = true;
            Type type = t.GetType();
            var properties = type.GetProperties();
            foreach (var pro in properties)
            {
                var attrs = pro.GetCustomAttributes();
                foreach (var attr in attrs)
                {
                    if (attr is IntValidateAttribute)
                    {
                        var invalidate = (IntValidateAttribute)attr;
                        isSafe = invalidate.Validate((int)pro.GetValue(t));
                    }
                    if (!isSafe)
                        break;
                }
            }
            if (isSafe)
                Console.WriteLine("保存到数据库");
            else
                Console.WriteLine("数据不合法");
        }
    }
}
