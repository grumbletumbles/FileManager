using FileManager.Commands;

namespace FileManager.Parsers;

public interface IParser
{
    ICommand? Parse(string input);
}