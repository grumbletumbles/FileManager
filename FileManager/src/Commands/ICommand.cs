using FileManager.Contexts;

namespace FileManager.Commands;

public interface ICommand
{
    void Execute(IContext context);
}