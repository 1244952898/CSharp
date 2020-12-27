using Elasticsearch.Net;
using ES0.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES0
{
    class Program
    {
        static void Main(string[] args)
        {
            var setting = new ConnectionConfiguration(new Uri("http://120.27.213.67:9200/")).RequestTimeout(TimeSpan.FromMinutes(2));
            //setting.BasicAuthentication("", "");
            var lowlevelClient = new ElasticLowLevelClient(setting);

            var uris = new List<Uri>
            {
                new Uri("http://localhost:9200"),
                new Uri("http://120.27.213.67:9200/"),
            };
            var connectPool = new SniffingConnectionPool(uris);
            var settings1 = new ConnectionConfiguration(connectPool);
            var lowlevelClient1 = new ElasticLowLevelClient(settings1);

            //var person = new Person
            //{
            //    FirstName = "Martijn",
            //    LastName = "Laarman"
            //};
            //var indexRespose = lowlevelClient.Index<BytesResponse>("people", "1", PostData.Serializable(person));
            //byte[] responseBytes = indexRespose.Body;

            //var asyncIndexResponse = await lowlevelClient.IndexAsync<StringResponse>("people", "1", PostData.Serializable(person));
            //string responseString = asyncIndexResponse.Body;

            //var peoples = new object[]
            //{
            //    new { index = new { _index = "people", _type = "_doc", _id = "1"  }},
            //    new { FirstName = "Martijn", LastName = "Laarman" },
            //    new { index = new { _index = "people", _type = "_doc", _id = "2"  }},
            //    new { FirstName = "Greg", LastName = "Marzouka" },
            //    new { index = new { _index = "people", _type = "_doc", _id = "3"  }},
            //    new { FirstName = "Russ", LastName = "Cam" },
            //};
            //var ndexResponse = lowlevelClient.Bulk<StringResponse>(PostData.MultiJson(peoples));
            //string responseStream = ndexResponse.Body;

            //var searchResponse = lowlevelClient.Search<StringResponse>("people", PostData.Serializable(new
            //{
            //    from = 0,
            //    size = 10,
            //    query = new
            //    {
            //        match = new
            //        {
            //            firstName = new
            //            {
            //                query = "Martijn"
            //            }
            //        }
            //    }
            //}));

            //var successful = searchResponse.Success;
            //var responseJson = searchResponse.Body;

            //var searchResponse1 = lowlevelClient.Search<BytesResponse>("people", PostData.Serializable(new { match_all = new { } }));

            //var success = searchResponse1.Success;
            //var successOrKnownError = searchResponse1.SuccessOrKnownError;
            //var exception = searchResponse1.OriginalException;
        }
    }
}
