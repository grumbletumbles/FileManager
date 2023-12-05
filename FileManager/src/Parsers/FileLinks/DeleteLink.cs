using FileManager.Commands;
using FluentChaining;

namespace FileManager.Parsers.FileLinks;

public class DeleteLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(Arguments request, SynchronousContext context, LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["delete", _])
            return next(request, context);

        return new DeleteCommand(request.Positional[1]);
    }
}