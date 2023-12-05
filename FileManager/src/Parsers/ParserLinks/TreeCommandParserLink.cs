using FileManager.Commands;
using FluentChaining;
using Chain = FluentChaining.FluentChaining;
namespace FileManager.Parsers.ParserLinks;

public class TreeCommandParserLink : ILink<string[], ICommand?>
{
    private readonly IChain<Arguments, ICommand?> _chain;

    public TreeCommandParserLink()
    {
        _chain = Chain.CreateChain<Arguments, ICommand?>(
            builder => builder
                .Then<GoToLink>()
                .Then<ListLink>()
                .FinishWith(() => null));
    }

    public ICommand? Process(string[] request, SynchronousContext context, LinkDelegate<string[], SynchronousContext, ICommand?> next)
    {
        if (request[0] is "tree")
        {
            var args = new Arguments();
            args.Parse(request[1..]);
            return _chain.Process(args);
        }

        return next(request, context);
    }
}