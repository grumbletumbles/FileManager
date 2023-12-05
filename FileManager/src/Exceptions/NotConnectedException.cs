namespace FileManager.Exceptions;

public class NotConnectedException : Exception
{
    public NotConnectedException(string message)
        : base(message) { }

    public NotConnectedException()
    { }

    public NotConnectedException(string message, Exception innerException)
        : base(message, innerException) { }
}