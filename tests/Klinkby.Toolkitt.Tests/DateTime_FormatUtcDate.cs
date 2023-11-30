namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class DateTime_FormatUtcDate
{
    [Theory]
    [InlineData("1970-01-01T00:00:00Z", "1970-01-01Z")]
    public void DateTime_Should_Format(DateTime dt, string expected)
    {
        // act
        bool success = dt.ToUniversalTime().TryFormatUtcDate(out var actual);

        // assert
        Assert.True(success);
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData("1970-01-01T20:00:00+05:00", "1970-01-01Z")]
    public void Local_DateTime_Should_Format(DateTime dt, string expected)
    {
        // act
        bool success = dt.ToLocalTime().TryFormatUtcDate(out var actual);

        // assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Reject_Unknown_Kind()
    {
        // arrange
        var dt = new DateTime(1970, 1, 1, 0, 0, 0, 
            DateTimeKind.Unspecified);
        
        // act
        bool success = dt.TryFormatUtcDate(out var actual);

        // assert
        Assert.False(success);
        Assert.Null(actual);
    }

    [Theory]
    [InlineData("1970-01-01T00:00:00Z", "1970-01-01Z")]
    public void DateTimeOffset_Should_Format(DateTimeOffset dt, string expected)
    {
        // act
        string actual = dt.FormatUtcDate();

        // assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1970-01-01T20:00:00+05:00", "1970-01-01Z")]
    public void Local_DateTimeOffset_Should_Format(DateTimeOffset dt, string expected)
    {
        // act
        string actual = dt.FormatUtcDate();

        // assert
        Assert.Equal(expected, actual);
    }



}