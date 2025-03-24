namespace MyProjectTemplate.Domain.Exceptions;

public abstract class BaseException : Exception
{
    public BaseException(int statusCode, string errorCode, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        ErrorMessage = message;
    }

    public int StatusCode { get; set; }
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
}