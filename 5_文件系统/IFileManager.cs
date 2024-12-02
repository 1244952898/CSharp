namespace _5_文件系统
{
    internal interface IFileManager
    {
        void ShowStructure(Action<int, string> render);
        Task<string> ReadAllTextAsync(string path);
    }
}
