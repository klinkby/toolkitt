using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Klinkby.Toolkitt;

/// <summary>
/// Identity monad factory
/// </summary>
public static class Identity
{
    /// <summary>
    /// Create a new Identity
    /// </summary>
    /// <param name="value">Value of identity</param>
    /// <typeparam name="T">Type of value</typeparam>
    /// <returns>A new Identity</returns>
    [Pure]
    public static Identity<T> From<T>(T value) => new(value);
}

/// <summary>
/// Simple immutable monad wrapper for a value. Using ref struct to guarantee no GC.
/// </summary>
/// <typeparam name="T">Value type</typeparam>
/// <seealso cref="Identity"/>
/// <seealso cref="Either{T}"/>
/// <example><code><!--
///  double Calculate(double y)
/// {
///     var result = Identity.From(y)
///         .Bind(x =&gt; x - 2)
///         .Bind(Math.Sin);
///     return result.Value;
/// }
/// --></code></example>
public readonly ref struct Identity<T>
{
    private readonly T _value;
    
    internal Identity(T value) => _value = value;

    /// <summary>
    /// Get value
    /// </summary>
    [Pure]
    public T Value => _value;

    /// <summary>
    /// Map value to another value, possibly of another type
    /// </summary>
    /// <param name="f"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    [Pure]
    public Identity<TResult> Bind<TResult>(Func<T, TResult> f)
    {
        Debug.Assert(f != null, nameof(f) + " != null");
        return f(_value);
    }

#pragma warning disable CA2225
    /// <summary>
    /// Cast to value
    /// </summary>
    /// <param name="me">Identity to get value from</param>
    /// <returns>Value of Identity</returns>
    [Pure]
    public static implicit operator T(Identity<T> me) => me.Value;

    /// <summary>
    /// Cast value to Identity
    /// </summary>
    /// <param name="value">Value of identity</param>
    /// <returns>A new Identity</returns>
    [Pure]
    public static implicit operator Identity<T>(T value) => new(value);
#pragma warning restore CA2225
}
