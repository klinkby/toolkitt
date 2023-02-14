namespace Klinkby.Toolkitt;

// hat tip to @oskardudycz@hachyderm.io
// https://event-driven.io/en/explicit_validation_in_csharp_just_got_simpler/
// See also https://learn.microsoft.com/en-us/dotnet/communitytoolkit/diagnostics/guard

/// <summary>Guard clauses for value-types</summary> 
public static class StructGuardExtensions
{
    /// <summary>
    /// Guard clause validate nullable value is non-null
    /// </summary>
    /// <param name="value">Nullable value to test</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <returns>Non-null value</returns>
    /// <example><code>
    /// public void Echo(Point? p)
    /// {
    ///     Console.WriteLine(p.AssertNotNull().ToString());   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentNullException">Thrown if value is null</exception>
    public static T AssertNotNull<T>(
        [NotNull] this Nullable<T> value,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : struct =>
            value ?? throw new ArgumentNullException(argumentName);

    /// <summary>
    /// Guard clause validate value is non-empty
    /// </summary>
    /// <param name="value">Nullable value to test</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <returns>Non-empty value</returns>
    /// <example><code>
    /// public void ShowExtent(Size s)
    /// {
    ///     Console.WriteLine(s.AssertNotEmpty().ToString());   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if value is empty/default</exception>
    public static T AssertNotEmpty<T>(
        this T value,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : struct, IComparable<T> =>
            (0 == value.CompareTo(default(T)))
                ? throw new ArgumentOutOfRangeException(argumentName)
                : value;

    /// <summary>
    /// Guard clause validate nullable value is non-empty
    /// </summary>
    /// <param name="value">Nullable value to test</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <returns>Non-empty value</returns>
    /// <example><code>
    /// public void ShowExtent(Size? s)
    /// {
    ///     Console.WriteLine(s.AssertNotEmpty().ToString());   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentNullException">Thrown if value is null</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if value is empty/default</exception>
    public static T AssertNotNullOrEmpty<T>(
        [NotNull] this Nullable<T> value,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : struct, IComparable<T>
    {
        if (!value.HasValue) throw new ArgumentNullException(argumentName);
        if (0 == value.Value.CompareTo(default(T))) throw new ArgumentOutOfRangeException(argumentName);
        return value.Value;
    }

    /// <summary>
    /// Guard clause validate value is within a given range
    /// </summary>
    /// <param name="value">Value to test</param>
    /// <param name="from">Minimum valid value</param>
    /// <param name="to">Maximum valid value</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <returns>Value within specified range</returns>
    /// <example><code>
    /// public void ShowPercent(int part)
    /// {
    ///     Console.WriteLine(part.AssertRange(0, 100).ToString());   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if value is out of given range</exception>
    public static T AssertRange<T>(
        this T value,
        T from,
        T to,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : IComparable<T> =>
            (value.CompareTo(from) < 0 || value.CompareTo(to) > 0)
                ? throw new ArgumentOutOfRangeException(argumentName)
                : value;
}
