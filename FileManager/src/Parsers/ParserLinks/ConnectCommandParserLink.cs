using FileManager.Commands;
using FileManager.Parsers.ConnectLinks;
using FluentChaining;
using Chain = FluentChaining.FluentChaining;
namespace FileManager.Parsers.ParserLinks;

public class ConnectCommandParserLink : ILink<string[], ICommand?>
{
    private readonly IChain<Arguments, ICommand?> _chain;

    public ConnectCommandParserLink()
    {
        _chain = Chain.CreateChain<Arguments, ICommand?>(
            builder => builder
                .Then<ConnectLink>()
                .Then<DisconnectLink>()
                .FinishWith(() => null));
    }

    public ICommand? Process(string[] request, SynchronousContext context, LinkDelegate<string[], SynchronousContext, ICommand?> next)
    {
        if (request[0] is "connect" or "disconnect")
        {
            var args = new Arguments();
            args.Parse(request);
            return _chain.Process(args);
        }

        return next(request, context);
    }
}