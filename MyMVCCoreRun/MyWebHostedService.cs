using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Hosting;

namespace MyMVCCoreRun
{
    public class MyWebHostedService : IHostedService
    {
        private readonly IServer _server;
        private readonly MyRequestDelegate _hander;

        public MyWebHostedService(IServer server, MyRequestDelegate hander)
        {
            _server = server;
            _hander = hander;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            IHttpApplication
            return _server.StartAsync(new RequestDelegate());
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _server.StopAsync(cancellationToken);
            return Task.CompletedTask;
        }
    }
}
