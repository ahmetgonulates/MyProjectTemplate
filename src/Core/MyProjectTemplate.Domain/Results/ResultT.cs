namespace MyProjectTemplate.Domain.Results;

public sealed class ResultT<TValue> : Result
{
    private readonly TValue? _value;

    private ResultT(TValue value) : base(200)
    {
        _value = value;
    }

    private ResultT(Error error) : base(error)
    {
        _value = default;
    }

    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("Value Degeri Olmak Zorunda");

    public static implicit operator ResultT<TValue>(Error error) => new(error);
    public static implicit operator ResultT<TValue>(TValue value) => new(value);

    public static ResultT<TValue> Success(TValue value) => new(value);
    public new static ResultT<TValue> Failure(Error error) => new(error);
}