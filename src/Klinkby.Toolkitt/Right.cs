using System.Diagnostics.Contracts;

namespace Klinkby.Toolkitt;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed record Right<T> : Either<T>
{
    private readonly T _value;

    internal Right(T value) => _value = value!;

    /// <inheritdoc />
    [Pure]
    public override T Value => _value;

    /// <inheritdoc />
    [Pure]
    public override Either<TResult> Bind<TResult>(Func<T, TResult> f)
    {
        try
        {
            TResult result = f(Value);
            return IsDefault(result)
                ? Left<TResult>.Empty
                : new Right<TResult>(result);
        }
        catch (Exception e)
        {
            return new Left<TResult>(e);
        }
    }
}