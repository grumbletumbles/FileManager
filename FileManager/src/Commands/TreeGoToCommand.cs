using FileManager.Contexts;

namespace FileManager.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public void Execute(IContext context)
    {
        var path = context.GetFullPath(_path);
        context.UpdateCurrentPath(path);
    }
}