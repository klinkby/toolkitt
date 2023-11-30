using System.Globalization;

namespace Klinkby.Toolkitt;

/// <summary>Extensions for <see cref="DateTime"/> and <see cref="DateTimeOffset"/></summary>
public static class DateTimeExtensions
{
    private const string IsoUtcDateFormat = $"yyyy-MM-ddZ";

    /// <summary>
    /// Throws <see cref="ArgumentException"/> if the timezone kind is unspecified
    /// </summary>
    /// <param name="value">DateTime to test</param>
    /// <param name="argumentName">Automatically inferred by compiler</param>
    /// <example><code>
    /// public void Echo()
    /// {
    ///     DateTime dt
    ///     Console.WriteLine(dt.AssertKnownKind());   
    /// }
    /// </code></example>
    /// <exception cref="ArgumentException">Thrown if Kind is Unspecified</exception>
    public static DateTime AssertKnownKind(this DateTime value,
        [CallerArgumentExpression("value")] string? argumentName = null)
    {
        if (value.IsUnspecifiedKind())
            throw new ArgumentException("Kind is Unspecified", argumentName);
        return value;
    }
    
    /// <summary>
    /// Returns true if the date is between start and end
    /// </summary>
    /// <param name="value">DateTime to compare</param>
    /// <param name="start">Period start (inclusive)</param>
    /// <param name="end">Period end (inclusive)</param>
    /// <returns>True if date is in rance</returns>
    /// <exception cref="ArgumentException">Thrown if a DateTime Kind is Unspecified</exception>
    public static bool Between(this DateTime value, DateTime start, DateTime end)
        => start.AssertKnownKind() <= value.AssertKnownKind() && end.AssertKnownKind() >= value; 
    
    /// <summary>
    /// Returns true if the date is between start and end 
    /// </summary>
    /// <param name="value">DateTime to compare</param>
    /// <param name="start">Period start (inclusive)</param>
    /// <param name="end">Period end (inclusive)</param>
    /// <returns>True if date is in rance</returns>
    public static bool Between(this DateTimeOffset value, DateTimeOffset start, DateTimeOffset end)
        => start <= value && end >= value;

    /// <summary>
    /// Returns the date as a string in ISO-8601 format (yyyy-MM-ddZ) in universal time zone. Returns false if the DateTime Kind is unspecified. 
    /// </summary>
    /// <param name="value">DateTime to convert</param>
    /// <param name="dateString">Result of formatting</param>
    /// <returns>True if the date could be formatted</returns>
    public static bool TryFormatUtcDate(this DateTime value, out string? dateString)
    {
        if (value.IsUnspecifiedKind())
        {
            dateString = default;
            return false;
        }
        dateString = (value.Kind == DateTimeKind.Local ? value.ToUniversalTime() : value)
            .ToString(IsoUtcDateFormat, CultureInfo.InvariantCulture);
        return true;
    }
    
    /// <summary>
    /// Returns the date as a string in ISO-8601 format (yyyy-MM-ddZ) in universal time zone. 
    /// </summary>
    /// <param name="value">DateTime to convert</param>
    /// <returns>Result of formatting</returns>
    public static string FormatUtcDate(this DateTimeOffset value)
        => value.ToUniversalTime()
             .ToString(IsoUtcDateFormat, CultureInfo.InvariantCulture);
    
    private static bool IsUnspecifiedKind(this DateTime value) => 
        value.Kind == DateTimeKind.Unspecified;
}