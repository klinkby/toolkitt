﻿using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class XUnitLoggerAdapter_Should_Write
{
    private readonly ITestOutputHelper _output;
   
    public XUnitLoggerAdapter_Should_Write(ITestOutputHelper output) 
        => _output = output;
    
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
        using (dut.BeginScope(this))
        {
            dut.LogWarning("test {No}", 42);
        }

        // assert
        mock.VerifyAll();
    }
    
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
    
    [Theory]
    [InlineData(LogLevel.None)]
    [InlineData(LogLevel.Warning)]
    public void LogLevel_Should_Skip(LogLevel logLevel)
    {
        // arrange
        var mock = new Mock<ITestOutputHelper>();
        
        // act
        var dut = mock.Object.ToILogger(logLevel);
        dut.LogInformation("test {No}", 42);
        
        // assert
        mock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Never());
    }

    [Fact]
    public void LogLevel_Should_Enable()
    {
        // arrange
        var mock = new Mock<ITestOutputHelper>();
        
        // act
        var dut = mock.Object.ToILogger(LogLevel.Information);
        
        // assert
        Assert.True(dut.IsEnabled(LogLevel.Information));
    }

    [Theory]
    [InlineData("Foo")]
    public void Log_Should_Not_Throw(string message)
    {
        // arrange
        var logger = _output.ToILogger();
        
        // act
        var exception = Record.Exception(() => 
            logger.LogInformation("{Mesage}", message)
        );

        // assert
        Assert.Null(exception);
    }
}