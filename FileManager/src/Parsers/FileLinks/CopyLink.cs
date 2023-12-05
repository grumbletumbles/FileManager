﻿using FileManager.Commands;
using FluentChaining;

namespace FileManager.Parsers.FileLinks;

public class CopyLink : ILink<Arguments, ICommand?>
{
    public ICommand? Process(Arguments request, SynchronousContext context, LinkDelegate<Arguments, SynchronousContext, ICommand?> next)
    {
        if (request.Positional is not ["copy", _, _])
            return next(request, context);

        return new CopyCommand(request.Positional[1], request.Positional[2]);
    }
}