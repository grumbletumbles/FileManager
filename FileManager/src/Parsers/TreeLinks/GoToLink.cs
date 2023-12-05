﻿using FileManager.Commands;
using FluentChaining;

namespace FileManager.Parsers.TreeLinks;

public class GoToLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(Arguments request, SynchronousContext context,
        LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["goto", _])
            return next(request, context);

        return new TreeGoToCommand(request.Positional[1]);
    }
}