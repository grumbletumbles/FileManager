using FileManager.Contexts;
using FileManager.Exceptions;
using FileManager.FileSystems;

namespace FileManager.Commands;

public class ConnectLocalCommand : ICommand
{
    private readonly string _path;

    public ConnectLocalCommand(string path)
    {
        _path = path;
    }

    public void Execute(IContext context)
    {
        if (context.FileSystem is not null)
            throw new AlreadyConnectedException(nameof(context));

        context.Connect(new LocalFileSystem());
        context.UpdateCurrentPath(_path);
    }
}