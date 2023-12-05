using FileManager.Exceptions;
using FileManager.FileSystems;

namespace FileManager.Contexts;

public class Context : IContext
{
    public Context(string currentPath)
    {
        CurrentPath = currentPath;
    }

    public IFileSystem? FileSystem { get; private set; }
    public string CurrentPath { get; private set; }

    public string GetFullPath(string path)
    {
        if (string.IsNullOrEmpty(CurrentPath))
        {
            throw new NotConnectedException(nameof(CurrentPath));
        }

        if (Path.IsPathRooted(path))
            return path;
        return Path.Combine(CurrentPath, path);
    }

    public void UpdateCurrentPath(string path)
    {
        CurrentPath = path;
    }

    public void Connect(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void Disconnect()
    {
        CurrentPath = string.Empty;
        FileSystem = null;
    }
}