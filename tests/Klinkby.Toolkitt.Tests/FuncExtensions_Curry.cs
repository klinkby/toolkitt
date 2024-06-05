namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class FuncExtensions_Curry
{
    [Fact]
    public void Curry_Two_Should_Uncurry()
    {
        var fn = (int a, int b) => a + b;
        var curryed = fn.Curry();
        Assert.Equal(43, curryed(42)(1));
        Assert.Equal(43, curryed.UnCurry() (42, 1));
    }

    [Fact]
    public void Curry_Three_Should_UnCurry()
    {
        var fn = (int a, int b, int c) => a + b + c;
        var curryed = fn.Curry();
        Assert.Equal(45, curryed(42)(1)(2));
        Assert.Equal(45, curryed.UnCurry()(42, 1, 2));
    }
}