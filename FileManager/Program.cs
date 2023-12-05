using FileManager.Commands;
using FileManager.Contexts;
using FileManager.Exceptions;
using FileManager.Parsers;

namespace FileManager;

public class Program
{
    public static void Main()
    {
        var parser = new Parser();
        var context = new Context(string.Empty);
        while (true)
        {
            Console.Write(context.CurrentPath + " ");
            var input = Console.ReadLine();
            if (input is null) continue;

            if (input == "exit")
                break;

            ICommand? command;
            try
            {
                command = parser.Parse(input);
            }
            catch (InvalidInputException)
            {
                Console.WriteLine("invalid input");
                continue;
            }

            if (command is null)
            {
                Console.WriteLine("Unknown command");
                continue;
            }

            try
            {
                command.Execute(context);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("error: access denied");
            }
            catch
            {
                Console.WriteLine("something went wrong");
            }
        }
    }
}