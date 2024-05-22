namespace MireaHackBack.Exceptions.FileExceptions;

public class RemoveFileException : FileException
{
    public RemoveFileException() {}
    public RemoveFileException(string message) : base(message) {}
    public RemoveFileException(string message, System.Exception inner) : base(message, inner) {}
    public RemoveFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}