using System.Diagnostics.CodeAnalysis;

namespace FlightProject.Shared;

public class Result(bool isSuccess, Error error)
{
    public bool IsSuccess { get; } = isSuccess;

    public bool IsFailure => !IsSuccess;

    public Error Error { get; } = error;

    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    public static Result<TValue> Failure<TValue>(TValue value, Error error) => new(value, false, error);
}

public class Result<TValue>(TValue? value, bool isSuccess, Error error) : Result(isSuccess, error)
{
    //private readonly TValue? _value = value;

    [NotNull]
    public TValue? Value { get; } = value;
}
