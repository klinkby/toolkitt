using System.Text.RegularExpressions;

namespace Klinkby.Toolkitt.Tests;

public partial class ObjectGuardExtensions_AssertMatchesRegex
{
    [GeneratedRegex(@"^(\d)$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex DigitRegex(); // code-gen

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(null)]
    public void Null_Should_Throw(string? myParameter)
    {
        var ex = Assert.Throws<ArgumentNullException>(() => myParameter.AssertMatchesRegex(DigitRegex()));
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData("12")]
    [InlineData("a")]
    [InlineData("")]
    public void NoMatch_Should_Throw(string? myParameter)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => myParameter.AssertMatchesRegex(DigitRegex()));
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData("2")]
    public void SingleDigit_Should_Ok(string? myParameter)
    {
        var p = myParameter.AssertMatchesRegex(DigitRegex());
        Assert.Equal(myParameter, p);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData("2")]
    public void Regex_SingleDigit_Should_Ok(string? myParameter)
    {
        var p = myParameter.AssertMatchesRegex(DigitRegex());
        Assert.Equal(myParameter, p);
    }
}