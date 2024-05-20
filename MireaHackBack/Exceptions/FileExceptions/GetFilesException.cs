public class GetFilesException : FileException
{
    public GetFilesException() {}
    public GetFilesException(string message) : base(message) {}
    public GetFilesException(string message, System.Exception inner) : base(message, inner) {}
    public GetFilesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}