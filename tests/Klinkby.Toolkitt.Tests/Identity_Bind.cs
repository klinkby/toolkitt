namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Identity_Bind
{
    const int Seed = 42;
    
    [Fact]
    public void Should_Change_Type()
    {
        // arrange
        var dut1 = Identity.From(Seed);
        
        // act
        var dut2 = dut1.Bind(x => $"{x * 2}");
        
        // assert
        Assert.Equal("84", dut2.Value);
    }
    
    [Fact]
    public void Should_Throw()
    {
        // arrange
        var dut1 = Identity.From(Seed);
        Exception? ex = default;
        bool called = false;
        
        // act
        try
        {
            _ = dut1.Bind(new Func<int, string>(_ => throw new InvalidOperationException()))
                    .Bind(_ => called = true); 
        }
#pragma warning disable CA1031
        catch (Exception e)
#pragma warning restore CA1031
        {
            ex = e;
        }
        
        // assert
        Assert.IsType<InvalidOperationException>(ex);
        Assert.False(called);
    }
}