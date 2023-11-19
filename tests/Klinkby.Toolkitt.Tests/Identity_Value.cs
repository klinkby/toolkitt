namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Identity_Value
{
    const int Seed = 42;

    [Fact]
    public void Initialized_Should_Return()
    {
        // act
        var dut1 = Identity.From(Seed);
        
        // assert
        Assert.Equal(Seed, dut1.Value);
    }
}