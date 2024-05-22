namespace MireaHackBack.Exceptions.FileExceptions;

public class CreateFileException : FileException
{
    public CreateFileException() {}
    public CreateFileException(string message) : base(message) {}
    public CreateFileException(string message, System.Exception inner) : base(message, inner) {}
    public CreateFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}