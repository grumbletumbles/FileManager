using FileManager.Components;
using FileManager.Contexts;
using FileManager.Printers;
using FileManager.Visitors;

namespace FileManager.Commands;

public class TreeListCommand : ICommand
{
    private readonly IVisitor _visitor;

    public TreeListCommand(int depth = 1)
    {
        _visitor = new Visitor(new ConsolePrinter(), depth);
    }

    public void Execute(IContext context)
    {
        var node = new DirectoryNode(context.CurrentPath);
        node.Accept(_visitor);
    }
}