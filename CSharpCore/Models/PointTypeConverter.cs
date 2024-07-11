using System.ComponentModel;
using System.Globalization;

namespace CSharpCore.Models
{
    public class PointTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string);

        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var values = value.ToString().TrimStart('(').TrimEnd(')').Split(',');
            var x = double.Parse(values[0]);
            var y = double.Parse(values[1]);
            return new Point(x, y);
        }
    }
}
