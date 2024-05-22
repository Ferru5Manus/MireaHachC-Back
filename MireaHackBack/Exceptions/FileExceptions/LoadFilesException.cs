public class LoadFilesException : FileException
{
    public LoadFilesException() {}
    public LoadFilesException(string message) : base(message) {}
    public LoadFilesException(string message, System.Exception inner) : base(message, inner) {}
    public LoadFilesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}