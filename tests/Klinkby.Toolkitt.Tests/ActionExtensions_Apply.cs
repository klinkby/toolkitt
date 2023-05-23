namespace Klinkby.Toolkitt.Tests;

public class ActionExtensions_Apply
{
    [Fact]
    [Trait("Category", "Unit")]
    public void One_On_One_Should_Apply()
    {
        int result = 0;
        var fn = (int a) => { result = a; };
        fn.Apply(42)();
        Assert.Equal(42, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void One_On_Two_Should_Apply()
    {
        int result = 0;
        var fn = (int a, int b) => { result = a + b; };
        fn.Apply(42)(1);
        Assert.Equal(43, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Two_On_Two_Should_Apply()
    {
        int result = 0;
        var fn = (int a, int b) => { result = a + b; };
        fn.Apply(42, 1)();
        Assert.Equal(43, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void One_On_Three_Should_Apply()
    {
        int result = 0;
        var fn = (int a, int b, int c) => { result = a + b + c; };
        fn.Apply(42)(1, 2);
        Assert.Equal(45, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Two_On_Three_Should_Apply()
    {
        int result = 0;
        var fn = (int a, int b, int c) => { result = a + b + c; };
        fn.Apply(42, 1)(2);
        Assert.Equal(45, result);
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void Three_On_Three_Should_Apply()
    {
        int result = 0;
        var fn = (int a, int b, int c) => { result = a + b + c; };
        fn.Apply(42, 1, 2)();
        Assert.Equal(45, result);
    }
}