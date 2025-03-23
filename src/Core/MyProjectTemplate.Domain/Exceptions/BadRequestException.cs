namespace MyProjectTemplate.Domain.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string errorCode, string message) : base(400, errorCode, message)
    {
        
    }
}