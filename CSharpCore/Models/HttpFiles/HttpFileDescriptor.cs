using Microsoft.Extensions.FileProviders;

namespace CSharpCore.Models.HttpFiles
{
    public class HttpFileDescriptor
    {
        public bool Exsits { get; set; }
        public bool IsDirectory { get; set; }
        public DateTimeOffset LastModify { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public string PhysicalPath { get; set; }

        public HttpFileDescriptor()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <param name="physicalPathResolver"></param>
        public HttpFileDescriptor(IFileInfo fileInfo, Func<string, string> physicalPathResolver)
        {
            Exsits = fileInfo.Exists;
            IsDirectory = fileInfo.IsDirectory;
            LastModify = fileInfo.LastModified;
            Length = fileInfo.Length;
            Name = fileInfo.Name;
            PhysicalPath = physicalPathResolver(fileInfo.Name);
        }

        public IFileInfo ToFileInfo(HttpClient httpClient) => this.Exsits ? new HttpFileInfo(this, httpClient) : new NotFoundFileInfo(this.Name);
    }
}
