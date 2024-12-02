using Microsoft.Extensions.FileProviders;
using System.Text;

namespace _5_文件系统
{
    internal class FileManager : IFileManager
    {
        private IFileProvider _fileProvider;
        public FileManager(IFileProvider fileProvider) => _fileProvider = fileProvider;

        public async Task<string> ReadAllTextAsync(string path)
        {
            byte[] bytes;
            using (var stream = _fileProvider.GetFileInfo(path).CreateReadStream())
            {
                bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, bytes.Length);
            }
            return Encoding.Default.GetString(bytes);
        }

        public void ShowStructure(Action<int, string> render)
        {
            var index = -1;
            Render("");
            void Render(string subPath)
            {
                index++;
                foreach (var fileInfo in _fileProvider.GetDirectoryContents(subPath))
                {
                    render(index, fileInfo.Name);
                    if (fileInfo.IsDirectory)
                    {
                        Render($@"{subPath}/{fileInfo.Name}".TrimStart('\\'));
                        index--;
                    }
                }
            }
        }

    }
}
