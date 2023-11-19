namespace Klinkby.Toolkitt.Tests;

[Trait("Category", "Unit")]
public class Identity_From
{
    const int Seed = 42;
    
    [Fact]
    public void Should_Create_Instance()
    {
        // arrange
        var dut1 = Identity.From(Seed);
        
        // act
        var dut2 = dut1.Bind(x => $"{x * 2}");
        
        // assert
        Assert.Equal("84", dut2.Value);
    }
}