using System.Diagnostics.Contracts;

namespace Klinkby.Toolkitt;

/// <summary>
/// An <see cref="Either{T}"/> value that is faulted due to default value or an exception. 
/// </summary>
/// <typeparam name="T">Value type</typeparam>
public sealed record Left<T> : Either<T>
{
    internal static readonly Left<T> Empty = new();
    private readonly Exception? _exception; 
    
    internal Left(Exception? exception = default) => _exception = exception;
    
    /// <summary>
    /// Returns the exception if the <see cref="Left{T}"/> is faulted, otherwise null.
    /// </summary>
    [Pure]
    public Exception? Exception => _exception;
    
#pragma warning disable CA1065
    /// <summary>
    /// Left monad has no meaningful value.
    /// Will throw the Exception value or <see cref="InvalidOperationException"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    [Pure]
    public override T Value => throw _exception ?? new InvalidOperationException("Left has no value.");
#pragma warning restore CA1065
    
    /// <inheritdoc />
    [Pure]
    public override Either<TResult> Bind<TResult>(Func<T, TResult> f)
    {
        return new Left<TResult>(Exception);
    }
}