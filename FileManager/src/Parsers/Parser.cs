using FileManager.Commands;
using FluentChaining;

namespace FileManager.Parsers;

using Chain = FluentChaining.FluentChaining;

public class Parser : IParser
{
    private readonly IChain<string[], ICommand?> _chain;

    public Parser()
    {
        _chain = Chain.CreateChain<string[], ICommand?>(
            builder => builder
                .Then<ConnectCommandParserLink>()
                .Then<FileCommandParserLink>()
                .Then<TreeCommandParserLink>()
                .FinishWith(() => null));
    }

    public ICommand? Parse(string input)
    {
        var tokens = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        return _chain.Process(tokens);
    }
}