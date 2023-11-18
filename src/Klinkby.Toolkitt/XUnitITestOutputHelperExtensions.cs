using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Klinkby.Toolkitt;

/// <summary>
///     Extensions for <see cref="ITestOutputHelper" />
/// </summary>
public static class XUnitITestOutputHelperExtensions
{
    private const string DefaultSeparator = "\t";
    private const LogLevel DefaultMinimumLogLevel = LogLevel.Trace;

    /// <summary>
    ///     Create an <see cref="ILogger" /> from an <see cref="ITestOutputHelper" />
    /// </summary>
    /// <param name="xunitLogger">The logger provided to test constructor</param>
    /// <param name="minimumLogLevel">Filter minimum log level (defaults to Trace)</param>
    /// <param name="separator">Field separator in output (defaults to Tab-character)</param>
    /// <returns>An ILogger</returns>
    /// <example>
    ///     <code><![CDATA[
    /// public class MyTest
    /// {
    ///     ILogger _logger;
    ///     public MyTest(ITestOutputHelper output)
    ///     {
    ///         _logger = output.ToILogger();
    ///     }
    /// }
    /// ]]></code>
    /// </example>
    public static ILogger ToILogger(this ITestOutputHelper xunitLogger,
        LogLevel minimumLogLevel = DefaultMinimumLogLevel,
        string separator = DefaultSeparator)
    {
        return new XUnitLoggerAdapter(xunitLogger, minimumLogLevel, separator);
    }

    /// <summary>
    ///     Create an <see cref="ILogger{T}" /> from an <see cref="ITestOutputHelper" />
    /// </summary>
    /// <param name="xunitLogger">The logger provided to test constructor</param>
    /// <param name="minimumLogLevel">Filter minimum log level (defaults to Trace)</param>
    /// <param name="separator">Field separator in output (defaults to Tab-character)</param>
    /// <returns>An ILogger{T}</returns>
    /// <example>
    ///     <code><![CDATA[
    /// public class MyTest
    /// {
    ///     ILogger<MyTest> _logger;
    ///     public MyTest(ITestOutputHelper output)
    ///     {
    ///         _logger = output.ToILogger<MyTest>();
    ///     }
    /// }
    /// ]]></code>
    /// </example>
    public static ILogger<T> ToILogger<T>(this ITestOutputHelper xunitLogger, LogLevel minimumLogLevel = LogLevel.Trace,
        string separator = "\t")
    {
        return new XUnitLoggerAdapter<T>(xunitLogger, minimumLogLevel, separator);
    }
}