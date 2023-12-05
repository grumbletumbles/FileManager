using FileManager.Contexts;
using FileManager.Printers;

namespace FileManager.Commands;

public class FilePrintCommand : ICommand
{
    private readonly string _path;
    private readonly IPrinter _printer;

    public FilePrintCommand(string path, IPrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public void Execute(IContext context)
    {
        var path = context.GetFullPath(_path);
        var content = File.ReadAllText(path);
        _printer.Print(content);
    }
}