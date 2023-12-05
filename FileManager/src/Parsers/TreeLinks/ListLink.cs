using System.Globalization;
using FileManager.Commands;
using FluentChaining;

namespace FileManager.Parsers.TreeLinks;

public class ListLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(Arguments request, SynchronousContext context, LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["list"])
            return next(request, context);

        var depth = 1;
        request.Flags.TryGetValue("-d", out var depthString);
        if (depthString is not null)
            depth = int.Parse(depthString, CultureInfo.InvariantCulture);

        return new TreeListCommand(depth);
    }
}