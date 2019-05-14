using Elasticsearch.Net;
using System;
namespace CSharp.ElsaticSearch
{
    public class ElasticLowLevelClientDemo
    {
        public static void MainMethod()
        {
            try
            {
                //var lowlevelClient = new ElasticLowLevelClient();

                var settings = new ConnectionConfiguration(new Uri("http://120.27.213.67:9200")).RequestTimeout(TimeSpan.FromMinutes(2));
                //var lowlevelClient = new ElasticLowLevelClient(settings);

                //var uris = new[]{new Uri("http://120.27.213.67:9200"),};
                //var connectionPool = new SniffingConnectionPool(uris);
                //var settings = new ConnectionConfiguration(connectionPool);
                var lowlevelClient = new ElasticLowLevelClient(settings);

                var person = new Person { FirstName = "Martijn", LastName = "Laarman" };
                var indexResponse = lowlevelClient.Index<StringResponse>("people", "person", "1", PostData.Serializable(person));
                string responseBytes = indexResponse.Body;
                //var asyncIndexResponse = await lowlevelClient.IndexAsync<StringResponse>("people", "person", "1", PostData.Serializable(person));
                //string responseString = asyncIndexResponse.Body;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
