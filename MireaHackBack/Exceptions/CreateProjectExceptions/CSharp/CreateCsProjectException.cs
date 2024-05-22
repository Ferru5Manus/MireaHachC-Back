namespace MireaHackBack.Exceptions.CreateProjectExceptions.CSharp;

public class CreateCsProjectException : System.Exception
{
    public CreateCsProjectException() {}
    public CreateCsProjectException(string message) : base(message) {}
    public CreateCsProjectException(string message, System.Exception inner) : base(message, inner) {}
    public CreateCsProjectException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
}