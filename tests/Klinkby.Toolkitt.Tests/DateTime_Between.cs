namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class DateTime_Between
{
    [Theory]
    [InlineData("1970-01-01T00:00:00Z")]
    [InlineData("1970-01-01T10:00:00Z")]
    [InlineData("1970-01-02T00:00:00Z")]
    public void Should_BeBetween(DateTimeOffset dt)
    {
        // arrange
        var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var end = start.AddDays(1);

        // act
        var actualDateTime = dt.UtcDateTime.Between(start, end);
        var actualDateTimeOffset = dt.Between(start, end);

        // assert
        Assert.True(actualDateTime);
        Assert.True(actualDateTimeOffset);
    }

    [Theory]
    [InlineData("1969-12-31T23:59:59Z")]
    [InlineData("1970-01-02T00:00:01Z")]
    public void ShouldNot_BeBetween(DateTimeOffset dt)
    {
        // arrange
        var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var end = start.AddDays(1);

        // act
        var actualDateTime = dt.UtcDateTime.Between(start, end);
        var actualDateTimeOffset = dt.Between(start, end);

        // assert
        Assert.False(actualDateTime);
        Assert.False(actualDateTimeOffset);
    }
}