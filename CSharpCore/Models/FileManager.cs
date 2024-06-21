using Microsoft.Extensions.FileProviders;
using System;
using System.Linq;
using System.Text;

namespace CSharpCore.Models
{
    public class FileManager : IFileManager
    {
        private readonly IFileProvider _fileProvider;

        public FileManager(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public async Task<string> ReadAllTextAsync(string path)
        {
            using var stream = _fileProvider.GetFileInfo(path).CreateReadStream();
            var buffers=new byte[stream.Length];
            await stream.ReadAsync(buffers,0, buffers.Length);
            return Encoding.Default.GetString(buffers);
        }

        public void ShowStructor(Action<int, string> render)
        {
            Render(string.Empty, -1);
            void Render(string subPath, int index)
            {
                index++;
                var files = _fileProvider.GetDirectoryContents(subPath);
                foreach (var fileinfo in files)
                {
                    render(index, fileinfo.Name);
                    if (fileinfo.IsDirectory)
                    {
                        Render($@"{subPath}\{fileinfo.Name}".TrimStart('\\'), index);
                    }
                }
            }
        }


    }
}
