using FileManager.Contexts;

namespace FileManager.Commands;

public class RenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public RenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public void Execute(IContext context)
    {
        var path = context.GetFullPath(_path);
        context.FileSystem?.RenameFile(path, _newName);
    }
}