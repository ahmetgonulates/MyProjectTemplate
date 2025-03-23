namespace MyProjectTemplate.Domain.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string errorCode, string message) : base(404, errorCode, message)
    {
    }
}