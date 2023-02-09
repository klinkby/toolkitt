namespace Klinkby.Toolkitt.Tests;

public class StructGuardExtensions_AssertNotNull
{
    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(null)]
    public void Null_Should_Throw(int? myParameter)
    {
        var ex = Assert.Throws<ArgumentNullException>(() =>
            myParameter.AssertNotNull());
        Assert.Equal(nameof(myParameter), ex.ParamName);
    }

    [Theory]
    [Trait("Category", "Unit")]
    [InlineData(42)]
    public void NotNull_Should_Ok(int? myParameter)
    {
        var p = myParameter.AssertNotNull();
        Assert.Equal(myParameter, p);
    }
}