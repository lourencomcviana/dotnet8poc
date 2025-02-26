using System.Runtime.Serialization;

namespace myapp.util.exceptions;

public class HttpException:Exception
{
    public int HttpCode { get; }
    

    public HttpException(int httpCode)
    {
        HttpCode = httpCode;
    }

    protected HttpException(SerializationInfo info, StreamingContext context, int httpCode) : base(info, context)
    {
        HttpCode = httpCode;
    }

    public HttpException(string? message, int httpCode) : base(message)
    {
        HttpCode = httpCode;
    }

    public HttpException(string? message, Exception? innerException, int httpCode) : base(message, innerException)
    {
        HttpCode = httpCode;
    }
}