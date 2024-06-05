namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class ObjectGuardExtensions_AssertNotNull
{
    [Theory]
    [InlineData(null)]
    public void Null_Should_Throw(object? myParameter)
    {
        var ex = Assert.Throws<ArgumentNullException>(() => myParameter.AssertNotNull());
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(2)]
    public void NotNull_Should_Ok(object? myParameter)
    {
        var p = myParameter.AssertNotNull();
        Assert.Equal(myParameter, p);
    }
}