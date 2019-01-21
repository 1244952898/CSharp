using MyAttribute.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Classes
{
    public static class Extend
    {
        public static string GetTableName<T>(this T t) where T:new()
        {
            Type type = t.GetType();
            var properties = type.GetCustomAttributes(true);
            foreach (var pro in properties)
            {
                if (pro is TableAttribute)
                {
                    TableAttribute tableAttribute = (TableAttribute)pro;
                    return tableAttribute.GetTableName();
                }
            }
            return type.Name;
        }
    }
}
