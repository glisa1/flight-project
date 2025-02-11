using System.Diagnostics.CodeAnalysis;

namespace FlightProject.Shared;

public class Result
{
    public Result(bool isSuccess, Error error)
    {
        Error = error;
        IsSuccess = isSuccess;
    }
    public Result(bool isSuccess, IEnumerable<Error> errors)
    {
        ValidationErrors = errors;
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public bool IsValidationErrorResult => ValidationErrors != null;

    public Error? Error { get; }

    public IEnumerable<Error>? ValidationErrors { get; }

    public static Result Success() => new(true, Error.None);
    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    public static Result Failure(Error error) => new(false, error);
    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);
    public static Result<TValue> Failure<TValue>(TValue value, Error error) => new(value, false, error);
    public static Result ValidationFailure(IEnumerable<Error> errors) => new(false, errors);
    public static Result<TValue> ValidationFailure<TValue>(TValue? value, IEnumerable<Error> errors) => new(value, false, errors);
}

public class Result<TValue> : Result
{
    public Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public Result(TValue? value, bool isSuccess, IEnumerable<Error> errors)
        : base(isSuccess, errors)
    {
        Value = value;
    }

    [NotNull]
    public TValue? Value { get; }
}
