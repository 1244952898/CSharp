namespace MyServiceCollection
{
    public class MyAsyncServiceScope : IMyServiceScope, IAsyncDisposable
    {
        private readonly IMyServiceScope _serviceScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncServiceScope"/> struct.
        /// Wraps an instance of <see cref="IServiceScope" />.
        /// </summary>
        /// <param name="serviceScope">The <see cref="IServiceScope"/> instance to wrap.</param>
        public MyAsyncServiceScope(IMyServiceScope serviceScope)
        {
            ThrowHelper.ThrowIfNull(serviceScope);

            _serviceScope = serviceScope;
        }

        /// <inheritdoc />
        public IMyServiceProvider ServiceProvider => _serviceScope.ServiceProvider;

        /// <inheritdoc />
        public void Dispose()
        {
            _serviceScope.Dispose();
        }

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            if (_serviceScope is IAsyncDisposable ad)
            {
                return ad.DisposeAsync();
            }
            _serviceScope.Dispose();

            // ValueTask.CompletedTask is only available in net5.0 and later.
            return default;
        }
    }
}
