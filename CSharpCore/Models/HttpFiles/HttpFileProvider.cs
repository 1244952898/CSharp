using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CSharpCore.Models.HttpFiles
{
    public class HttpFileProvider : IFileProvider
    {
        private readonly string _baseAddress;
        private readonly HttpClient _httpClient;

        public HttpFileProvider(string baseAddress)
        {
            _baseAddress = baseAddress.TrimEnd('/');
            _httpClient = new HttpClient();
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            var url = $"{_baseAddress}/{subpath.TrimStart('/')}?dir-meta";
            var content= _httpClient.GetStringAsync(url).Result;
            var directory = JsonConvert.DeserializeObject<HttpDirectoryContentsDescriptor>(content);
            return new HttpDirectoryContent(directory, _httpClient);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var url = $"{_baseAddress}/{subpath.TrimStart('/')}?dir-meta";
            var content = _httpClient.GetStringAsync(url).Result;
            var descriptor = JsonConvert.DeserializeObject<HttpFileDescriptor>(content);
            return descriptor?.ToFileInfo(_httpClient) ?? new NotFoundFileInfo("");
        }

        public IChangeToken Watch(string filter)
        {
           return NullChangeToken.Singleton;
        }
    }
}
