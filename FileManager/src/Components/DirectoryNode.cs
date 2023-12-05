using FileManager.Visitors;

namespace FileManager.Components;

public class DirectoryNode : INode
{
    public DirectoryNode(string path)
    {
        FullPath = path;
        Name = path[(path.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
    }

    public string Name { get; }
    public string FullPath { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}