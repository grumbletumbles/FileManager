using FileManager.Contexts;

namespace FileManager.Commands;

public class MoveCommand : ICommand
{
    private readonly string _from;
    private readonly string _to;

    public MoveCommand(string from, string to)
    {
        _from = from;
        _to = to;
    }

    public void Execute(IContext context)
    {
        var from = context.GetFullPath(_from);
        context.FileSystem?.MoveFile(from, _to);
    }
}