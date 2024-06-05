namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class StructGuardExtensions_AssertNotEmpty
{
    [Theory]
    [InlineData(0)]
    public void Empty_Should_Throw(int myParameter)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            myParameter.AssertNotEmpty());
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [InlineData(42)]
    public void NotEmpty_Should_Ok(int myParameter)
    {
        var p = myParameter.AssertNotEmpty();
        Assert.Equal(myParameter, p);
    }
}