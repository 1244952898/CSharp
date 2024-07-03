namespace IOCTest.Models
{
    public class ScopeService(IServiceProvider serviceProvider)
    {
        public IServiceProvider RequestProvider { get; } = serviceProvider;
    }
}
