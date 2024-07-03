namespace MyServiceCollection
{
    public static class ThrowHelper
    {
        public static void ThrowIfNull(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
        }
    }
}
