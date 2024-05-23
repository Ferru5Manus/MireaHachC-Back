namespace MireaHackBack.Response;

public class ApiResponse
{
    public int StatusCode {get;set;}
    public object? Payload {get;set;}
    public Exception? Exception {get;set;}
}