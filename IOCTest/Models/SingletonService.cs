namespace IOCTest.Models
{
    public class SingletonService(IServiceProvider serviceProvider)
    {
        public IServiceProvider ApplicationService { get; } = serviceProvider;
    }
}
