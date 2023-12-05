using FileManager.Components;

namespace FileManager.Visitors;

public interface IVisitor
{
    void SetDepth(int depth);
    void Visit(FileNode fileNode);
    void Visit(DirectoryNode directoryNode);
}