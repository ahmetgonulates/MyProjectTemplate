namespace MyProjectTemplate.Domain.Results;

public enum ErrorType
{
    Failure = 500,
    NotFound = 404,
    Validation = 400,
    AccessUnAuthorized = 401,
    AccessForbidden = 403
}