using FileManager.Commands;
using FluentChaining;

namespace FileManager.Parsers.ConnectLinks;

public class ConnectLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(Arguments request, SynchronousContext context, LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        request.Flags.TryGetValue("-m", out var mode);
        if (mode is not null and not "local")
            return next(request, context);
        if (request.Positional is not ["connect", _])
            return next(request, context);

        return new ConnectLocalCommand(request.Positional[1]);
    }
}