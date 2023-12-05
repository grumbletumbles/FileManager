using System.Text;
using FileManager.Components;
using FileManager.Exceptions;
using FileManager.Printers;

namespace FileManager.Visitors;

public class Visitor : IVisitor
{
    private readonly IPrinter _printer;
    private readonly string _sep;
    private readonly string _fileSymbol;
    private readonly string _directorySymbol;
    private int _depth;
    private int _shift;

    public Visitor(
        IPrinter printer,
        int depth,
        string sep = "    ",
        string fileSymbol = "file: ",
        string directorySymbol = "dir: ")
    {
        _printer = printer;
        _shift = 0;
        _depth = depth;
        _sep = sep;
        _fileSymbol = fileSymbol;
        _directorySymbol = directorySymbol ?? throw new ArgumentNullException(nameof(directorySymbol));
    }

    public void SetDepth(int depth)
    {
        _depth = depth;
    }

    public void Visit(FileNode fileNode)
    {
        if (fileNode is null)
            throw new ArgumentNullException(nameof(fileNode));
        _printer.Print(Format(fileNode));
    }

    public void Visit(DirectoryNode directoryNode)
    {
        if (directoryNode is null)
            throw new ArgumentNullException(nameof(directoryNode));
        var dirs = new List<string>(Directory.EnumerateDirectories(directoryNode.FullPath));

        foreach (DirectoryNode dirNode in dirs.Select(dir => new DirectoryNode(dir)))
        {
            _printer.Print(Format(dirNode));

            _depth--;
            if (_depth > 0)
            {
                _shift++;
                Visit(dirNode);
                _shift--;
            }

            _depth++;
        }

        var files = new List<string>(Directory.EnumerateFiles(directoryNode.FullPath));
        foreach (string file in files)
        {
            _printer.Print(Format(new FileNode(file)));
        }
    }

    private string Format(INode node)
    {
        var sb = new StringBuilder();
        sb.Insert(0, _sep, _shift);

        switch (node)
        {
            case FileNode:
                sb.Append(_fileSymbol);
                break;
            case DirectoryNode:
                sb.Append(_directorySymbol);
                break;
            default:
                // how did you end up here?
                throw new UnexpectedDirectoryContentException(nameof(node));
        }

        sb.Append(node.Name);
        return sb.ToString();
    }
}