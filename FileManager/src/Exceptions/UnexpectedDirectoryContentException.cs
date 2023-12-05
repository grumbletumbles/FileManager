namespace FileManager.Exceptions;

public class UnexpectedDirectoryContentException : Exception
{
    public UnexpectedDirectoryContentException(string message)
        : base(message) { }

    public UnexpectedDirectoryContentException()
    { }

    public UnexpectedDirectoryContentException(string message, Exception innerException)
        : base(message, innerException) { }
}