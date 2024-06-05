using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Klinkby.Toolkitt;

// hat tip to @oskardudycz@hachyderm.io
// https://event-driven.io/en/explicit_validation_in_csharp_just_got_simpler/
// See also https://learn.microsoft.com/en-us/dotnet/communitytoolkit/diagnostics/guard

/// <summary>Guard clauses for reference-types</summary> 
public static class ObjectGuardExtensions
{
    /// <summary>
    /// Guard clause validate value is non-null
    /// </summary>
    /// <param name="value">Value to test</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <returns>Non-null value</returns>
    /// <example><code>
    /// public void Cleanup(IDisposable? obj)
    /// {
    ///     obj.AssertNotNull().Dispose();   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentNullException">Thrown if value is null</exception>
    public static T AssertNotNull<T>(
        [NotNull] this T? value,
        [CallerArgumentExpression("value")] string? argumentName = null) where T: class => 
           value ?? throw new ArgumentNullException(argumentName);

    /// <summary>
    /// Guard clause validate value is non-null and match a specific regular expression
    /// </summary>
    /// <param name="value">Value to test</param>
    /// <param name="pattern">Regular expression to match</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <returns>Non-null value that match the pattern</returns>
    /// <example><code>
    /// public void SendMail(string email)
    /// {
    ///     SendMail(to: email.AssertMatchesRegex(new Regex("@")), body: "Hello there");   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentNullException">Thrown if value is null</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if value does not match expression</exception>
    public static string AssertMatchesRegex(
        [NotNull] this string? value,
        Regex pattern,
        [CallerArgumentExpression("value")] string? argumentName = null)
    {
        Debug.Assert(pattern != null, nameof(pattern) + " != null");
        return pattern.IsMatch(value ?? throw new ArgumentNullException(argumentName))
            ? value
            : throw new ArgumentOutOfRangeException(argumentName);
    }

    /// <summary>
    /// Guard clause validate value is non-null and not an empty string
    /// </summary>
    /// <param name="value">Value to test</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <returns>Non-null, non-empty value</returns>
    /// <example><code>
    /// public void SayHello(string? name)
    /// {
    ///     Console.WriteLine($"Hello {name.AssertNotNullOrEmpty()}");   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentNullException">Thrown if value is null</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if value is empty</exception>
    public static string AssertNotNullOrEmpty(
        [NotNull] this string? value,
        [CallerArgumentExpression("value")] string? argumentName = null) =>
            (0 == (value ?? throw new ArgumentNullException(argumentName)).Length)
                ? throw new ArgumentOutOfRangeException(argumentName)
                : value;
}
