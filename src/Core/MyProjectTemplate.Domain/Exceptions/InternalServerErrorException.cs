namespace MyProjectTemplate.Domain.Exceptions;

public class InternalServerErrorException : BaseException
{
    public InternalServerErrorException(string errorCode, string message) : base(500, errorCode, message)
    {
    }
}