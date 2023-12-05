namespace FileManager.Exceptions;

public class InvalidInputException : Exception
{
    public InvalidInputException(string message)
        : base(message)
    { }

    public InvalidInputException()
    { }

    public InvalidInputException(string message, Exception innerException)
        : base(message, innerException)
    { }
}