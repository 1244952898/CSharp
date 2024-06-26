using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.HttpFiles
{
    public class HttpFileInfo: IFileInfo
    {
        private readonly HttpClient httpClient;

        public bool Exists{ get; set; }

        public bool IsDirectory { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string PhysicalPath { get; set; }

        public Stream CreateReadStream()
        {
            var message=httpClient.GetAsync(new Uri(PhysicalPath)).Result;
            return message.Content.ReadAsStream();
        }
        public HttpFileInfo(HttpFileDescriptor httpFileDescriptor, HttpClient httpClient)
        {
            Exists = httpFileDescriptor.Exsits;
            IsDirectory = httpFileDescriptor.IsDirectory;
            LastModified = httpFileDescriptor.LastModify;
            Length = httpFileDescriptor.Length;
            Name = httpFileDescriptor.Name;
            PhysicalPath = httpFileDescriptor.PhysicalPath;
            this.httpClient = httpClient;
        }
    }
}
