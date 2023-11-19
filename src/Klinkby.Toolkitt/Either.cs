using System.Diagnostics.Contracts;

namespace Klinkby.Toolkitt;

/// <summary>
/// Base class for <see cref="Either{T}"/>
/// </summary>
/// <seealso cref="Identity"/>
public abstract record Either
{
    /// <summary>
    /// Create an <see cref="Either{T}"/> from a value.
    /// </summary>
    /// <param name="value">Value of Either</param>
    /// <returns>New Either</returns>
    public static Either<T> From<T>(T value) => IsDefault(value) ? Left<T>.Empty : new Right<T>(value);

    internal static bool IsDefault<T>(T value) => EqualityComparer<T>.Default.Equals(default, value);
}

/// <summary>
/// Implements a monad that either a) holds a value in which case it is a <see cref="Right{T}"/>, 
/// or b) an exception or default-value in which case it is a <see cref="Left{T}"/>.
/// </summary>
/// <remarks>This is sometimes referred to as a Maybe.</remarks>
/// <typeparam name="T">Type of Either</typeparam>
/// <seealso cref="Identity{T}"/>
/// <example><code><!--
///  double Calculate(double y)
/// {
///     var result = Either.From(y)
///         .Bind(x =&gt; x - 2)
///         .Bind(Math.Sin);
///     return (result is Right&lt;double&gt;)
///             ? result
///             : SomeCompensation();
/// }
/// --></code></example>
public abstract record Either<T> : Either
{
    /// <summary>
    /// Cast Either to value
    /// </summary>
    /// <param name="me">Either to get value from</param>
    /// <returns>Value of Either</returns>
    [Pure]
    public static implicit operator T(Either<T> me) => me.Value;
    
    /// <summary>
    /// Cast value to Either
    /// </summary>
    /// <param name="value">Value of new Either</param>
    /// <returns>Either with value</returns>
    [Pure]
    public static implicit operator Either<T>(T value) => From(value);

    internal Either()
    {
    }

    /// <summary>
    /// Get the value if the Either is a <see cref="Right{T}"/>, otherwise throw an exception.
    /// </summary>
    public abstract T Value { get; }

    /// <summary>
    /// Transforms the value of the Either if it is a <see cref="Right{T}"/> using the given
    /// function.
    /// </summary>
    /// <param name="f">Function to apply to value</param>
    /// <typeparam name="TResult">Result type</typeparam>
    /// <returns>Result as either <see cref="Right{T}"/> or <see cref="Left{T}"/> </returns>
    /// <remarks>This is sometimes referred to as Map.</remarks>
    public abstract Either<TResult> Bind<TResult>(Func<T, TResult> f);
}