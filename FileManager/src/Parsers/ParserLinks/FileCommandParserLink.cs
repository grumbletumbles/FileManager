using FileManager.Commands;
using FileManager.Parsers.FileLinks;
using FluentChaining;
using Chain = FluentChaining.FluentChaining;
namespace FileManager.Parsers.ParserLinks;

public class FileCommandParserLink : ILink<string[], ICommand?>
{
    private readonly IChain<Arguments, ICommand?> _chain;

    public FileCommandParserLink()
    {
        _chain = Chain.CreateChain<Arguments, ICommand?>(
            builder => builder
                .Then<CopyLink>()
                .Then<DeleteLink>()
                .Then<MoveLink>()
                .Then<RenameLink>()
                .Then<ShowLink>()
                .FinishWith(() => null));
    }

    public ICommand? Process(string[] request, SynchronousContext context, LinkDelegate<string[], SynchronousContext, ICommand?> next)
    {
        if (request[0] is "file")
        {
            var args = new Arguments();
            args.Parse(request[1..]);
            return _chain.Process(args);
        }

        return next(request, context);
    }
}