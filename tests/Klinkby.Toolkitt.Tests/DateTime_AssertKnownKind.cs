namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class DateTime_AssertKnownKind
{
    [Theory]
    [InlineData(DateTimeKind.Local)]
    [InlineData(DateTimeKind.Utc)]
    public void Should_Accept(DateTimeKind kind)
    {
        // arrange
        var value = new DateTime(1970, 1, 1, 0, 0, 0, kind);

        // act
        var actual = value.AssertKnownKind();
        
        // assert
        Assert.Equal(value, actual);
    }
    
    [Theory]
    [InlineData(DateTimeKind.Unspecified)]
    public void Should_Throw(DateTimeKind kind)
    {
        // arrange
        var value = new DateTime(1970, 1, 1, 0, 0, 0, kind);

        // act, assert
        Assert.Throws<ArgumentException>(() => value.AssertKnownKind());
    }

}