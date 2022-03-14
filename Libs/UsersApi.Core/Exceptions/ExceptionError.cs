namespace UsersApi.Core.Exceptions;

public class ExceptionError
{
    public string Message { get; set; } = null!;

    public int StatusCode { get; set; }
}