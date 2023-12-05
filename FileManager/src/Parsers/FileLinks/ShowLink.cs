using FileManager.Commands;
using FileManager.Exceptions;
using FileManager.Printers;
using FluentChaining;

namespace FileManager.Parsers.FileLinks;

public class ShowLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(Arguments request, SynchronousContext context, LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["show", _])
            return next(request, context);

        IPrinter printer = new ConsolePrinter();
        request.Flags.TryGetValue("-m", out var mode);
        if (mode is not null)
        {
            printer = mode switch
            {
                "console" => new ConsolePrinter(),
                _ => throw new InvalidInputException(nameof(mode)),
            };
        }

        return new FilePrintCommand(request.Positional[1], printer);
    }
}