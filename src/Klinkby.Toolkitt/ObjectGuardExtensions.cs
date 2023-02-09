using System.Text.RegularExpressions;
namespace Klinkby.Toolkitt;

// hat tip to @oskardudycz@hachyderm.io
// https://event-driven.io/en/explicit_validation_in_csharp_just_got_simpler/

public static class ObjectGuardExtensions
{
    public static object AssertNotNull(
        [NotNull] this object? value,
        [CallerArgumentExpression("value")] string? argumentName = null) =>
            value ?? throw new ArgumentNullException(argumentName);

    public static string AssertMatchesRegex(
        [NotNull] this string? value,
        /* [StringSyntax(StringSyntaxAttribute.Regex)] */ string pattern,
        RegexOptions options = default,
        [CallerArgumentExpression("value")] string? argumentName = null) =>
        Regex.IsMatch(value ?? throw new ArgumentNullException(argumentName), pattern, options)
            ? value
            : throw new ArgumentOutOfRangeException(argumentName);

    public static string AssertNotNullOrEmpty(
        [NotNull] this string? value,
        [CallerArgumentExpression("value")] string? argumentName = null) =>
            (0 == (value ?? throw new ArgumentNullException(argumentName)).Length)
                ? throw new ArgumentOutOfRangeException(argumentName)
                : value;
}
