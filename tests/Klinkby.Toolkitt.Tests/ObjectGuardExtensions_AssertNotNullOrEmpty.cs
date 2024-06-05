namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class ObjectGuardExtensions_AssertNotNullOrEmpty
{
    [Theory]
    [InlineData(null)]
    public void Null_Should_Throw(string? myParameter)
    {
        var ex = Assert.Throws<ArgumentNullException>(() =>
            myParameter.AssertNotNullOrEmpty());
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [InlineData("")]
    public void Empty_Should_Throw(string? myParameter)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            myParameter.AssertNotNullOrEmpty());
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [InlineData("foo")]
    public void NotNull_Should_Ok(string? myParameter)
    {
        var p = myParameter.AssertNotNullOrEmpty();
        Assert.Equal(myParameter, p);
    }
}