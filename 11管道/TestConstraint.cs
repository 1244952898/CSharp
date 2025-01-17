
namespace _11管道
{
    public class TestConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey,out var v) && v != null)
            {

            }
            throw new NotImplementedException();
        }
    }
}
