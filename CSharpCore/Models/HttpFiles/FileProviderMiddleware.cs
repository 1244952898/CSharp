using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace CSharpCore.Models.HttpFiles
{
    public class FileProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IFileProvider _fileProvider;

        public FileProviderMiddleware(RequestDelegate next, string root)
        {
            _next = next;
            _fileProvider = new PhysicalFileProvider(root);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("dir-meta"))
            {
                var dirContents = _fileProvider.GetDirectoryContents(context.Request.Path);
                var dirDescriptor = new HttpDirectoryContentsDescriptor(dirContents, CreatePhysicalPathResolver(context, true));
                await context.Response.WriteAsync(JsonConvert.SerializeObject(dirDescriptor));
            }
            else if (context.Request.Query.ContainsKey("file-meta"))
            {
                var fileInfo = _fileProvider.GetFileInfo(context.Request.Path);
                var fileDescriptor = new HttpFileDescriptor(fileInfo, CreatePhysicalPathResolver(context, false));
                await context.Response.WriteAsync(JsonConvert.SerializeObject(fileDescriptor));
            }
            else
            {
                await context.Response.SendFileAsync(_fileProvider.GetFileInfo(context.Request.Path));
            }
        }

        public Func<string, string> CreatePhysicalPathResolver(HttpContext context, bool isDirRequest)
        {
            string schema = context.Request.IsHttps ? "https" : "http";
            string host = context.Request.Host.Host;
            var port = context.Request.Host.Port;
            var pathBase = context.Request.PathBase.ToString().TrimEnd('/');
            var path = context.Request.Path.ToString().TrimEnd('/');

            pathBase = string.IsNullOrWhiteSpace(pathBase) ? string.Empty : $"/{pathBase}";
            path = string.IsNullOrWhiteSpace(path) ? string.Empty : $"/{path}";
            return isDirRequest ? name => $"{schema}://{host}:{port}{pathBase}{path}/{name}" : name => $"{schema}://{host}:{port}{pathBase}{path}";
        }
    }
}
