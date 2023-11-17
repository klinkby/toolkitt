using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Klinkby.Toolkitt;

internal class XUnitLoggerAdapter : ILogger
{
    private readonly ITestOutputHelper _logger;
    private readonly LogLevel _minimumLogLevel;
    private readonly string _separator;
    private int _indent;

    public XUnitLoggerAdapter(ITestOutputHelper logger, LogLevel minimumLogLevel, string separator)
    {
        _logger = logger;
        _minimumLogLevel = minimumLogLevel;
        _separator = separator;
    }

    private string Indent 
        => new(' ', _indent);

    public IDisposable BeginScope<TState>(TState state)
    {
        _logger.WriteLine(Indent + state);
        Interlocked.Increment(ref _indent);
        return new Scope(() => Interlocked.Decrement(ref _indent));
    }

    public bool IsEnabled(LogLevel logLevel) 
        => logLevel switch
        {
            LogLevel.None => false,
            _ => logLevel >= _minimumLogLevel 
        };

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;
        var message = $"{Indent}{logLevel}{_separator}{eventId}{_separator}{formatter(state, exception)}";
        _logger.WriteLine(message);
    }

    private sealed class Scope : IDisposable
    {
        private readonly Action _cleanUp;

        internal Scope(Action cleanup) => _cleanUp = cleanup;

        public void Dispose() => _cleanUp();
    }
}

internal class XUnitLoggerAdapter<T> : XUnitLoggerAdapter, ILogger<T>
{
    public XUnitLoggerAdapter(ITestOutputHelper logger, LogLevel minimumLogLevel, string separator)
        : base(logger, minimumLogLevel, separator)
    {
    }
}