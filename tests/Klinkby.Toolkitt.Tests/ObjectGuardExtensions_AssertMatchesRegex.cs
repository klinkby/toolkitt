namespace Klinkby.Toolkitt.Tests;

public class ObjectGuardExtensions_AssertMatchesRegex
{
    private const string Pattern = @"^(\d)$";

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(null)]
    public void Null_Should_Throw(string? myParameter)
    {
        var ex = Assert.Throws<ArgumentNullException>(() => myParameter.AssertMatchesRegex(Pattern));
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData("12")]
    [InlineData("a")]
    [InlineData("")]
    public void NoMatch_Should_Throw(string? myParameter)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => myParameter.AssertMatchesRegex(Pattern));
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData("2")]
    public void SingleDigit_Should_Ok(string? myParameter)
    {
        var p = myParameter.AssertMatchesRegex(Pattern);
        Assert.Equal(myParameter, p);
    }
}