using FileManager.FileSystems;

namespace FileManager.Contexts;

public interface IContext
{
    string CurrentPath { get; }
    IFileSystem? FileSystem { get; }
    string GetFullPath(string path);
    void UpdateCurrentPath(string path);
    void Connect(IFileSystem fileSystem);
    void Disconnect();
}