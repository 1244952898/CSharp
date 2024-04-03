using Spire.Doc;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public static class SpireOfficeHelpers
    {
        /// <summary>
        /// 注入激活信息
        /// </summary>
        /// <param name="workbook"></param>
        public static void Crack(this Workbook workbook)
        {
            InjectLicense(workbook);
        }
        /// <summary>
        /// 注入激活信息
        /// </summary>
        /// <param name="document"></param>
        public static void Crack(this Document document)
        {
            InjectLicense(document);
        }
        /// <summary>
        /// 注入激活信息，并返回该类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T InjectLicense<T>(T t) where T : class
        {
            var InternalLicense = t.GetType().GetProperty("InternalLicense", BindingFlags.NonPublic | BindingFlags.Instance);
            var TypeLic = InternalLicense.PropertyType.Assembly.CreateInstance(InternalLicense.PropertyType.GetTypeInfo().FullName);
            foreach (var item in TypeLic.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (item.FieldType.IsArray)
                {
                    item.SetValue(TypeLic, new string[] { "Spire.Spreadsheet", "Spire.DocViewer.Wpf" });
                }
                else if (item.FieldType.IsEnum)
                {
                    item.SetValue(TypeLic, 3);
                }
            }
            InternalLicense.SetValue(t, TypeLic);
            return t;
        }
    }
}
