using FileManager.Commands;
using FluentChaining;

namespace FileManager.Parsers.ConnectLinks;

public class DisconnectLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(Arguments request, SynchronousContext context, LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["disconnect"])
            return next(request, context);

        return new DisconnectCommand();
    }
}