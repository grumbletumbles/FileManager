using FileManager.Contexts;

namespace FileManager.Commands;

public class CopyCommand : ICommand
{
    private readonly string _from;
    private readonly string _to;

    public CopyCommand(string from, string to)
    {
        _from = from;
        _to = to;
    }

    public void Execute(IContext context)
    {
        var from = context.GetFullPath(_from);
        context.FileSystem?.CopyFile(from, _to);
    }
}