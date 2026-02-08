namespace Versta.Store.Models.Results;

public class Result
{
    public bool IsSuccess => Error == null;

    public Error? Error { get; init; }

    public static Result Success() => new();

    public static Result Failure(Error error) => new() { Error = error };

    public static Result Failure(string errorMessage) => new() { Error = new Error(string.Empty, errorMessage) };
}

public class Result<T> : Result
{
    public T? Data { get; init; }

    public static Result<T> Success(T data) => new() { Data = data };

    public new static Result<T> Failure(Error error) => new() { Error = error };

    public new static Result<T> Failure(string errorMessage) => new() { Error = new Error(string.Empty, errorMessage) };
}

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);
}
