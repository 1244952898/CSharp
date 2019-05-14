using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.ElsaticSearch
{
    public class DemoES
    {
        public static async Task MethodAsync()
        {
    //        var connection = new AConnection();
    //        var connectionPool = new AConnectionPool(new Uri("http://http://120.27.213.67:9200/"));
    //        var settings = new AConnectionSettings(connectionPool, connection);
    //        //settings.IsDisposed.Should().BeFalse();
    //        //connectionPool.IsDisposed.Should().BeFalse();
    //        //connection.IsDisposed.Should().BeFalse();

    //        var lowLevelTransport = new Transport<ConnectionConfiguration>(new ConnectionConfiguration());

    //        var highlevelTransport = new Transport<ConnectionSettings>(new ConnectionSettings ());

    //        var connectionPool1 = new SingleNodeConnectionPool (new Uri ("http://http://120.27.213.67:9200"));
    //        var inMemoryTransport = new Transport < ConnectionSettings >(new ConnectionSettings (connectionPool1, new InMemoryConnection ()));

    //        var response = inMemoryTransport.Request<SearchResponse<Project>>(
    //            HttpMethod.GET,
    //            "/_search",
    //            PostData.Serializable(new { query = new { match_all = new { } } }));

    //        response = await inMemoryTransport.RequestAsync<SearchResponse<Project>>(
    //            HttpMethod.GET,
    //            "/_search",
    //            default(CancellationToken),
    //            PostData.Serializable(new { query = new { match_all = new { } } }));

    //        var pipeline = new RequestPipeline(
    //        settings,
    //        DateTimeProvider.Default,
    //        new MemoryStreamFactory(),
    //        new SearchRequestParameters());
    //        pipeline.GetType().Should().Implement<IDisposable>();

    //        var requestPipelineFactory = new RequestPipelineFactory();
    //        var requestPipeline = requestPipelineFactory.Create(
    //            settings,
    //            DateTimeProvider.Default,
    //            new MemoryStreamFactory(),
    //            new SearchRequestParameters());

    //        requestPipeline.Should().BeOfType<RequestPipeline>();
    //        requestPipeline.GetType().Should().Implement<IDisposable>();

    //        var transport = new Transport<IConnectionSettingsValues>(
    //        settings,
    //        requestPipelineFactory,
    //        DateTimeProvider.Default,
    //        new MemoryStreamFactory());

    //        var client = new ElasticClient(transport);

    //        var singleNodePipeline = CreatePipeline(uris => new SingleNodeConnectionPool(uris.First()));
    //        var staticPipeline = CreatePipeline(uris => new StaticConnectionPool(uris));
    //        var sniffingPipeline = CreatePipeline(uris => new SniffingConnectionPool(uris));

    //        var inMemoryConnection = new WaitingInMemoryConnection(
    //TimeSpan.FromSeconds(1),
    //responseBody);
        }
    }

    class AConnectionSettings : ConnectionSettings
    {
        public AConnectionSettings(IConnectionPool connectionPool, IConnection connection) : base(connectionPool, connection)
        {
        }

        public bool IsDisposed { get; private set; }

        protected override void DisposeManagedResources()
        {
            this.IsDisposed = true;
            base.DisposeManagedResources();
        }
    }

    class AConnectionPool : SingleNodeConnectionPool
    {
        public AConnectionPool(Uri uri, IDateTimeProvider dateTimeProvider = null) : base(uri, dateTimeProvider)
        {
        }

        public bool IsDisposed { get; private set; }

        protected override void DisposeManagedResources()
        {
            this.IsDisposed = true;
            base.DisposeManagedResources();
        }
    }

    class AConnection : InMemoryConnection
    {
        public bool IsDisposed { get; private set; }

        protected override void DisposeManagedResources()
        {
            this.IsDisposed = true;
            base.DisposeManagedResources();
        }
    }
}
