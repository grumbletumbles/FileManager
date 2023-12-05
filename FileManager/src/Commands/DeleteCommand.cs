using FileManager.Contexts;

namespace FileManager.Commands;

public class DeleteCommand : ICommand
{
    private readonly string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(IContext context)
    {
        var path = context.GetFullPath(_path);
        context.FileSystem?.DeleteFile(path);
    }
}