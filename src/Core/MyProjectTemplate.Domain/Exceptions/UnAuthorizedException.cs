namespace MyProjectTemplate.Domain.Exceptions;

public class UnAuthorizedException : BaseException
{
    public UnAuthorizedException(string errorCode, string message) : base(401, errorCode, message)
    {
    }
}