public class FileException : System.Exception
{
    public FileException() {}
    public FileException(string message) : base(message) {}
    public FileException(string message, System.Exception inner) : base(message, inner) {}
    public FileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}