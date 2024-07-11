using System;
using System.ComponentModel;
using System.Linq;

namespace CSharpCore.Models
{
    [TypeConverter(typeof(PointTypeConverter))]
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Point X:{X}-Y:{Y}";
        }
    }
}
