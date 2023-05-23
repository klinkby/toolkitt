namespace Klinkby.Toolkitt.Tests;

public class FuncExtensions_Apply
{
    [Fact]
    [Trait("Category", "Unit")]
    public void One_On_One_Should_Apply()
    {
        var fn = (int a) => a;
        var applied = fn.Apply(42);
        Assert.Equal(42, applied());
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void One_On_Two_Should_Apply()
    {
        var fn = (int a, int b) => a + b;
        var applied = fn.Apply(42);
        Assert.Equal(43, applied(1));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Two_On_Two_Should_Apply()
    {
        var fn = (int a, int b) => a + b;
        var applied = fn.Apply(42, 1);
        Assert.Equal(43, applied());
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void One_On_Three_Should_Apply()
    {
        var fn = (int a, int b, int c) => a + b + c;
        var applied = fn.Apply(42);
        Assert.Equal(45, applied(1, 2));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Two_On_Three_Should_Apply()
    {
        var fn = (int a, int b, int c) => a + b + c;
        var applied = fn.Apply(42, 1);
        Assert.Equal(45, applied(2));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Three_On_Three_Should_Apply()
    {
        var fn = (int a, int b, int c) => a + b + c;
        var applied = fn.Apply(42, 1, 2);
        Assert.Equal(45, applied());
    }
}