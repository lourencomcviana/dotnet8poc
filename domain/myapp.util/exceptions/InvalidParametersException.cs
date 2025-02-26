namespace myapp.util.exceptions;

public class InvalidParametersException: HttpException
{
    public InvalidParametersException(string? message, Exception? innerException, int code) : base(message,innerException ,code)
    {
    }

}