using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore.Models.HttpFiles
{
    internal interface IFileManager
    {
        void ShowStructor(Action<int, string> render);

        Task<string> ReadAllTextAsync(string path);
    }
}
