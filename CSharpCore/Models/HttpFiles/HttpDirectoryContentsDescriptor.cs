using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.HttpFiles
{
    public class HttpDirectoryContentsDescriptor
    {
        public bool Exsits { get; set; }
        public IEnumerable<HttpFileDescriptor> FileDescriptors { get; set; }

        public HttpDirectoryContentsDescriptor()
        {
            FileDescriptors = [];
        }

        public HttpDirectoryContentsDescriptor(IDirectoryContents directoryContents, Func<string, string> physicalPathResolver)
        {
            Exsits= directoryContents.Exists;
            FileDescriptors= directoryContents.Select(x=>new HttpFileDescriptor(x, physicalPathResolver));
        }
    }
}
