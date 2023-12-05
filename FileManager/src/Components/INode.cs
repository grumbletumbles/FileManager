using FileManager.Visitors;

namespace FileManager.Components;

public interface INode
{
    public string Name { get; }
    public string FullPath { get; }
    public void Accept(IVisitor visitor);
}