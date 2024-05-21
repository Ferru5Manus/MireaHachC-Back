namespace MireaHackBack.Exceptions.FileExceptions;


public class RemoveDirectoryException : Exception
{
    public RemoveDirectoryException() {}
    public RemoveDirectoryException(string message) : base(message) {}
    public RemoveDirectoryException(string message, System.Exception inner) : base(message, inner) {}
    public RemoveDirectoryException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}