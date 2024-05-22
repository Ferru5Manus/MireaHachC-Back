public class GetFileException : FileException
{
    public GetFileException() {}
    public GetFileException(string message) : base(message) {}
    public GetFileException(string message, System.Exception inner) : base(message, inner) {}
    public GetFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}