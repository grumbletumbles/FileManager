using FileManager.Contexts;
using FileManager.Exceptions;

namespace FileManager.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(IContext context)
    {
        if (context.FileSystem is null)
            throw new NotConnectedException(nameof(context));

        context.Disconnect();
    }
}