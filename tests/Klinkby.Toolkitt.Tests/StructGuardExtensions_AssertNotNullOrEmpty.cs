namespace Klinkby.Toolkitt.Tests;

public class StructGuardExtensions_AssertNotNullOrEmpty
{
    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(null)]
    public void Null_Should_Throw(int? myParameter)
    {
        var ex = Assert.Throws<ArgumentNullException>(() =>
            myParameter.AssertNotNullOrEmpty());
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(0)]
    public void Empty_Should_Throw(int? myParameter)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            myParameter.AssertNotNullOrEmpty());
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(42)]
    public void NotNull_Should_Ok(int? myParameter)
    {
        var p = myParameter.AssertNotNullOrEmpty();
        Assert.Equal(myParameter, p);
    }
}