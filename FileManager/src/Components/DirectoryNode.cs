using FileManager.Visitors;

namespace FileManager.Components;

public class DirectoryNode : INode
{
    public DirectoryNode(string path)
    {
        FullPath = path ?? throw new ArgumentNullException(nameof(path));
        Name = path[(path.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
    }

    public string Name { get; }
    public string FullPath { get; }

    public void Accept(IVisitor visitor)
    {
        if (visitor is null)
            throw new ArgumentNullException(nameof(visitor));
        visitor.Visit(this);
    }
}