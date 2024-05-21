namespace MireaHackBack.Exceptions.FileExceptions;

public class ModifyFileException : FileException
{
    public ModifyFileException() {}
    public ModifyFileException(string message) : base(message) {}
    public ModifyFileException(string message, System.Exception inner) : base(message, inner) {}
    public ModifyFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
} 
