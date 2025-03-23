namespace MyProjectTemplate.Domain.Exceptions;

public class ForbiddenException : BaseException
{
    public ForbiddenException(string errorCode, string message) : base(403, errorCode, message)
    {
    }
}