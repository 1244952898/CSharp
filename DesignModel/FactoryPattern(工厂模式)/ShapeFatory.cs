namespace DesignModel.FactoryPattern_工厂模式_
{
    internal class ShapeFatory
    {
        public static IShape GetShape(int type)
        {
            IShape shape = type switch
            {
                0 => new Circle(),
                1 => new Square(),
                _ => new Rectangle(),
            };
            return shape;
        }
    }
}
