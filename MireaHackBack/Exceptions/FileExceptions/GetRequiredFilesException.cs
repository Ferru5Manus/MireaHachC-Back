namespace FileArchieveApi.Exceptions.FileExceptions;

public class GetRequiredFilesException: FileException
{
   
    public GetRequiredFilesException() {}
    public GetRequiredFilesException(string message) : base(message) {}
    public GetRequiredFilesException(string message, System.Exception inner) : base(message, inner) {}
    public GetRequiredFilesException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}

}
