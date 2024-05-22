namespace MireaHackBack.Exceptions.CreateProjectExceptions.CSharp;

public class CreateCsProjectCommandException : System.Exception
{
    public CreateCsProjectCommandException() {}
    public CreateCsProjectCommandException(string message) : base(message) {}
    public CreateCsProjectCommandException(string message, System.Exception inner) : base(message, inner) {}
    public CreateCsProjectCommandException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}