namespace MireaHackBack.Exceptions.CreateProjectExceptions.CSharp;

public class AddCsFileException : System.Exception
{
    public AddCsFileException() {}
    public AddCsFileException(string message) : base(message) {}
    public AddCsFileException(string message, System.Exception inner) : base(message, inner) {}
    public AddCsFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}