namespace Klinkby.Toolkitt;

// hat tip to @oskardudycz@hachyderm.io
// https://event-driven.io/en/explicit_validation_in_csharp_just_got_simpler/

public static class StructGuardExtensions
{
    public static T AssertNotNull<T>(
        [NotNull] this Nullable<T> value,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : struct =>
            value ?? throw new ArgumentNullException(argumentName);

    public static T AssertNotEmpty<T>(
        this T value,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : struct, IComparable<T> =>
            (0 == value.CompareTo(default(T)))
                ? throw new ArgumentOutOfRangeException(argumentName)
                : value;

    public static T AssertNotNullOrEmpty<T>(
        [NotNull] this Nullable<T> value,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : struct, IComparable<T>
    {
        if (!value.HasValue) throw new ArgumentNullException(argumentName);
        if (0 == value.Value.CompareTo(default(T))) throw new ArgumentOutOfRangeException(argumentName);
        return value.Value;
    }

    public static T AssertRange<T>(
        this T value,
        T from,
        T to,
        [CallerArgumentExpression("value")] string? argumentName = null) where T : IComparable<T> =>
            (value.CompareTo(from) < 0 || value.CompareTo(to) > 0)
                ? throw new ArgumentOutOfRangeException(argumentName)
                : value;
}
