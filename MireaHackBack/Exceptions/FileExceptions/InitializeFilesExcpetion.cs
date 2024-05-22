public class InitializeFilesException : FileException
{
    public InitializeFilesException() {}
    public InitializeFilesException(string message) : base(message) {}
    public InitializeFilesException(string message, System.Exception inner) : base(message, inner) {}
    public InitializeFilesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}