using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace Klinkby.Toolkitt.Tests;

public class XUnitLoggerAdapter_Should_Write
{
    [Trait("Category", "Unit")]
    [Theory]
    [InlineData("\t")]
    [InlineData(";")]
    public void Log_Should_Write(string separator)
    {
        // arrange
        var mock = new Mock<ITestOutputHelper>();
        mock.Setup(x => x.WriteLine(It.Is<string>(s => $" Warning{separator}0{separator}test 42" == s)))
            .Verifiable();
        
        // act
        var dut = mock.Object.ToILogger(separator: separator);
        using var scope = dut.BeginScope(this);
        dut.LogWarning("test {no}", 42);
        
        // assert
        mock.VerifyAll();
    }
    
    [Trait("Category", "Unit")]
    [Fact]
    public void LogT_Should_BeGeneric()
    {
        // arrange
        var mock = new Mock<ITestOutputHelper>();

        // act
        var dut = mock.Object.ToILogger<XUnitLoggerAdapter_Should_Write>();
        
        // assert
        Assert.IsAssignableFrom<ILogger<XUnitLoggerAdapter_Should_Write>>(dut);
    }
    
    [Trait("Category", "Unit")]
    [Theory]
    [InlineData(LogLevel.None)]
    [InlineData(LogLevel.Warning)]
    public void LogLevel_Should_Skip(LogLevel logLevel)
    {
        // arrange
        var mock = new Mock<ITestOutputHelper>();
        
        // act
        var dut = mock.Object.ToILogger(logLevel);
        dut.LogInformation("test {no}", 42);
        
        // assert
        mock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Never());
    }
}