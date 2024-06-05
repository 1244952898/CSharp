namespace MyServiceCollection
{
    public interface IMyServiceScope : IDisposable
    {
        /// <summary>
        /// The <see cref="System.IServiceProvider"/> used to resolve dependencies from the scope.
        /// </summary>
        IMyServiceProvider ServiceProvider { get; }
    }
}
