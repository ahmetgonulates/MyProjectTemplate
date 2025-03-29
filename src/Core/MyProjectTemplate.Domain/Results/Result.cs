using System.Text.Json.Serialization;

namespace MyProjectTemplate.Domain.Results;

public class Result
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Error? Error { get; }

    protected Result(int statusCode)
    {
        StatusCode = statusCode;
        IsSuccess = true;
        Error = default;
    }

    protected Result(Error error)
    {
        StatusCode = (int)error.ErrorType;
        IsSuccess = false;
        Error = error;
    }
    
    public static Result Success() => new(200);
    public static Result Created() => new(201);
    public static Result NoContent() => new(204);

    public static Result Failure(Error error) => new(error);
    
    public static implicit operator Result(Error error) => new(error);
}