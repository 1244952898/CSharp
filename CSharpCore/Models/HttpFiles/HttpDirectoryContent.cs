using Microsoft.Extensions.FileProviders;
using System.Collections;

namespace CSharpCore.Models.HttpFiles
{
    public class HttpDirectoryContent : IDirectoryContents
    {
        public bool Exists { get; }
        private readonly IEnumerable<IFileInfo> _fileInfos;

        public HttpDirectoryContent(HttpDirectoryContentsDescriptor descriptor, HttpClient httpClient)
        {
            Exists = descriptor.Exsits;
            _fileInfos = descriptor.FileDescriptors.Select(file => file.ToFileInfo(httpClient));
        }

        public IEnumerator<IFileInfo> GetEnumerator() => _fileInfos.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _fileInfos.GetEnumerator();
    }
}
