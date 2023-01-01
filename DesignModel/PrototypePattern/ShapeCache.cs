using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.PrototypePattern
{
    internal class ShapeCache
    {
        public static Dictionary<int, Shape> dics= new Dictionary<int, Shape>();
        public static void LoadCache()
        {
            var circle = new Circle
            {
                Id = 0
            };
            dics.Add(circle.Id, circle);

            var rectangle = new Rectangle
            {
                Id = 1
            };
            dics.Add(rectangle.Id, rectangle);

            var square = new Square
            {
                Id = 2
            };
            dics.Add(square.Id, square);
        }

        public static Shape GetShape(int id)
        {
            if (dics.ContainsKey(id))
            {
                var shape = dics[id];
                return (Shape)shape.Clone();
            }
            return null;
        }
    }
}
